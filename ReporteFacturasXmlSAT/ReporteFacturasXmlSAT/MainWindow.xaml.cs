using System.Windows;
using ReporteFacturasXmlSAT.ViewModels;

namespace ReporteFacturasXmlSAT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowModel _model;

        public MainWindow()
        {
            _model = new MainWindowModel();

            InitializeComponent();

            DataContext = _model;
        }

        private void ProcesarBtn_Click(object sender, RoutedEventArgs e)
        {
            _model.Procesar();
        }

        private void SeleccionarBtn_Click(object sender, RoutedEventArgs e)
        {
            _model.SeleccionarDirectorio();
        }
    }
}
