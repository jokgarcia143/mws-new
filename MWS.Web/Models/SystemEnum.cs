using System;
using System.ComponentModel;

namespace MWS.Web.Models
{
    public class SystemEnum
    {
        public enum TransType
        {
            [Description("NEW CONNECTION")]
            T1 = 1,
            [Description("WATER BILL ISSUE")]
            T2 = 2,
            [Description("Water Bill Payment")]
            T3 = 3,
            [Description("RECONNECTION FEE")]
            T4 = 4,
            [Description("REPLACEMENT FEE")]
            T5 = 5,
            [Description("OTHER FEE")]
            T6 = 6,
            [Description("OTHER INCOME")]
            T7 = 7
        }
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }

}
