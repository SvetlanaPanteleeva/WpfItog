using System;
using System.Data;
using System.Collections.Generic;
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

namespace WpfItog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {         
            InitializeComponent();
            textLabel.Text = 0.ToString();

            //общее действие (Клик) для всех кнопок:
            foreach (UIElement el in MainRoot.Children)
            { 
                if(el is Button)
                {
                  ((Button)el).Click += Button_Click;
                }
            }
        }      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
            double dn, res; res = 0;
 
            string str = (string)((Button)e.OriginalSource).Content;

            //обработка исключений:

            if (str == "C")
            {
                textLabel.Text = "0";
            }
            else if (str == "←")
            {
                textLabel.Text = textLabel.Text.Substring(0, textLabel.Text.Length - 1);
            }
            else if (textLabel.Text == "0" && textLabel.Text.Length > 0)
            {
                textLabel.Text = str;
            }
            else if (str == "=")
            {
                string value = new DataTable().Compute(textLabel.Text, null).ToString();
                textLabel.Text = value;
            }          
            else if (str == "√")
            {
                dn = Convert.ToDouble(textLabel.Text);
                res = Math.Sqrt(dn);
                textLabel.Text = Convert.ToString(res);
            }
            else if (str == "^")
            {
                dn = Convert.ToDouble(textLabel.Text);
                res = Math.Pow(dn, 2);
                textLabel.Text = Convert.ToString(res);
            }           
            else
                textLabel.Text += str;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
           