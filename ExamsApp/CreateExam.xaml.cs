using ExamsApp.Windows;
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

namespace ExamsApp
{
    /// <summary>
    /// Логика взаимодействия для CreateExam.xaml
    /// </summary>
    public partial class CreateExam : Window
    {
        public Exam cur_ex;
        public bool IsAdded = false;
        public bool IsStarted = false;

        public CreateExam(Exam ex)
        {
            InitializeComponent();
            cur_ex = ex;
            if (ex.Name != null)
            {
                Update();
                start.Content = ExamDBEntities.GetContext().Exams.Find(cur_ex.Id).Started;
                start.Visibility = Visibility.Visible;
                tbName.Text = cur_ex.Name;
                IsAdded = true;
                IsStarted = ex.IsStarted;
            }
        }



        public void Update()
        {
            lbQues.ItemsSource = ExamDBEntities.GetContext().Exams.Find(cur_ex.Id).Questions.ToList();
            
        }

        private void addQues_Click(object sender, RoutedEventArgs e)
        {            
            if (tbName.Text == "") MessageBox.Show("Введите название");
            else
            {
                int a=0;
                if (!IsAdded)
                {
                    cur_ex.Name = tbName.Text;
                    cur_ex = ExamDBEntities.GetContext().Exams.Add(cur_ex);
                    ExamDBEntities.GetContext().SaveChanges();
                    IsAdded = true;
                    start.Visibility = Visibility.Visible;
                }
                if (tbQues.Text == "" || tbAns1.Text == "" || tbAns2.Text == "" || tbRight.Text == "")
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }
                if (tbAns3.Text == "" && tbRight.Text == "3" || tbAns4.Text == "" && tbRight.Text == "4" || !int.TryParse(tbRight.Text, out a))
                {
                    MessageBox.Show("Проверьте данные о правильном ответе");
                    return;
                }
                ExamDBEntities.GetContext().Questions.Add(new Question()
                {
                    Wording = tbQues.Text,
                    Answer1 = tbAns1.Text,
                    Answer2 = tbAns2.Text,
                    Answer3 = tbAns3.Text,
                    Answer4 = tbAns4.Text,
                    RightAnswer = int.Parse(tbRight.Text),
                    IdExam = cur_ex.Id,
                    Exam = cur_ex
                });
                ExamDBEntities.GetContext().SaveChanges();
                Update();
                tbQues.Text = "";
                tbAns1.Text = "";
                tbAns2.Text = "";
                tbAns3.Text = "";
                tbAns4.Text = "";
                tbRight.Text = "";
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            IsStarted = !IsStarted;
            ExamDBEntities.GetContext().Exams.Find(cur_ex.Id).IsStarted = IsStarted;
            ExamDBEntities.GetContext().SaveChanges();
            start.Content = ExamDBEntities.GetContext().Exams.Find(cur_ex.Id).Started;
        }

        private void createExam_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
