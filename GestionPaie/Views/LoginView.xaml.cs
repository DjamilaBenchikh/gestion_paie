using indemnite_retraite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Formation_WPF.Views
{
    /// <summary>
    /// Logique d'interaction pour LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(" Data Source = DESKTOP-UD3ST4M\\SQLEXPRESS;Initial Catalog= gestion_paie;Integrated Security=true");
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    string rc = "select Count(1) from utilisateurs where login=@login and mot_pass=@password";
                    SqlCommand cmd = new SqlCommand(rc, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@login", login.Text);
                    cmd.Parameters.AddWithValue("@password", password.Password);
                    cmd.ExecuteNonQuery();
                    int count = Convert.ToInt16(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        MainWindow w = new MainWindow();
                        w.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("mot de pass incorrect");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }


            conn.Close();
        }
    }
}
