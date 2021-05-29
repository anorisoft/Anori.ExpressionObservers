using System;
using System.Collections.Generic;
using System.Text;

namespace Anori.ExpressionTrees
{
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class TypeExtensions
    {
        public static bool AreMethodsEqualForDeclaringType(this MethodInfo first, MethodInfo second)
        {
            first = first.ReflectedType == first.DeclaringType ? first : first.DeclaringType.GetMethod(first.Name, first.GetParameters().Select(p => p.ParameterType).ToArray());
            second = second.ReflectedType == second.DeclaringType ? second : second.DeclaringType.GetMethod(second.Name, second.GetParameters().Select(p => p.ParameterType).ToArray());
            return first == second;
        }

        public static bool IsIndexer(this Type type, MethodInfo methodInfo)
        {
            return GetIndexers(type).Any(i => AreMethodsEqualForDeclaringType(i.GetMethod, methodInfo));
        }

        public static bool IsIndexer(this Type type, MethodCallExpression methodCallExpression)
        {
            return type.IsIndexer(methodCallExpression.Method);
        }

        public static IEnumerable<PropertyInfo> GetIndexers(this Type type)
        {
            var indexers = type.GetProperties().Where(p => p.GetIndexParameters().Length > 0).ToList();
            return indexers;
        }

        private static MethodInfo GetInterfaceMethod(this Type implementingClass, Type implementedInterface, MethodInfo classMethod)
        {
            var map = implementingClass.GetInterfaceMap(implementedInterface);
            var index = Array.IndexOf(map.TargetMethods, classMethod);
            return map.InterfaceMethods[index];
        }
    }
}