using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;


namespace CalcWithLoginscreen
{
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        // LOGIN WINDOW
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            // DB
            string connectionString = ConfigurationManager.ConnectionStrings["userdb"].ConnectionString;
            SqlConnection sqlConnection = null;

            // Data
            string xlogin = xLoginBox.Text;
            string xpass = xPassBox.Password;

            // Login lenght check
            if (xlogin.Length < 5)
            { MessageBox.Show("Длина логина должна быть больше 5 символов с:"); }

            // Pass lenght check
            else if (xpass.Length < 5)
            { MessageBox.Show("Длина пароля должна быть больше 5 символов с:"); }

            // If everything is Ok -> reg  
            else 
            {
                // Add to the database data
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlDataReader dr;

                // Querry
                SqlCommand command = new SqlCommand($"SELECT * FROM UsersDB WHERE login='{xlogin}' AND pass='{xpass}'", sqlConnection);

                // Reader
                dr = command.ExecuteReader();
                dr.Read();

                // Check data in database
                try
                {
                    if ((string)dr["login"] != "" & (string)dr["pass"] != "")
                    {
                        MessageBox.Show("Вход успешно выполнен");

                        Calculator calc = new Calculator();
                        calc.Show();
                        Hide();

                    }
                }
                catch
                {
                    MessageBox.Show("Вы не зарегистрированы");
                }
            }

        }
    }
}
