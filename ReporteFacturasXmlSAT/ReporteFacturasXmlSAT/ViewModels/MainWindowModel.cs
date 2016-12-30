using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ReporteFacturasXmlSAT.Commands;
using ReporteFacturasXmlSAT.Xml;

namespace ReporteFacturasXmlSAT.ViewModels
{
    public class MainWindowModel: INotifyPropertyChanged
    {
        private bool _procesando;
        private bool _esValido;
        private bool _isLogsChanged;

        private string _pathDirectorio;
        private string _bitacora;

        private ProcessarCommand _processarCommand;
        private SeleccionarDirectorioCommand _seleccionarCommand;

        public MainWindowModel()
        {
            _processarCommand = new ProcessarCommand(this);
            _seleccionarCommand = new SeleccionarDirectorioCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public bool EsValido
        {
            get { return _esValido; }
            private set
            {
                _esValido = value;
                OnPropertyChanged("EsValido");
            }
        }

        public bool IsLogsChanged
        {
            get { return _isLogsChanged; }
            private set
            {
                _isLogsChanged = value;
                OnPropertyChanged("IsLogsChanged");
            }
        }

        public bool PuedeSeleccionar
        {
            get { return !_procesando; }
        }

        public bool PuedeProcesar
        {
            get { return EsValido && !Procesando; }
        }

        public bool Procesando
        {
            get { return _procesando; }
            private set
            {
                _procesando = value;
                OnPropertyChanged("Procesando");
            }
        }
        
        public string PathDirectorio
        {
            get { return _pathDirectorio; }
            set
            {
                _pathDirectorio = value;
                OnPropertyChanged("PathDirectorio");
            }
        }

        public string Bitacora
        {
            get { return _bitacora; }
            set
            {
                _bitacora = value;
                OnPropertyChanged("Bitacora");
            }
        }

        public void SeleccionarDirectorio()
        {
            var folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            var result = folderDialog.ShowDialog();

            string path = null;
            bool esValido = false;

            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = folderDialog.SelectedPath;
                    path = file;
                    esValido = true;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    path = null;
                    esValido = false;
                    break;
            }

            PathDirectorio = path;
            EsValido = esValido;
            OnPropertyChanged("PuedeSeleccionar");
            OnPropertyChanged("PuedeProcesar");

            _processarCommand.RaiseCanExecuteChanged();
        }

        public void Procesar()
        {
            if (Procesando)
            {
                return;
            }

            Procesando = true;
            OnPropertyChanged("PuedeSeleccionar");
            OnPropertyChanged("PuedeProcesar");

            Task.Factory.StartNew(() =>
            {
                try
                {
                    LogInUI("Iniciando procesamiento");

                    new DirectoryProcessor().ProcessDirectory(PathDirectorio, LogInUI);

                    LogInUI("Terminado.");
                }
                catch (Exception e)
                {
                    LogInUI("Ocurrio un error");
                    LogInUI(e.StackTrace);
                }

                Application.Current.Dispatcher.Invoke((() =>
                {
                    Procesando = false;
                    OnPropertyChanged("PuedeSeleccionar");
                    OnPropertyChanged("PuedeProcesar");
                }));
            });
        }

        private void Log(string msg)
        {
            Bitacora += msg + Environment.NewLine;

            IsLogsChanged = true;
        }

        private void LogInUI(string msg)
        {
            Application.Current.Dispatcher.Invoke((() =>
            {
                Log(msg);
            }));
        }

        public ICommand SeleccionarCommand
        {
            get
            {
                return _seleccionarCommand;
            }
        }

        public ICommand ProcesarCommand
        {
            get
            {
                return _processarCommand;
            }
        }
    }
}