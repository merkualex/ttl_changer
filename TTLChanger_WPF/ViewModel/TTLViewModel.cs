using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using TTLChanger_WPF.Commands;
using System.Windows.Input;
using System.Windows;

namespace TTLChanger_WPF.ViewModel
{
    class TTLViewModel : BaseViewModel
    {
        private string _currentTTL;

        public string CurrentTTL
        {
            get { return _currentTTL; }
            set
            {
                _currentTTL = value;
                OnPropertyChanged("CurrentTTL");
            }
        }

        private string _notification;

        public string Notification
        {
            get { return _notification; }
            set
            {
                _notification = value;
                OnPropertyChanged("Notification");
            }
        }

        public int NewTTL { get; set; }

        private RelayCommand _setValue;
        public ICommand SetValue
        {
            get
            {
                if (_setValue == null)
                {
                    _setValue = new RelayCommand(o => SetTTLValue());
                }
                return _setValue;
            }
        }

        private RelayCommand _deleteValue;
        public ICommand DeleteValue
        {
            get
            {
                if (_deleteValue == null)
                {
                    _deleteValue = new RelayCommand(o => DeleteTTLValue());
                }
                return _deleteValue;
            }
        }

        private RelayCommand _shutdown;

        public RelayCommand Shutdown
        {
            get
            {
                if (_shutdown == null)
                {
                    _shutdown = new RelayCommand(o => System.Windows.Application.Current.Shutdown());
                }
                return _shutdown;
            }
        }

        public TTLViewModel()
        {
            CurrentTTL = RegisterCommands.ReadRegistryKey();
        }

        private void SetTTLValue()
        {
            RegisterCommands.CreateTTLKey(NewTTL);
            CurrentTTL = RegisterCommands.ReadRegistryKey();

        }
        private void DeleteTTLValue()
        {
            Notification = RegisterCommands.DeleteTTLKey();
            CurrentTTL = RegisterCommands.ReadRegistryKey();
        }

    }
}
