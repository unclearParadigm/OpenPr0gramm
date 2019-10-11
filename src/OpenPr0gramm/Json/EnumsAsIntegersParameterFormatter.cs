using System;
using System.Reflection;
using OpenPr0gramm.Structures;
using Refit;

namespace OpenPr0gramm.Json
{
    internal class EnumsAsIntegersParameterFormatter : IUrlParameterFormatter
    {
        // See: https://github.com/paulcbetts/refit/issues/184#issuecomment-137324961
        public string Format(object parameterValue, ParameterInfo parameterInfo)
        {
            if (parameterValue == null)
                return null;
            var info = Denullify(parameterInfo.ParameterType);
            if (info.IsEnum && parameterInfo.ParameterType == typeof(ItemFlags))
                return ((int) ((ItemFlags) parameterValue)).ToString();
            return parameterValue.ToString();
        }

        // Just makes sure you have the generic type arg for Nullable<T>
        private static TypeInfo Denullify(Type type)
        {
            var info = type.GetTypeInfo();
            if (info.IsGenericType && info.GetGenericTypeDefinition() == typeof(Nullable<>))
                return type.GenericTypeArguments[0].GetTypeInfo();
            return info;
        }
    }
}
