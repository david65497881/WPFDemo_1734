using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo_1734.Class
{
    /// <summary>
    /// Stock表單
    /// </summary>
    public class Stock
    {
        public string Stock_No { get; set; }
        public string Stock_Name { get; set; }
        public decimal Low_Price { get; set; }
        public decimal High_Price { get; set; }
        public DateTime Modify_Date { get; set; }
        public string Modify_User { get; set; }
    }
}
