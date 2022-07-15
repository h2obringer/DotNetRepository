using System;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WorkByrdLibrary.Utils
{
    public static class DataUtils
    {
        public static decimal GetDecimal(object val)
        {
            if (val == null)
            {
                return 0;
            }
            try
            {
                switch (val)
                {
                    case decimal _:
                    case Int64 _:
                    case Int32 _:
                    case Int16 _:
                    case sbyte _:
                    case byte _:
                    case ushort _:
                    case uint _:
                    case ulong _:
                    case float _:
                    case double _:
                        return Convert.ToDecimal(val);
                    case string _:
                        return decimal.Parse(val.ToString(), CultureInfo.InvariantCulture);
                    default:
                        return -1;
                }
            }
            catch
            {
                return -1;
            }
        }

        public static Int16 GetInt16(object val)
        {
            if (val == null)
            {
                return 0;
            }
            try
            {
                switch (val)
                {
                    case decimal _:
                    case Int64 _:
                    case Int32 _:
                    case Int16 _:
                    case sbyte _:
                    case byte _:
                    case ushort _:
                    case uint _:
                    case ulong _:
                    case float _:
                    case double _:
                        return Convert.ToInt16(val);
                    case string _:
                        return Int16.Parse(val.ToString(), CultureInfo.InvariantCulture);
                    default:
                        return -1;
                }
            }
            catch
            {
                return -1;
            }
        }

        public static int GetInt(object val)
        {
            if (val == null)
            {
                return 0;
            }
            try
            {
                switch (val)
                {
                    case decimal _:
                    case Int64 _:
                    case Int32 _:
                    case Int16 _:
                    case sbyte _:
                    case byte _:
                    case ushort _:
                    case uint _:
                    case ulong _:
                    case float _:
                    case double _:
                        return Convert.ToInt32(val);
                    case string _:
                        return int.Parse(val.ToString(), CultureInfo.InvariantCulture);
                    default:
                        return -1;
                }
            }
            catch
            {
                return -1;
            }
        }

        public static long GetLong(object val)
        {
            if (val == null)
            {
                return 0;
            }
            try
            {
                switch (val)
                {
                    case decimal _:
                    case Int64 _:
                    case Int32 _:
                    case Int16 _:
                    case sbyte _:
                    case byte _:
                    case ushort _:
                    case uint _:
                    case ulong _:
                    case float _:
                    case double _:
                        return Convert.ToInt64(val);
                    case string _:
                        return long.Parse(val.ToString(), CultureInfo.InvariantCulture);
                    default:
                        return -1;
                }
            }
            catch
            {
                return -1;
            }
        }

        public static string GetString(object val)
        {
            return (string)val; //this might need to be a little more robust than this...
        }

        public static bool GetBool(object val)
        {
            if (val == null)
            {
                return false;
            }
            try
            {
                switch (val)
                {
                    case decimal _:
                    case Int64 _:
                    case Int32 _:
                    case Int16 _:
                    case sbyte _:
                    case byte _:
                    case ushort _:
                    case uint _:
                    case ulong _:
                    case float _:
                    case double _:
                        Int64 temp = Convert.ToInt64(val);
                        return temp > 0 || temp == -1;
                }
                if (val is string)
                {
                    if (Regex.IsMatch((string)val, @"yes|Yes|YES|-1|1|true|True|TRUE"))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsSimple(Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                //nullable type, check if the nested type is simple.
                return IsSimple(typeInfo.GetGenericArguments()[0]);
            }
            return typeInfo.IsPrimitive || typeInfo.IsEnum || type.Equals(typeof(string)) || type.Equals(typeof(decimal));
        }

        public static bool IsBoolean(Type type, object value)
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                //nullable type, check if the nested type is simple.
                return IsBoolean(typeInfo.GetGenericArguments()[0], value);
            }
            return type.Equals(typeof(bool)) || type.Equals(typeof(Boolean));
        }
    }
}
