using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Lab_2.Models;

namespace Lab_2
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        private Questions questions = Questions.GetInstance();
        private List<QuestionWithAnswers> availableQuestions = new List<QuestionWithAnswers>();
        private Answers rightAnswers = new Answers(); 
        private Answers userAnswers = new Answers();

        public Test(int questionsCount)
        {
            InitializeComponent();

            availableQuestions = questions.ShuffleOrder().GetQuestions(questionsCount);
            for (int i = 0; i < availableQuestions.Count; i++)
            {
                rightAnswers.SaveAnswer(i, availableQuestions[i].AnswerNumber);
            }

            UpdateQuestionsList();
        }

        public void UpdateQuestionsList()
        {
            List<PickedQuestion> items = new List<PickedQuestion>();
            for (int i = 0; i < availableQuestions.Count; i++)
            {
                items.Add(new PickedQuestion() { Name = $"Вопрос {i + 1}", IsCorrect = 0 });
            }

            QuestionsList.ItemsSource = items;
            QuestionsList.SelectedIndex = 0;
        }

        private void Questions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuestionsList.SelectedIndex != -1)
            {
                var record = availableQuestions[QuestionsList.SelectedIndex];
                var answer = userAnswers.GetAnswer(QuestionsList.SelectedIndex);

                QuestionLabel.Content = record.Question;
                VariantARadio.Content = record.VariantA;
                VariantARadio.IsChecked = answer == 1;
                VariantBRadio.Content = record.VariantB;
                VariantBRadio.IsChecked = answer == 2;
                VariantCRadio.Content = record.VariantC;
                VariantCRadio.IsChecked = answer == 3;
                VariantDRadio.Content = record.VariantD;
                VariantDRadio.IsChecked = answer == 4;
            }
        }

        private void VariantA_Checked(object sender, RoutedEventArgs e)
        {
            userAnswers.SaveAnswer(QuestionsList.SelectedIndex, 1);
        }

        private void VariantB_Checked(object sender, RoutedEventArgs e)
        {
            userAnswers.SaveAnswer(QuestionsList.SelectedIndex, 2);
        }

        private void VariantC_Checked(object sender, RoutedEventArgs e)
        {
            userAnswers.SaveAnswer(QuestionsList.SelectedIndex, 3);
        }

        private void VariantD_Checked(object sender, RoutedEventArgs e)
        {
            userAnswers.SaveAnswer(QuestionsList.SelectedIndex, 4);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < QuestionsList.Items.Count; i++)
            {
                PickedQuestion item = (PickedQuestion) QuestionsList.Items[i];
                item.IsCorrect = rightAnswers.GetAnswer(i) == userAnswers.GetAnswer(i) ? 2 : 1;
            }
            QuestionsList.Items.Refresh();

            float currentAnswersCount = rightAnswers.GetMatchingPercentage(userAnswers);
            if (currentAnswersCount > 0.7)
            {
                MessageBox.Show($"Поздравляем, вы набрали {currentAnswersCount * 100:N2}%." + Environment.NewLine + "Тест пройден.", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"К сожалению, вы набрали лишь {currentAnswersCount * 100:N2}%." + Environment.NewLine + "Тест не пройден.", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            VariantARadio.IsEnabled = false;
            VariantBRadio.IsEnabled = false;
            VariantCRadio.IsEnabled = false;
            VariantDRadio.IsEnabled = false;
            SubmitButton.IsEnabled = false;
        }

        private void TestForm_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
