namespace Cik.Web.Utilities.Extensions
{
    using System;

    public static class ConvertExtensions
    {
         public static int ConvertToInteger(this string source)
         {
             return Convert.ToInt32(source);
         }
    }
}