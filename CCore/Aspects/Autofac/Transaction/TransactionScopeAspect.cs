using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {

                    invocation.Proceed();
                    if (invocation.ReturnValue is Task returnValueTask)
                    {
                        returnValueTask.GetAwaiter().GetResult();
                    }

                    if (invocation.ReturnValue is Task task && task.Exception != null)
                    {
                        throw task.Exception;
                    }

                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    //işlemi hataya düşür
                    transactionScope.Dispose();
                    throw;
                }

            }
            base.Intercept(invocation);
        }
    }
}
