using System;
using System.ComponentModel;

namespace LegendaryMarvelRandomizer.Core.Utils
{
    public static class ObjectExtensions
    {
        public static string GetDescription(this object obj)
        {
            var result = string.Empty;
            if (obj != null)
            {
                var attribute = obj.GetAttribute<DescriptionAttribute>();
                result = (attribute == null) ? string.Empty : attribute.Description;
            }
            return result;
        }

        public static T GetAttribute<T>(this object obj) where T : Attribute
        {
            if (obj != null)
            {
                var field = obj.GetType().GetField(obj.ToString());
                if (field != null)
                {
                    return Attribute.GetCustomAttribute(field, typeof(T)) as T;
                }
            }
            return null;
        }
    }
}
