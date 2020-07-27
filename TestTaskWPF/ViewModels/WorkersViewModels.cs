using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TestTaskWPF.Common;
using TestTaskWPF.Models;
using TestTaskWPF.Views;

namespace TestTaskWPF.ViewModels
{
    /// <summary>
    /// Основная ViewModel для окна MainWindow
    /// </summary>
    public class WorkersViewModels : INotifyPropertyChanged
    {

        public WorkersViewModels()
        {
            //Инициализация трёх объектов коллекции
            Workers = new ObservableCollection<Worker>()
            {
                new Worker("Andrew","Manager","Working",new DateTime(1970,09,10)),
                new Worker("Vasiliy","HR","Not Working",new DateTime(1980,10,08)),
                new Worker("Dimitry","Manager","Working",new DateTime(1995,01,10))

            };
            //Инициализация свойств фильтров
            NameFilter = "";
            PositionFilter = "";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private string nameFilter;
        public string NameFilter
        {
            get { return nameFilter ?? ""; }
            set
            {
                nameFilter = value;
                OnPropertyChanged("NameFilter");
            }
        }

        private string positionFilter;
        public string PositionFilter
        {
            get { return positionFilter; }
            set
            {
                positionFilter = value;
                OnPropertyChanged("PositionFilter");
            }
        }

        private Worker selectedWorker;
        public Worker SelectedWorker
        {
            get { return selectedWorker; }
            set
            {
                selectedWorker = value;
                OnPropertyChanged("SelectedWorker");
            }
        }
        public ObservableCollection<Worker> Workers { get; set; }

        public ICollectionView WorkersCollection
        {
            get { return CollectionViewSource.GetDefaultView(Workers); }
            set
            {
                WorkersCollection = value;
                OnPropertyChanged("WorkersCollection");
            }
        }

        #region Commands

        private RelayCommand openChangeWorkDialog;
        public RelayCommand OpenChangeWorkDialog
        {
            get
            {
                return openChangeWorkDialog ??
                  (openChangeWorkDialog = new RelayCommand(obj =>
                  {
                      if (SelectedWorker != null)
                      {
                          if (SelectedWorker.Status.Equals("Working"))
                              SelectedWorker.Status = "Not Working";
                          else
                              SelectedWorker.Status = "Working";
                          WorkersCollection.Refresh();
                      }
                      else
                      {
                          MessageBox.Show("Choose worker, please.");
                      }

                  }
                  ));
            }
        }
        /// <summary>
        /// Команда открытия диалога добавления работника
        /// </summary>
        private RelayCommand openAddWorkerDialog;
        public RelayCommand OpenAddWorkerDialog
        {
            get
            {
                return openAddWorkerDialog ??
                  (openAddWorkerDialog = new RelayCommand(obj =>
                  {
                      AddWorkerDialog AddWorkerDialogView = new AddWorkerDialog();
                      AddWorkerDialogView.Closing += delegate
                      {

                          var Model = (AddWorkerDialogViewModel)AddWorkerDialogView.DataContext;
                          //Если на предыдущем меню выбрано "сохранить"
                          if (Model.Success)
                          {
                              //Создание нового работника на основе данных с модели
                              var NewWorker = new Worker()
                              {
                                  Name = Model.Name,
                                  Birthday = DateTime.Parse(Model.Birthday),
                                  Position = Model.Position,
                                  Status = "Newbie"
                              };
                              Workers.Add(NewWorker);

                          }
                      };
                      AddWorkerDialogView.ShowDialog();
                  }
                  ));
            }
        }
        //Удалить из коллекции объект и потенциально с БД
        private RelayCommand removeWorker;
        public RelayCommand RemoveWorker
        {
            get
            {
                return removeWorker ??
                 (removeWorker = new RelayCommand(obj =>
                 {
                     if (SelectedWorker != null)
                     {
                         if (MessageBox.Show("Are you sure you want to remove the worker?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                         {

                             Workers.Remove(SelectedWorker);
                         }
                     }
                     else
                     {
                         MessageBox.Show("Choose worker!");
                     }
                 }
                 ));
            }
        }



        private RelayCommand applyWorkerFilters;
        /// <summary>
        /// Применение фильтров для отображения только введенных данных
        /// </summary>
        public RelayCommand ApplyWorkerFilters
        {
            get
            {
                return applyWorkerFilters ??
                    (applyWorkerFilters = new RelayCommand(obj =>
                    {

                        WorkersCollection.Filter = new Predicate<object>(o =>
                      (NameFilter == "" || ((Worker)o).Name.ToLower().Contains(NameFilter.ToLower())) &&
                           (PositionFilter == "" || (((Worker)o).Position == null || ((Worker)o).Position.Contains(PositionFilter))));
                        WorkersCollection.Refresh();
                    }
                    ));
            }
        }

        private RelayCommand removeWorkerFilters;
        /// <summary>
        /// Сброс фильтров
        /// </summary>
        public RelayCommand RemoveWorkerFilters
        {
            get
            {
                return removeWorkerFilters ??
                  (removeWorkerFilters = new RelayCommand(obj =>
                  {
                      WorkersCollection.Filter = null;

                      NameFilter = "";
                      PositionFilter = "";
                      WorkersCollection.Refresh();
                  }
                      ));
            }
        }

    }

    #endregion

}
