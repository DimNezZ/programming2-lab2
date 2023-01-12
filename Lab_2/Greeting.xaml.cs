using System;
using System.Windows;
using System.Windows.Input;
using Lab_2.Models;

namespace Lab_2
{
    /// <summary>
    /// Логика взаимодействия для Greeting.xaml
    /// </summary>
    public partial class Greeting : Window
    {
        private Questions questions = Questions.GetInstance();
       
        public Greeting()
        {
            InitializeComponent();

            CountAnswerTooltip.Text = $"Введите значение от 9 до {questions.GetCount()}";
        }

        private void Greeting_KeyUp(object sender, KeyEventArgs e)
        {
            if (CountAnswerTextBox.Text != "")
            {
                ButtonForward.IsEnabled = true;
            }
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            int count = Int32.Parse(CountAnswerTextBox.Text);
            if (count < 9 || count > questions.GetCount())
            {
                MessageBox.Show($"Введите значение от 9 до {questions.GetCount()}.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else 
            {
                Hide();
                
                Test mainWindow = new Test(count);
                mainWindow.Show();
            }
        }
    }
}
