using System.Linq;
using TddShop.Cli.Order.Models;


namespace TddShop.Cli.Shipment
{
    public class AncientRomeShippingService
    {
        private readonly IDeliveryService _deliveryService;
        private readonly INumeralsConvereter _numeralsConvereter;

        public AncientRomeShippingService(IDeliveryService deliveryService, INumeralsConvereter numeralsConvereter)
        {
            _deliveryService = deliveryService;
            _numeralsConvereter = numeralsConvereter;
        }

        /// <summary>
        /// To ship an order you need to generate a shipment reference number (see IDeliveryService).
        /// Ancient Rome works with romanian numbers so you will need to convert shipment reference number to a valid romanian number (string).
        /// Use IDeliveryService to ship an order.
        ///                
        /// </summary>
        /// <param name="order"></param>
        public void ShipOrder(OrderModel order)
        {
            if (order.Items.Count() >= 1)
            {
                var shipmentReferenceNumber = _deliveryService.GenerateShipmentReferenceNumber(order.Items.Count());
                if (shipmentReferenceNumber > 0 && shipmentReferenceNumber < 4000)
                {
                    var convertedShipmentReferenceNumber = _numeralsConvereter.ArabicToRomanNumeralsConverter(shipmentReferenceNumber);
                    _deliveryService.RequestDelivery(convertedShipmentReferenceNumber, order);
                }

            }
          
        }
    }    
}
