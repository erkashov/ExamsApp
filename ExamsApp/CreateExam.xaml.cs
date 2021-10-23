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
        private Exam cur_ex;
        public CreateExam(Exam ex)
        {
            InitializeComponent();
            cur_ex = ex;
            if(ex!=null)lbQues.ItemsSource = ExamDBEntities.GetContext().Exams.Find(cur_ex.Id).Questions.ToList();
        }

        private void addQues_Click(object sender, RoutedEventArgs e)
        {

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
