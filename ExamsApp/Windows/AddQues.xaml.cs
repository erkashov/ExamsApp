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
    /// Логика взаимодействия для AddQues.xaml
    /// </summary>
    public partial class AddQues : Window
    {
        CreateExam crEx;
        public AddQues(CreateExam createExam)
        {
            InitializeComponent();
            crEx = createExam;
        }

        private void addQues_Click(object sender, RoutedEventArgs e)
        {
            if(tbQues.Text=="" || tbAns1.Text=="" || tbAns2.Text == "" || tbRight.Text=="")
            {
                MessageBox.Show("Заполните все обязательные поля");
                return;
            }
            if(tbAns3.Text==""&&tbRight.Text=="3" || tbAns4.Text == "" && tbRight.Text == "4")
            {
                MessageBox.Show("Проверьте данные о правильном ответе");
            }
            ExamDBEntities.GetContext().Questions.Add(new Question() { 
                Wording = tbQues.Text, Answer1 = tbAns1.Text, Answer2 = tbAns2.Text, Answer3 = tbAns3.Text, Answer4 = tbAns4.Text, 
                RightAnswer=int.Parse(tbRight.Text), IdExam=crEx.cur_ex.Id, Exam=crEx.cur_ex });
            ExamDBEntities.GetContext().SaveChanges();
            crEx.Update();
            this.Close();
        }
    }
}
