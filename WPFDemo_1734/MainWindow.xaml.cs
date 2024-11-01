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
                string connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;

                using (IDbConnection db = new OracleConnection(connectionString))
                {
                    // 查詢 Stock 表
                    string query = "SELECT stock_no, stock_name, low_price, high_price, modify_date, modify_user FROM Stock";
                    List<Stock> stockList = db.Query<Stock>(query).ToList();

                    // 綁定資料到 DataGrid
                    StockDataGrid.ItemsSource = stockList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"資料載入時發生錯誤：{ex.Message}", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

   
    
}
