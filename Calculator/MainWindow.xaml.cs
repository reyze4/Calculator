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

        bool isMax = true;

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            TBAge.Text = TBHeight.Text = TBKg.Text = TBTDEE.Text = TBBMR.Text = string.Empty;
            TBKg.MaxLength = 3;
        }

        private void BCalculate_Click(object sender, RoutedEventArgs e)
        {
            double result, ratio;
            TBBMR.Text = TBTDEE.Text = string.Empty;

            string error = "";

            if (string.IsNullOrWhiteSpace(TBAge.Text) == true || TBAge.Text.EndsWith(",") == true
                || !(Convert.ToDouble(TBAge.Text) <= 80  && Convert.ToDouble(TBAge.Text) >= 15))
            {
                error += "-Введите корректный возраст\n(15 - 80 лет)\n";
                TBAge.Text = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(TBKg.Text) == true ||TBKg.Text.EndsWith(",") == true
                || !(Convert.ToDouble(TBKg.Text) >= 40 && Convert.ToDouble(TBKg.Text) <= 500))
            {
                error += "-Введите корректный вес\n(40 - 500 кг)\n";
                TBKg.Text = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(TBHeight.Text) == true || TBHeight.Text.EndsWith(",") == true
                || !(Convert.ToDouble(TBHeight.Text) <= 220 && Convert.ToDouble(TBHeight.Text) >= 120))
            {
                error += "-Введите корректный рост\n(120 - 220 см)\n";
                TBHeight.Text = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(error) == false)
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }



            if (Gender.SelectedIndex == 0)
            {
                result= 66 + (13.7 * Convert.ToDouble(TBKg.Text.Replace(" ", ""))) + (5 * Convert.ToDouble(TBHeight.Text.Replace(" ", "")) - (6.8 * Convert.ToInt32(TBAge.Text.Replace(" ", ""))));
            }
            else 
            {
                result= 655 + (9.6 * Convert.ToDouble(TBKg.Text.Replace(" ", ""))) + (1.8 * Convert.ToDouble(TBHeight.Text.Replace(" ", ""))) - (4.7 * Convert.ToInt32(TBAge.Text.Replace(" ", "")));
            }
            ratio = GetRatio() * result;
            TBBMR.Text = result.ToString();
            TBTDEE.Text = ratio.ToString();
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
            int max = 5;


            if (Regex.IsMatch(e.Text, @"[0-9,]") == false)
                e.Handled = true;

            if (textBox.Text.Length == 0 && e.Text == ",")
                e.Handled = true;

            if (e.Text == "," && textBox.Text.Contains(','))
                e.Handled = true;

            if (e.Text == "," && isMax == true)
            {
                textBox.MaxLength += 3;
                isMax = false;
            }
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
