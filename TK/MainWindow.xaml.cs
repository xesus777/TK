using System;
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

namespace TK
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

        /// <summary>
        /// Событие при выборе любого переключателя (прямоугольник, круг, треугольник)
        /// </summary>
        private void FigureRadio_Checked(object sender, RoutedEventArgs e)
        {
            // Сбрасываем результат
            ResultTextBlock.Text = "—";

            

            // Очищаем все поля
            Side1TextBox.Text = "";
            Side2TextBox.Text = "";
            Side3TextBox.Text = "";
            RadiusTextBox.Text = "";

            // Включаем кнопку вычисления (переключатель выбран)
            CalculateButton.IsEnabled = true;

            // Включаем нужные поля в зависимости от выбранной фигуры
            if (RectangleRadio.IsChecked == true)      // Выбран прямоугольник
            {
                Side1TextBox.Visibility = Visibility.Visible;   // нужна сторона 1
                first.Visibility = Visibility.Visible;
                Side2TextBox.Visibility = Visibility.Visible;   // нужна сторона 2
                second.Visibility = Visibility.Visible;
                Side3TextBox.Visibility = Visibility.Hidden;
                thirty.Visibility = Visibility.Hidden;
                RadiusTextBox.Visibility = Visibility.Hidden;
                forty.Visibility = Visibility.Hidden;
            }
            else if (CircleRadio.IsChecked == true)    // Выбран круг
            {
                RadiusTextBox.Visibility = Visibility.Visible;  // нужен только радиус
                forty.Visibility = Visibility.Visible;
                Side1TextBox.Visibility = Visibility.Hidden;
                first.Visibility = Visibility.Hidden;
                Side2TextBox.Visibility = Visibility.Hidden;
                second.Visibility = Visibility.Hidden;
                Side3TextBox.Visibility = Visibility.Hidden;
                thirty.Visibility = Visibility.Hidden;
            }
            else if (TriangleRadio.IsChecked == true)  // Выбран треугольник
            {
                Side1TextBox.Visibility = Visibility.Visible;   // нужна сторона 1
                Side2TextBox.Visibility = Visibility.Visible;   // нужна сторона 2
                Side3TextBox.Visibility = Visibility.Visible;   // нужна сторона 3
                RadiusTextBox.Visibility = Visibility.Hidden;

                first.Visibility = Visibility.Visible;
                second.Visibility = Visibility.Visible;
                thirty.Visibility = Visibility.Visible;
                forty.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Обработчик кнопки "Вычислить" - рассчитывает периметр или длину окружности
        /// </summary>
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = 0;

                // Определяем, какая фигура выбрана, и вычисляем соответствующий периметр
                if (RectangleRadio.IsChecked == true)      // Прямоугольник: P = 2 * (a + b)
                {
                    double side1 = GetDoubleFromTextBox(Side1TextBox, "сторону 1");
                    double side2 = GetDoubleFromTextBox(Side2TextBox, "сторону 2");
                    result = 2 * (side1 + side2);
                }
                else if (CircleRadio.IsChecked == true)    // Круг (длина окружности): C = 2 * π * r
                {
                    double radius = GetDoubleFromTextBox(RadiusTextBox, "радиус");
                    result = 2 * Math.PI * radius;
                }
                else if (TriangleRadio.IsChecked == true)  // Треугольник: P = a + b + c
                {
                    double tSide1 = GetDoubleFromTextBox(Side1TextBox, "сторону 1");
                    double tSide2 = GetDoubleFromTextBox(Side2TextBox, "сторону 2");
                    double tSide3 = GetDoubleFromTextBox(Side3TextBox, "сторону 3");
                    result = tSide1 + tSide2 + tSide3;
                }
                else
                {
                    // Если ни один переключатель не выбран (по идее не должно случиться, т.к. кнопка неактивна)
                    MessageBox.Show("Выберите фигуру", "Предупреждение",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Отображаем результат с округлением до 2 знаков
                ResultTextBlock.Text = result.ToString("0.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Вспомогательный метод для получения числа из TextBox с проверкой корректности
        /// </summary>
        /// <param name="textBox">Поле ввода</param>
        /// <param name="fieldName">Название поля для сообщения об ошибке</param>
        /// <returns>Число типа double</returns>
        private double GetDoubleFromTextBox(TextBox textBox, string fieldName)
        {
            // Проверка на пустое поле
            if (string.IsNullOrWhiteSpace(textBox.Text))
                throw new Exception($"Введите {fieldName}");

            // Проверка на корректность числа (поддерживает точку и запятую)
            if (!double.TryParse(textBox.Text, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double value))
                throw new Exception($"Некорректное значение для {fieldName}");

            // Проверка, что число больше нуля
            if (value <= 0)
                throw new Exception($"{fieldName} должно быть больше нуля");

            return value;
        }
    }

}
