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

		public static MvcHtmlString Image<T>(this HtmlHelper<T> helper, string src, string alt)
		{
			ExtTagBuilder tag = new ExtTagBuilder("img").With("src", src).And("alt", alt);
			return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
		}

		public static MvcHtmlString ImageLink<T>(this HtmlHelper<T> htmlHelper, string imgSrc, string alt, string actionName, string controllerName)
		{
			UrlHelper urlHelper = ((Controller)htmlHelper.ViewContext.Controller).Url;
			string imgtag = htmlHelper.Image(imgSrc, alt).ToString();
			string url = urlHelper.Action(actionName, controllerName);


			ExtTagBuilder imglink = new ExtTagBuilder("a").With("href", url);
			imglink.InnerHtml = imgtag;

			return MvcHtmlString.Create(imglink.ToString());
		}
		
		public static MvcHtmlString Pterodactyl<T>(this HtmlHelper<T> htmlHelper, string message)
		{
			return MvcHtmlString.Create(String.Format(@"<!--
	-\-                                                     
	\-- \-                                                  
	 \  - -\                                                
	  \      \\                                             
	   \       \                                            
		\       \\                                              
		 \        \\                                            
		 \          \\                                        
		 \           \\\                                      
		  \            \\                                                 
		   \            \\                                              
		   \. .          \\                                  
			\    .       \\                                 
			 \      .    \\                                            
			  \       .  \\                                 
			  \         . \\                                           
			  \            <=)                                         
			  \            <==)                                         
			  \            <=)                                           
			   \           .\\                                           _-
			   \         .   \\                                        _-//
			   \       .     \\                                     _-_/ /
			   \ . . .        \\                                 _--_/ _/
				\              \\                              _- _/ _/
				\               \\                      ___-(O) _/ _/ 
				\                \                  __--  __   /_ /      ***********************************
				\                 \\          ____--__----  /    \_       I AM A MOTHERFUCKING PTERODACTYL!
				 \                  \\       -------       /   \_  \_     {0}
				  \                   \                  //   // \__ \_   All credits to the oatmeal =)
				   \                   \\              //   //      \_ \_ **********************************
					\                   \\          ///   //          \__- 
					\                -   \\/////////    //            
					\            -         \_         //              
					/        -                      //                
				   /     -                       ///                  
				  /   -                       //                      
			 __--/                         ///
  __________/                            // |               
//-_________      ___                ////  |                
		____\__--/                /////    |                
   -----______    -/---________////        |                
	 _______/  --/    \                   |                 
   /_________-/       \                   |                 
  //                  \                   /                 
					   \.                 /                 
					   \     .            /                 
						\       .        /                  
					   \\           .    /                  
						\                /                  
						\              __|                  
						\              ==/                  
						/              //                   
						/          .  //                    
						/   .  .    //                      
					   /.           /                       
					  /            //                       
					  /           /
					 /          //
					/         //
				 --/         /
				/          //
			////         //
		 ///_________////


-->", message));
		}
	}
}
