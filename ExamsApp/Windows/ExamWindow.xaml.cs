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
using System.Windows.Shapes;

namespace ExamsApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для ExamWindow.xaml
    /// </summary>
    public partial class ExamWindow : Window
    {
        private Exam current_exam;
        private User current_user;
        private int numberQues = 1;
        private int numberRightAns = 0;
        public ExamWindow(Exam ex, User u)
        {
            InitializeComponent();
            current_exam = ex;
            current_user = u;
        }

        public void Update()
        {
            tbQues.Text = current_exam.Questions.ElementAt(numberQues - 1).Wording;
            rb1.Content = current_exam.Questions.ElementAt(numberQues - 1).Answer1;
            rb2.Content = current_exam.Questions.ElementAt(numberQues - 1).Answer2;
            rb3.Content = current_exam.Questions.ElementAt(numberQues - 1).Answer3;
            rb4.Content = current_exam.Questions.ElementAt(numberQues - 1).Answer4;

            if (rb3.Content == "") rb3.Visibility = Visibility.Hidden;
            if (rb4.Content == "") rb4.Visibility = Visibility.Hidden;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if(current_exam.Questions.Count == 0)
            {
                MessageBox.Show("Вопросов нет");
                return;
            }
            if (current_exam.Questions.Count == 1)
            {
                
                netxQues.Content = "Завершить экзамен";
            }
            Update();
            stQues.Visibility = Visibility.Visible;
            buttonStart.Visibility = Visibility.Collapsed;
            
        }

        private void netxQues_Click(object sender, RoutedEventArgs e)
        {
            int rightAns = current_exam.Questions.ElementAt(numberQues - 1).RightAnswer;
            if ((bool)rb1.IsChecked && rightAns == 1) { numberRightAns++; }
            if ((bool)rb2.IsChecked && rightAns == 2) { numberRightAns++; }
            if ((bool)rb3.IsChecked && rightAns == 3) { numberRightAns++; }
            if ((bool)rb4.IsChecked && rightAns == 4) { numberRightAns++; }
            numberQues++;
            if (numberQues > current_exam.Questions.Count)
            {
                
                ExamDBEntities.GetContext().Reports.Add(new Report { Result = numberRightAns, IdUser = current_user.Id, User = current_user, IdExam = current_exam.Id, Exam = current_exam }) ;
                ExamDBEntities.GetContext().SaveChanges();
                MessageBox.Show($"Количество правильных ответов - {numberRightAns}");
                this.Close();
            }
            else if(numberQues == current_exam.Questions.Count)
            {
                netxQues.Content = "Завершить экзамен";
            }
            else
            {
                Update();
            }
        }
    }
}
