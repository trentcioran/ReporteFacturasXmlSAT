using System;
using System.Windows.Input;
using ReporteFacturasXmlSAT.ViewModels;

namespace ReporteFacturasXmlSAT.Commands
{
    public class SeleccionarDirectorioCommand : ICommand
    {
        private MainWindowModel _model;

        public SeleccionarDirectorioCommand(MainWindowModel _obj) 
        {
            _model = _obj;
        }
        public bool CanExecute(object parameter)
        {
            return _model.PuedeSeleccionar; 
        }
        public void Execute(object parameter)
        {
            _model.SeleccionarDirectorio(); 
        }

        public event EventHandler CanExecuteChanged;
    }
}