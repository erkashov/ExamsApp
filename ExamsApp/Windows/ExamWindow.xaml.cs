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
        public ExamWindow(Exam ex)
        {
            InitializeComponent();
            current_exam = ex;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
