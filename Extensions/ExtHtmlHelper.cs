using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Aethelflaed.Extensions
{
	public static class ExtHtmlHelper
	{
		public static MvcHtmlString DropDownForEnum<T, U>(this HtmlHelper<T> h, Expression<Func<T, U>> func) where T : new()
		{
			Type enumType = typeof(U);

			T model = h.ViewData.Model;
			if (model == null)
			{
				model = new T();
			}
			string name = ((MemberExpression)func.Body).Member.Name;
			U selectedValue = func.Compile()(model);

			ExtTagBuilder tag = new ExtTagBuilder("select").With("name", name).And("id", name);

			foreach (U val in Enum.GetValues(enumType))
			{
				//string enumText = Resources.ResourceManager.GetString(val.ToString());
				//if (String.IsNullOrEmpty(enumText)) enumText = val.ToString();
				string enumText = val.ToString();
				ExtTagBuilder option = new ExtTagBuilder("option").With("value", (val).ToString()).AndIf(val.Equals(selectedValue), "selected", "selected").WithText(enumText);
				tag.Append(option);
			}
			return MvcHtmlString.Create(tag.ToString());
		}
	}
}