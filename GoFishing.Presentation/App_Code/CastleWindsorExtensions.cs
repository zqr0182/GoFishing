using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;

namespace GoFishing.Presentation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class WireAttribute : Attribute
    {

    }
    public static class CastleWindsorExtensions
    {
        private static readonly Type _wireAttributeType = typeof(WireAttribute);

        public static void InjectProperties(this IKernel kernel, object target)
        {
            var type = target.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.GetCustomAttributes(true).Any(a => a.GetType() == _wireAttributeType)).ToList();
            foreach (var property in properties)
            {
                if (property.CanWrite && kernel.HasComponent(property.PropertyType))
                {
                    var value = kernel.Resolve(property.PropertyType);
                    try
                    {
                        property.SetValue(target, value, null);
                    }
                    catch (Exception ex)
                    {
                        var message = string.Format("Error setting property {0} on type {1}, See inner exception for more information.", property.Name, type.FullName);
                        throw new ComponentActivatorException(message, ex, null);
                    }
                }
            }
        }
    }
}