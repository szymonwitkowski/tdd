using NUnit.Framework;
using Moq;
using TddShop.Cli.Order;
using TddShop.Cli.Order.Models;
using TddShop.Cli.Order.Repositories;

namespace TddShop.Cli.Tests.Order
{
    [TestFixture]
    public class OrderServiceTests
    {
        private OrderService _target;
        private Mock<IOrderRepository> _orderRepository;
        private Mock<IStockRepository> _stockRepository;

        [SetUp]
        public void Initialize()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _stockRepository = new Mock<IStockRepository>();

            _target = new OrderService(_orderRepository.Object, _stockRepository.Object);
        }

        [Test]
        public void PlaceOrder_IfOrderContainsItem_ShouldSaveOrder()
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

            //Act
            _target.PlaceOrder(order);

            //Assert
            _orderRepository.Verify(x => x.SaveOrder(order), Times.Once);
        }

        [Test]
        public void PlaceOrder_IfOrderContainsNoItem_ShouldNeverSaveOrder()
        {
            //Arrange
            var order = new OrderModel();

            //Act
            _target.PlaceOrder(order);

            //Assert
            _orderRepository.Verify(x => x.SaveOrder(order), Times.Never);
        }

        [Test]
        public void PlaceOrder_IfOrderContainsItem_ShouldDecreaseItemsInStock()
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

            //Act
            _target.PlaceOrder(order);

            //Assert
            _stockRepository.Verify(x => x.DecreaseItemsInStock("przedmiot", 2), Times.Once);
        }


    }
}
