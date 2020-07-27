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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestTaskWPF.ViewModels;

namespace TestTaskWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WorkersViewModels();
        }
        private DataGridRow CurrentRoleEditRow { get; set; }

        private void RolesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurrentRoleEditRow != null)
            {
                DataGrid dg = sender as DataGrid;
                _showCellsNormalTemplate(dg, CurrentRoleEditRow, false);
            }
        }
        /// <summary>
        /// Отображение изменяемых ячеек в нормальную форму.
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="row"></param>
        /// <param name="canCommit"></param>
        private void _showCellsNormalTemplate(DataGrid dg, DataGridRow row, bool canCommit = false)
        {

            bool update = true;
            foreach (DataGridColumn col in dg.Columns)
            {
                if (col.Visibility != Visibility.Hidden)
                {
                    DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                    while (parent.GetType().Name != "DataGridCell")
                        parent = VisualTreeHelper.GetParent(parent);

                    DataGridCell cell = ((DataGridCell)parent);
                    DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                    if (col.DisplayIndex != 0)
                    {
                        if (canCommit == true)
                        {
                            ((TextBox)cell.Content).GetBindingExpression(TextBox.TextProperty).UpdateSource();
                        }
                        else
                        {

                            dg.Items.Refresh();

                        }
                    }
                }
            }
            if (update)
            {
                foreach (DataGridColumn col in dg.Columns)
                {
                    if (col.Visibility != Visibility.Hidden)
                    {
                        DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                        while (parent.GetType().Name != "DataGridCell")
                            parent = VisualTreeHelper.GetParent(parent);

                        DataGridCell cell = ((DataGridCell)parent);
                        DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                        cell.Content = c.CellTemplate.LoadContent();

                    }
                }
            }
        }


        private DataGrid FindAncestorGrid(object sender, RoutedEventArgs e)
        {
            try
            {
                var source = e.Source as Button;
                DependencyObject parent = source;
                DataGrid CurrDg = new DataGrid();
                while (parent.GetType().Name != "DataGrid") parent = VisualTreeHelper.GetParent(parent);
                if (parent.GetType().Name == "DataGrid") CurrDg = parent as DataGrid;
                DataGridRow row = (DataGridRow)CurrDg.ItemContainerGenerator.ContainerFromItem(CurrDg.CurrentItem);
                return CurrDg;
            }
            catch { return null; }
        }
        private void EnableEditMode(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid CurrDg = new DataGrid();
                CurrDg = FindAncestorGrid(sender, e);
                DataGridRow row = (DataGridRow)CurrDg.ItemContainerGenerator.ContainerFromItem(CurrDg.CurrentItem);
                CurrentRoleEditRow = row;
                _showCellsEditingTemplate(CurrDg, row);

            }
            catch { }
        }

        /// <summary>
        /// Отображение изменяемых ячеек в форму для изменения.
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="row"></param>
        private void _showCellsEditingTemplate(DataGrid dg, DataGridRow row)
        {
            try
            {
                foreach (DataGridColumn col in dg.Columns)
                {
                    if (col.Visibility != Visibility.Hidden)
                    {
                        DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                        while (parent.GetType().Name != "DataGridCell")
                            parent = VisualTreeHelper.GetParent(parent);
                        DataGridCell cell = ((DataGridCell)parent);
                        DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                        if (c.CellEditingTemplate != null)
                            cell.Content = ((DataGridTemplateColumn)col).CellEditingTemplate.LoadContent();
                        cell.Focus();

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// Отмена режима редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelEditMode(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid CurrDg = new DataGrid();
                CurrDg = FindAncestorGrid(sender, e);
                DataGridRow row = (DataGridRow)CurrDg.ItemContainerGenerator.ContainerFromItem(CurrDg.CurrentItem);
                _showCellsNormalTemplate(CurrDg, row);

            }
            catch { }
        }
        /// <summary>
        /// Подтверждение изменений, потенциальная отправка в БД и возвращение к нормальному виду ячеек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommitEdit(object sender, RoutedEventArgs e)
        {
            try
            {

                DataGrid CurrDg = new DataGrid();
                CurrDg = FindAncestorGrid(sender, e);
                DataGridRow row = (DataGridRow)CurrDg.ItemContainerGenerator.ContainerFromItem(CurrDg.CurrentItem);
                _showCellsNormalTemplate(CurrDg, row, true);
            }
            catch (Exception exept)
            {
                MessageBox.Show(exept.Message);
            }
        }
    }
}
