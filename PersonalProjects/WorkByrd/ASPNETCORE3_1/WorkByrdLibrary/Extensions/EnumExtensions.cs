using System;
using System.Linq;
using System.Reflection;

namespace WorkByrdLibrary.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Can return the Display attached to an Enum value.
        /// </summary>
        /// <param name="GenericEnum">An Enumeration type.</param>
        /// <returns>The Display Attribute value assigned to an Enum value.</returns>
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }
    }
}
