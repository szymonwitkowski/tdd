using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddShop.Cli.Order.Models;
using TddShop.Cli.Shipment;

namespace TddShop.Cli.Tests.Shipment
{
    [TestFixture]
    public class AncientRomeShippingServiceTests
    {
        private Mock<IDeliveryService> _deliveryService;
        private Mock<INumeralsConvereter> _numeralsConvereter;
        private AncientRomeShippingService _target;

        [SetUp]
        public void Initialize()
        {
            _deliveryService = new Mock<IDeliveryService>();
            _numeralsConvereter = new Mock<INumeralsConvereter>();
            _target = new AncientRomeShippingService(_deliveryService.Object, _numeralsConvereter.Object);           
        }
        [Test]
        public void ShipOrder_IfOrderContainsAtLeast1item_DeliveryServiceShouldReturnShipmentReferenceNumberOnce()
        {
            //Arrange            
             var order = new OrderModel
             {
                 Items = new ItemModel[] {
                    new ItemModel
                    {
                        Name = "przedmiot",
                        Quantity = 2
                    }

                }
             };
            var itemsNumber = 1;            

            //Act
            _target.ShipOrder(order);

            //Assert
            _deliveryService.Verify(x => x.GenerateShipmentReferenceNumber(itemsNumber), Times.Once);

        }

        [Test]
        public void ShipOrder_IfOrderIsEmpty_DeliveryServiceShouldNeverReturnShipmentReferenceNumber()
        {
            //Arrange            
            var order = new OrderModel();
            var itemsNumber = 0;

            //Act
            _target.ShipOrder(order);

            //Assert
            _deliveryService.Verify(x => x.GenerateShipmentReferenceNumber(itemsNumber), Times.Never);

        }

        [Test]
        public void ShipOrder_IfShipmentReferenceNumberGraterThen3999_ArabicToRomanConverterShouldNeverConvert()
        {
            //Arrange            
            var order = new OrderModel
            {
                Items = new ItemModel[] {
                    new ItemModel
                    {
                        Name = "przedmiot",
                        Quantity = 2
                    }

                }
            };
            var itemsNumber = 1;
            var shipmentReferenceNumber = 4000;
            _deliveryService.Setup(x => x.GenerateShipmentReferenceNumber(itemsNumber)).Returns(shipmentReferenceNumber);

            //Act
            _target.ShipOrder(order);

            //Assert
           _numeralsConvereter.Verify(x => x.ArabicToRomanNumeralsConverter(shipmentReferenceNumber), Times.Never);

        }

        [Test]
        public void ShipOrder_IfShipmentReferenceNumberLessThen1_ArabicToRomanConverterShouldNeverConvert()
        {
            //Arrange            
            var order = new OrderModel
            {
                Items = new ItemModel[] {
                    new ItemModel
                    {
                        Name = "przedmiot",
                        Quantity = 2
                    }

                }
            };
            var itemsNumber = 1;
            var shipmentReferenceNumber = -2;
            _deliveryService.Setup(x => x.GenerateShipmentReferenceNumber(itemsNumber)).Returns(shipmentReferenceNumber);

            //Act
            _target.ShipOrder(order);

            //Assert
            _numeralsConvereter.Verify(x => x.ArabicToRomanNumeralsConverter(shipmentReferenceNumber), Times.Never);

        }

        [Test]
        public void ShipOrder_IfShipmentReferenceNumberBetween1and3999_ArabicToRomanConverterShouldConvertOnce()
        {
            //Arrange            
            var order = new OrderModel
            {
                Items = new ItemModel[] {
                    new ItemModel
                    {
                        Name = "przedmiot",
                        Quantity = 2
                    }

                }
            };
            var itemsNumber = 1;
            var shipmentReferenceNumber = 3382;
            _deliveryService.Setup(x => x.GenerateShipmentReferenceNumber(itemsNumber)).Returns(shipmentReferenceNumber);

            //Act
            _target.ShipOrder(order);

            //Assert
            _numeralsConvereter.Verify(x => x.ArabicToRomanNumeralsConverter(shipmentReferenceNumber), Times.Once);

        }

        [Test]
        public void ShipOrder_AllValidData_RequestDeliveryShouldStartOnce()
        {
            //Arrange            
            var order = new OrderModel
            {
                Items = new ItemModel[] {
                    new ItemModel
                    {
                        Name = "przedmiot",
                        Quantity = 2
                    }

                }
            };
            var itemsNumber = 1;
            var shipmentReferenceNumber = 3382;
            var convertedShipmentReferenceNumber = "MMMCCCLXXXII";
            _deliveryService.Setup(x => x.GenerateShipmentReferenceNumber(itemsNumber)).Returns(shipmentReferenceNumber);
            _numeralsConvereter.Setup(x => x.ArabicToRomanNumeralsConverter(shipmentReferenceNumber)).Returns(convertedShipmentReferenceNumber);
            

            //Act
            _target.ShipOrder(order);

            //Assert
            _deliveryService.Verify(x => x.RequestDelivery(convertedShipmentReferenceNumber, order), Times.Once);
        }

        [Test]
        public void ShipOrder_IfOrderItemIsNull_RequestDeliveryShouldNeverStart()
        {
            //Arrange            
            var order = new OrderModel
            {
                Items = new ItemModel[] {null}
            };            
            var convertedShipmentReferenceNumber = "MMMCCCLXXXII";


            //Act
            _target.ShipOrder(order);

            //Assert
            _deliveryService.Verify(x => x.RequestDelivery(convertedShipmentReferenceNumber, order), Times.Never);
        }


    }
}
