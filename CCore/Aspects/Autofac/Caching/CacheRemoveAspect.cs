using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Caching;
using Core.Utilities.Helpers;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _methodName;
        private readonly ICacheService _cacheService;

        public CacheRemoveAspect(string methodName)
        {
            _methodName = methodName;
            _cacheService = (ICacheService)HttpContext.Current.RequestServices.GetService(typeof(ICacheService));
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            string[] methods = _methodName.Split(',');
            foreach (string method in methods)
                _cacheService.Remove($"Bussines.Abstract.{method}()");
        }
    }
}