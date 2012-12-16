ASP.Net-MVC-Helpers
===================

Some ASP.Net MVC 4 helpers I create / find / improve

You may feel convenient to use :

- *Extension/ExtTagBuilder*: A subclass of TagBuilder which permits to chain commands in an easy way.
- *Extension/ExtHtmlHelper*: A set of extension methods for HtmlHelper.
  - DropDownForEnum: Create a drop down list for the enum identified using the lambda expression. For example : @Html.DropDownForEnum(m => m.Gender).
- *Filters/DiscardAttribute*: Simply negates the AuthorizeAttribute mecanism. Used when you want a page available only for logout users (typically, register and login pages).
