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
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private User currrent_user;
        public StudentWindow(User u)
        {
            InitializeComponent();
            currrent_user = u;
            Update();
        }

        public void Update()
        {
            lbExams.ItemsSource = ExamDBEntities.GetContext().Exams.ToList();
            if (lbExams.Items.Count == 0)
            {
                lbExams.Visibility = Visibility.Collapsed;
                tbNot.Visibility = Visibility.Visible;
            }
        }

        private void lbExams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbExams.SelectedItem == null) return;
            var ex = ExamDBEntities.GetContext().Exams.Find(((Exam)lbExams.SelectedItem).Id);
            if (ex.IsStarted)
            {
                if (ExamDBEntities.GetContext().Reports.Where(p => p.IdUser == currrent_user.Id && p.IdExam == ex.Id).FirstOrDefault() != null)
                {
                    MessageBox.Show("Вы уже прошли данный экзамен");
                }
                else
                {
                    ExamWindow w = new ExamWindow(ex, currrent_user);
                    w.Show();
                }
                
            }
            else
            {
                MessageBox.Show("Экзамен еще не начался");
            }
                lbExams.SelectedIndex = -1;
            
        }

        private void buttonReport_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow r = new ReportsWindow(currrent_user);
            r.Show();
        }
    }
}
