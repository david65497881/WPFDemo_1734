using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using WPFDemo_1734.Class;

namespace WPFDemo_1734
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadStockData();
        }

        private void LoadStockData()
        {
            try
            {
                // 取得資料庫連線字串
                //使用ConfigurationManager從App.config中讀取連線字串
                string connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;

                //使用using確保使用後會釋放資源
                using (IDbConnection db = new OracleConnection(connectionString))
                {
                    //查詢Stock表
                    string x = "SELECT stock_no, stock_name, low_price, high_price, modify_date, modify_user FROM Stock";
                    //將x傳到stockList
                    List<Stock> stockList = db.Query<Stock>(x).ToList();

                    //將stockList綁定到WPF中的 DataGrid
                    StockDataGrid.ItemsSource = stockList;
                }
            }
            //Exception是.NET中所有異常類別的基類，因此這個catch區塊可以捕捉到任何未被特定類型catch區塊捕獲的錯誤
            catch (Exception ex)
            {
                MessageBox.Show($"資料載入時發生錯誤：{ex.Message}", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

   
    
}
