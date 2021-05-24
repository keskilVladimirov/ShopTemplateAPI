using ShopTemplateAPI.Models.EnumModels;
using System.Collections.Generic;

namespace ShopTemplateAPI.Configurations
{
    //Конфигурация бизнес логики
    public class ShopConfiguration
    {
        public static decimal DeliveryPrice;
        public static int MaxPoints;
        public static List<PaymentMethod> PaymentMethods;
        public static int Version;
    }
}
