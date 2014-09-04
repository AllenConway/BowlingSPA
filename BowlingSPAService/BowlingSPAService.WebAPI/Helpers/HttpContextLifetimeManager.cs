using System;
using System.Web;
using Microsoft.Practices.Unity;

namespace BowlingSPAService.WebAPI.Helpers
{
    public class HttpContextLifetimeManager : LifetimeManager, IDisposable
    {
        private readonly Guid itemName;

        public HttpContextLifetimeManager()
        {
            itemName = Guid.NewGuid();
        }

        public override object GetValue()
        {
            if (HttpContext.Current != null) return HttpContext.Current.Items[itemName];
            return null;
        }

        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(itemName);
        }

        public override void SetValue(object newValue)
        {
            if (HttpContext.Current != null) HttpContext.Current.Items[itemName] = newValue;
        }

        public void Dispose()
        {
            RemoveValue();
        }
    }
}