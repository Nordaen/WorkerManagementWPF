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
using TestTaskWPF.ViewModels;

namespace TestTaskWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerDialog.xaml
    /// </summary>
    public partial class AddWorkerDialog : Window
    {
        public AddWorkerDialog()
        {
            InitializeComponent();
            AddWorkerDialogViewModel vm = new AddWorkerDialogViewModel
            {
                CloseDialog = new Action(Close)
            };
            DataContext = vm;
        }
    }
}
