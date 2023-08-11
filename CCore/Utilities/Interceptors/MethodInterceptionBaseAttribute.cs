using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor //Castle.DynamicProxy; İNDİR
    {
        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
