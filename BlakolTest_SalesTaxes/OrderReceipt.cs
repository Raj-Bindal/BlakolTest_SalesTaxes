using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlakolTest_SalesTaxes
{
    public class OrderReceipt
    {
        //private List<OrderItem> orderItems = new List<OrderItem>();
        private double _total;
        private double _toalSalesTax;

        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                //Add Validation here based on data source
                _total = value;
            }
        }
        public double ToalSalesTax
        {
            get
            {
                return _toalSalesTax;
            }
            set
            {
                //Add Validation here based on data source
                _toalSalesTax = value;
            }
        }

        /// Basic sales tax is applicable at a rate of 10% on all goods; except books, food, and medical products that are exempt.
        /// Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions.
        public void GenerateOrderReceipt(List<OrderItem> orderItems)
        {
            try
            {
                foreach (var item in orderItems)
                {
                    CalculateTax(item);
                }

                //Print output to console
                PrintReceipt(orderItems);
            }
            catch (Exception ex)
            {
                //Log error to DB or text file here
            }
        }
        private void PrintReceipt(List<OrderItem> orderItems)
        {
            Console.WriteLine();
            Console.WriteLine("Output:");

            foreach (var item in orderItems)
            {
                Console.WriteLine(string.Format("{0} {1}: {2}", item.ItemQty, item.ItemName, item.ItemPriceAfterSalesTax));
            }

            Console.WriteLine(string.Format("Sales Taxes: {0} Total: {1}", ToalSalesTax, Total));
        }
        private void CalculateTax(OrderItem item)
        {
            try
            {
                double appliedSalesTaxPer = 0;

                //Basic sales tax is applicable at a rate of 10% on all goods; except books, food, and medical products that are exempt
                if (!item.IsExemptedItem)
                    appliedSalesTaxPer += Config.NonExemptedItemSalesTaxPer;

                if (item.IsImportedItem)
                    appliedSalesTaxPer += Config.NonImportedItemSalesTaxPer;

                item.TotalSalesTaxApplied = Config.RoundTwoDecimals(item.ItemPrice * appliedSalesTaxPer);
                item.ItemPriceAfterSalesTax = Config.RoundTwoDecimals(item.ItemPrice + item.TotalSalesTaxApplied);

                ToalSalesTax += item.TotalSalesTaxApplied;
                Total += item.ItemPriceAfterSalesTax;
            }
            catch (Exception ex)
            {
                //Log error to DB or text file here
            }
        }
    }
}
