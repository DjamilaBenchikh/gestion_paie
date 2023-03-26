using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using indemnite_retraite.Views;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Configuration;

namespace indemnite_retraite
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Fonctions Con;
        public MainWindow()
        {
            InitializeComponent();
            Bindatagrid();
        }

        private void Bindatagrid()
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-UD3ST4M\\SQLEXPRESS;Initial Catalog= Gestion_paie;Integrated Security=true");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Employes";
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Employes");
            da.Fill(dt);
            ListeSalaries.ItemsSource = dt.DefaultView;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1000;
                    this.Height = 7200;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NouveauSalarie w = new NouveauSalarie();
            w.Show();

        }
        /*private void ListerSalaries()
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-UD3ST4M\\SQLEXPRESS;Initial Catalog= indemmnite_retraite;Integrated Security=true");
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                   
                    string rc = "Select * from Employes";
                    
                    SqlCommand cmd = new SqlCommand(rc, conn);
                   
                    
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }*/
    }

    
}
