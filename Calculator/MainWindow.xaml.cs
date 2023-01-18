using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            TBAge.Text = TBHeight.Text = TBKg.Text = TBAnswer.Text = "";
        }

        private void BCalculate_Click(object sender, RoutedEventArgs e)
        {
            double result, ratio;

            string error = "";

            if (string.IsNullOrWhiteSpace(TBAge.Text) == true || TBAge.Text.EndsWith(",") == true)
            {
                error += "Введите корректный возраст\n";
            }
            if (string.IsNullOrWhiteSpace(TBKg.Text) == true ||TBKg.Text.EndsWith(",") == true)
            {
                error += "Введите корректный вес\n";
            }
            if (string.IsNullOrWhiteSpace(TBHeight.Text) == true || TBHeight.Text.EndsWith(",") == true)
            {
                error += "Введите корректный рост\n";
            }
            if (string.IsNullOrWhiteSpace(error) == false)
            {
                MessageBox.Show(error);
                return;
            }



            if (Gender.Text=="0")
            {
                result= 66 + (13.7 * Convert.ToDouble(TBKg.Text)) + (5 * Convert.ToDouble(TBHeight.Text)) - (6.8 * Convert.ToInt32(TBAge.Text));
            }
            else 
            {
                result= 655 + (9.6 * Convert.ToDouble(TBKg.Text)) + (1.8 * Convert.ToDouble(TBHeight.Text)) - (4.7 * Convert.ToInt32(TBAge.Text));
            }
            ratio = GetRatio() * result;
            TBAnswer.Text = ratio.ToString();
        }

        private void TBAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;

            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
                e.Handled = true;

        }

        private void TBKg_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;

            if (Regex.IsMatch(e.Text, @"[0-9,]") == false)
                e.Handled = true;

            if (textBox.Text.Length == 0 && e.Text == ",")
                e.Handled = true;

            if (e.Text == "," && textBox.Text.Contains(','))
                e.Handled = true;
        }

        private double GetRatio()
        {
            switch (CBRatio.SelectedIndex)
            {
                case 0:
                    return 1.375;

                case 1:
                    return 1.55;

                case 2:
                    return 1.725;

                case 3:
                    return 1.9;

                    default:
                    return 1;
            }
        }

    }
}
