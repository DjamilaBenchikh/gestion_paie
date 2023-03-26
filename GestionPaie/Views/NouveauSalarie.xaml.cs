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

namespace indemnite_retraite.Views
{
    /// <summary>
    /// Logique d'interaction pour NouveauSalarie.xaml
    /// </summary>
    public partial class NouveauSalarie : Window
    {
   
        public NouveauSalarie()
        {
            InitializeComponent();
            
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-UD3ST4M\\SQLEXPRESS;Initial Catalog= indemmnite_retraite;Integrated Security=true");
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    String id = "hh";
                    String nomt = Nom.Text;
                    MessageBox.Show(nomt);
                    String prenom = Prenom.Text;
                    String date_nais = Date_nais.Text;
                    String date_debut = Date_debut.Text;
                    String salaire_de_debut = Salaire_de_debut.Text;
                    string rc = "INSERT INTO Employes ([id],[nom],[prenom],[date_naissance],[date_debut],[salaire_debut]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')";
                    rc = String.Format(rc, id, nomt, prenom, date_nais, date_debut, salaire_de_debut);
                   
                    SqlCommand cmd = new SqlCommand(rc, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                
                    cmd.ExecuteNonQuery();
                    Nom.Text = "";
                    Prenom.Text = "";
                    Date_nais.Text = "";
                    Date_debut.Text = "";
                    Salaire_de_debut.Text = "";



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }


        }
    }
}
