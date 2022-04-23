using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlakolTest_SalesTaxes
{
    public class OrderItem
    {
        private string _itemName;
        private int _itemQty;
        private double _itemPrice;
        private double _itemPriceAfterSalesTax;
        private double _totalSalesTaxApplied;
        //private ItemTypeEnum _itemType;
        private bool _isImportedItem;
        private bool _isExemptedItem;

        public OrderItem(string itemName, int qty, double price, bool isImported, bool isExempted)
        {
            this.ItemName = itemName;
            this.ItemQty = qty;
            this.ItemPrice = price;
            this.IsImportedItem = isImported;
            this.IsExemptedItem = isExempted;
        }

        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                //Add Validation here based on data source
                _itemName = value;
            }
        }
        public int ItemQty
        {
            get
            {
                return _itemQty;
            }
            set
            {
                //Add Validation here based on data source
                _itemQty = value;
            }
        }
        public double ItemPrice 
        {
            get 
            {
                return _itemPrice;
            }
            set
            {
                //Add Validation here based on data source
                _itemPrice = value;
            }
        }
        public double ItemPriceAfterSalesTax
        {
            get
            {
                return _itemPriceAfterSalesTax;
            }
            set
            {
                //Add Validation here based on data source
                _itemPriceAfterSalesTax = value;
            }
        }
        public double TotalSalesTaxApplied
        {
            get
            {
                return _totalSalesTaxApplied;
            }
            set
            {
                //Add Validation here based on data source
                _totalSalesTaxApplied = value;
            }
        }
        //public ItemTypeEnum ItemType
        //{
        //    get
        //    {
        //        return _itemType;
        //    }
        //    set
        //    {
        //        //Add Validation here based on data source
        //        _itemType = value;
        //    }
        //}
        public bool IsImportedItem
        {
            get
            {
                return _isImportedItem;
            }
            set
            {
                //Add Validation here based on data source
                _isImportedItem = value;
            }
        }
        public bool IsExemptedItem
        {
            get
            {
                return _isExemptedItem;
            }
            set
            {
                //Add Validation here based on data source
                _isExemptedItem = value;
            }
        }
    }	
}