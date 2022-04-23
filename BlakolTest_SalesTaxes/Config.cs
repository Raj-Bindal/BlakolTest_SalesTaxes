using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlakolTest_SalesTaxes
{
    public static class Config
    {
        public static double NonExemptedItemSalesTaxPer = 0.10;
        public static double NonImportedItemSalesTaxPer = 0.05;
        public static List<string> exemptedItemList = new List<string>() { "book", "chocolate", "pill" };
        public static string string_Imported = "imported";

        public static double RoundTwoDecimals(double val)
        {
            return Math.Round(val, 2, MidpointRounding.AwayFromZero);
        }
    }
}
