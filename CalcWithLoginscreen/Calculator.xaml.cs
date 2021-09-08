using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalcWithLoginscreen
{
    /// <summary>
    /// Логика взаимодействия для Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string cacl = calc.Text;

            try
            {
                object result = (object)new DataTable().Compute($"{cacl}", null);
                MessageBox.Show(result.ToString());
            }
            catch
            {
                MessageBox.Show("Чота непонятное");
            }
            
        }
    }
}
