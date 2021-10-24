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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private User cur_user;
        public AdminWindow(User u)
        {
            InitializeComponent();
            cur_user = u;
            Update();
        }
        /// <summary>
        /// Обновление списка экзаменов
        /// </summary>
        public void Update()
        {
            lbExams.ItemsSource = ExamDBEntities.GetContext().Exams.Where(p => p.IdUser == cur_user.Id).ToList();
        }

        private void createExam_Click(object sender, RoutedEventArgs e)
        {
            Exam ex = new Exam() { IdUser = cur_user.Id, IsStarted = false };
            CreateExam a = new CreateExam(ex);
            a.ShowDialog();
        }

        private void lbExams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbExams.SelectedItem != null)
            {
                CreateExam a = new CreateExam((Exam)lbExams.SelectedItem);
                a.Show();
            }
            
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            lbExams.ItemsSource = ExamDBEntities.GetContext().Exams.Where(p => p.IdUser == cur_user.Id).ToList<Exam>();
        }

        private void lbExams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (lbExams.SelectedItem != null)
                {
                    if (MessageBox.Show("Вы точно хотите удалить выбранный вопрос?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        ExamDBEntities.GetContext().Exams.Remove(ExamDBEntities.GetContext().Exams.Find(((Exam)lbExams.SelectedItem).Id));
                        ExamDBEntities.GetContext().SaveChanges();
                        Update();
                    }
                }
            }
        }
    }

}
