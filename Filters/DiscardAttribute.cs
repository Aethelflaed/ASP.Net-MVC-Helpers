using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Aethelflaed.Filters
{
	[AttributeUsage(AttributeTargets.Class |
		AttributeTargets.Method,
		Inherited = true,
		AllowMultiple = true)]
	public class DiscardAttribute : AuthorizeAttribute
	{
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			return !base.AuthorizeCore(httpContext);
		}

		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (AuthorizeCore(filterContext.HttpContext) == false)
			{
				filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
				{
					{"controller", RedirectToController},
					{"action", RedirectToAction}
				});
			}
		}

		private string redirectToController = "Home";

		public string RedirectToController
		{
			get { return redirectToController; }
			set { redirectToController = value; }
		}

		private string redirectToAction = "Index";

		public string RedirectToAction
		{
			get { return redirectToAction; }
			set { redirectToAction = value; }
		}
		
	}
}