using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlakolTest_SalesTaxes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read Inputs
            string parentPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string input1 = Path.Combine(parentPath, "BlakolTest_SalesTaxes\\inputs\\input1.txt");
            string input2 = Path.Combine(parentPath, "BlakolTest_SalesTaxes\\inputs\\input2.txt");
            string input3 = Path.Combine(parentPath, "BlakolTest_SalesTaxes\\inputs\\input3.txt");

            List<string> inputsPaths = new List<string>() { input1, input2, input3 };

            foreach (string path in inputsPaths)
            {
                OrderReceipt receipt1 = new OrderReceipt();
                receipt1.GenerateOrderReceipt(ConvertInputFileIntoItems(path));
            }
        }

		private static List<OrderItem> ConvertInputFileIntoItems(string filePath)
		{
            List<OrderItem> items = new List<OrderItem>();

            try
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        // 1 book at 12.49
                        // 1 music CD at 14.99
                        // 1 chocolate bar at 0.85

                        string[] data = line.Trim().Split(" at ");                        

                        //Get Price of item
                        double itemPrice = Convert.ToDouble(data[1].ToString().Trim());

                        string[] data1 = data[0].ToString().Trim().Split(" ");

                        //Get Qty
                        int qty = Convert.ToInt32(data1[0]);

                        //get item name
                        string name = string.Empty;

                        for (int i = 1; i < data1.Length; i++)
                            name += data1[i] + " ";

                        //check item is imported or not
                        bool importedItem = line.ToLower().Contains(Config.string_Imported);

                        //check item is exempted or not
                        bool isExemptedItem = false;
                        foreach (var item in Config.exemptedItemList)
                        {
                            if (line.Contains(item))
                            {
                                isExemptedItem = true;
                                break;
                            }
                        }

                        //Add Item to to shopping Cart List
                        OrderItem newItem = new OrderItem(name.Trim(), qty, itemPrice, importedItem, isExemptedItem);
                        items.Add(newItem);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log error to db or txt file
            }

            return items;
        }
    }
}
