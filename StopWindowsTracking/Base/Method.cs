using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using StopWindowsTracking.Base;

namespace StopWindowsTracking
{
    static class Method
    {
        public static List<IRegEdit> GetRegEdits()
        {
            List<IRegEdit> methods = new List<IRegEdit>();

            IEnumerable<Type> types = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "StopWindowsTracking.Methods.RegEdits");
            foreach (Type type in types)
                methods.Add(Activator.CreateInstance(type) as IRegEdit);

            return methods;
        }

        public static List<ICustom> GetCustom()
        {
            List<ICustom> methods = new List<ICustom>();

            IEnumerable<Type> types = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "StopWindowsTracking.Methods.Custom");
            foreach (Type type in types)
                methods.Add(Activator.CreateInstance(type) as ICustom);

            return methods;
        }

        private static IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
            => assembly.GetTypes().Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
    }
}
