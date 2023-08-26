﻿using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterseptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            return classAttributes.ToArray();
        }
    }
}