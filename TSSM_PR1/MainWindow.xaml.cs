using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Ввод значений x и b
                if (!double.TryParse(TextBoxX.Text, out double x))
                {
                    MessageBox.Show("Введите корректное значение для x.");
                    return;
                }

                if (!double.TryParse(TextBoxB.Text, out double b))
                {
                    MessageBox.Show("Введите корректное значение для b.");
                    return;
                }

                // Определение функции f(x)
                double fx;
                if (RadioButtonSinh.IsChecked == true)
                {
                    fx = Math.Sinh(x);
                }
                else if (RadioButtonSquare.IsChecked == true)
                {
                    fx = Math.Pow(x, 2);
                }
                else if (RadioButtonExp.IsChecked == true)
                {
                    fx = Math.Exp(x);
                }
                else
                {
                    MessageBox.Show("Выберите функцию f(x).");
                    return;
                }

                // Вычисление произведения xb
                double xb = x * b;

                // Вычисление кусочно-заданной функции s
                double s;
                if (1 < xb && xb < 10)
                {
                    s = Math.E * fx; // ef
                }
                else if (12 < xb && xb < 40)
                {
                    s = Math.Sqrt(fx + 4 * b); // sqrt(f(x) + 4 * b)
                }
                else
                {
                    s = b * Math.Pow(fx, 2); // b * f(x)^2
                }

                // Вывод результата
                TextBoxResult.Text = $"S = {s:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            // Очистка всех полей
            TextBoxX.Clear();
            TextBoxB.Clear();
            TextBoxResult.Clear();
            RadioButtonSinh.IsChecked = true; // Сброс выбора функции на sh(x)
        }
    }
}
