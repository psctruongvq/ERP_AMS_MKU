using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace PSC_ERP_Common
{
    public class AttributeUtil
    {
        public static string GetDescription(Object obj)
        {
            Type type = obj.GetType();

            var descriptions = (DescriptionAttribute[])type.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (descriptions.Length == 0)
            {
                return null;
            }
            return descriptions[0].Description;
        }
        public static string GetEnumFieldDescription(Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo info = type.GetField(name);
                if (info != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(info,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
        public static string GetFieldDescription(Object obj, String fieldName)
        {
            Type type = obj.GetType();

            if (fieldName != null)
            {
                FieldInfo info = type.GetField(fieldName);
                if (info != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(info,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
        public static string GetPropertyDescription(Object obj, String propertyName)
        {
            Type type = obj.GetType();

            if (propertyName != null)
            {
                PropertyInfo info = type.GetProperty(propertyName);
                if (info != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(info,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
        public static string GetMethodDescription(Object obj, String methodName)
        {
            Type type = obj.GetType();

            if (methodName != null)
            {
                MethodInfo info = type.GetMethod(methodName);
                if (info != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(info,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
        public static string GetConstructorDescription(Object obj, Type[] constructorParameterTypes)
        {

            //MyConstructor(int x){}
            //Type[] constructorParameterTypes = new Type[1];
            //constructorParameterTypes[0] = typeof(int);

            Type type = obj.GetType();

            ConstructorInfo info = type.GetConstructor(constructorParameterTypes);
            if (info != null)
            {
                DescriptionAttribute attr =
                       Attribute.GetCustomAttribute(info,
                         typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }

            return null;
        }
    }
}
