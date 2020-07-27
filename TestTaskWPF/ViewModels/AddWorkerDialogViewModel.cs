using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestTaskWPF.Common;

namespace TestTaskWPF.ViewModels
{
    /// <summary>
    /// Основная модель представления для формы добавления работника
    /// </summary>
    public class AddWorkerDialogViewModel : INotifyPropertyChanged
    {
        public AddWorkerDialogViewModel()
        {
            //Инициализация переменной для отображения вводного формата
            Birthday = "10.09.1989";
        }
        /// <summary>
        /// Успех операции
        /// </summary>
        public bool Success;

        private string name;
        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
       
        private string position;
        /// <summary>
        /// Позиция
        /// </summary>
        public string Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        private string birthday;
        /// <summary>
        /// Дата рождения
        /// </summary>
        public string Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged("Brithday");
            }
        }
        public Action CloseDialog { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private RelayCommand addWorker;
        /// <summary>
        /// Команда на закрытие формы. Может быть использовано для сохранения информации в БД
        /// </summary>
        public RelayCommand AddWorker
        {
            get
            {
                return addWorker ??
                  (addWorker = new RelayCommand(obj =>
                  {
                      Success = true;
                      CloseDialog();
                  }
                  ));
            }
        }
    }
}
