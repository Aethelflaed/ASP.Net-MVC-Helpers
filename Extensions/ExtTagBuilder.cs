using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aethelflaed.Extensions
{
	public class ExtTagBuilder : TagBuilder
	{
		public ExtTagBuilder(string TagName)
			: base(TagName)
		{

		}

		public ExtTagBuilder Append(ExtTagBuilder innerTag)
		{
			base.InnerHtml += innerTag.ToString();
			return this;
		}

		public ExtTagBuilder WithText(string text)
		{

			base.InnerHtml += text;
			return this;
		}

		public ExtTagBuilder With(ExtTagBuilder innerTag)
		{
			base.InnerHtml = innerTag.ToString();
			return this;
		}

		public ExtTagBuilder With(string attributeName, string attributeValue)
		{
			base.Attributes.Add(attributeName, attributeValue);
			return this;
		}

		public ExtTagBuilder And(string attributeName, string attributeValue)
		{
			base.Attributes.Add(attributeName, attributeValue);
			return this;
		}


		public ExtTagBuilder AndIf(bool condition, string attributeName, string attributeValue)
		{
			if (condition)
				base.Attributes.Add(attributeName, attributeValue);
			return this;
		}

	}
}