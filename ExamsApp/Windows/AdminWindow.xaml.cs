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
            lbExams.ItemsSource = ExamDBEntities.GetContext().Exams.Where(p => p.IdUser == cur_user.Id).ToList<Exam>();
        }

        private void createExam_Click(object sender, RoutedEventArgs e)
        {
            Exam ex = new Exam() { IdUser = cur_user.Id, IsStarted = false };
            CreateExam a = new CreateExam(ex);
            a.ShowDialog();
        }

        private void lbExams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateExam a = new CreateExam((Exam)lbExams.SelectedItem);
            a.ShowDialog();
        }
    }

}
