using System;
using System.Windows.Input;
using ReporteFacturasXmlSAT.ViewModels;

namespace ReporteFacturasXmlSAT.Commands
{
    public class ProcessarCommand : ICommand
    {
        private MainWindowModel _model;

        public ProcessarCommand(MainWindowModel _obj) 
        {
            _model = _obj;
        }
        public bool CanExecute(object parameter)
        {
            return _model.PuedeProcesar; 
        }
        public void Execute(object parameter)
        {
            _model.Procesar(); 
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            EventHandler eCanExecuteChanged = CanExecuteChanged;
            if (eCanExecuteChanged != null)
                eCanExecuteChanged(this, EventArgs.Empty);
        }
    }
}