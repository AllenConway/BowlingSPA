using System;
using System.Web;
using Microsoft.Practices.Unity;

namespace BowlingSPAService.WebAPI.Helpers
{
    /// <summary>
    /// This class subsidizes Unity's IoC container to allow a "per request" lifetime manager for dependencies like database sessions to prevent unintended concurrency issues.
    /// This ensures the container will resolve the same instance per http request scope.
    /// </summary>
    /// <remarks>Derived from: http://bit.ly/YvnzEO and http://bit.ly/Zgmr83 </remarks>
    public class HttpContextLifetimeManager : LifetimeManager, IDisposable
    {

        private readonly Guid key = Guid.NewGuid();

        public override object GetValue()
        {
            if (HttpContext.Current != null && HttpContext.Current.Items.Contains(key))
                return HttpContext.Current.Items[key];
            else
                return null;
        }

        public override void RemoveValue()
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items.Remove(key);
        }

        public override void SetValue(object newValue)
        {
            if (HttpContext.Current != null) 
                HttpContext.Current.Items[key] = newValue;
        }

        public void Dispose()
        {
            RemoveValue();
        }
    }
}