using System;
using System.Collections.Generic;
using LiteNetLib;

namespace Network
{
    public static class UdpDeliveryHelper
    {
        private static Dictionary<DeliveryType, DeliveryMethod> _deliveryTypes = new()
        {
            { DeliveryType.Reliable, DeliveryMethod.ReliableOrdered },
            { DeliveryType.Unreliable, DeliveryMethod.Sequenced },
        };
        
        public static DeliveryMethod GetDeliveryMethod(DeliveryType type)
        {
            if (_deliveryTypes.TryGetValue(type, out var method))
            {
                return method;
            }

            throw new Exception($"Unknown delivery type {type}");
        }
    }
}