using Registros.BLL;
using Registros.Entidades;
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

namespace Registros.UI.Consultas
{
    /// <summary>
    /// Interaction logic for rConsulta.xaml
    /// </summary>
    public partial class rConsulta : Window
    {
        public rConsulta()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //UsuarioId
                        listado = UsuariosBLL.GetList(e => e.UsuarioId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1: //Nombre                      
                        listado = UsuariosBLL.GetList(e => e.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = UsuariosBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = UsuariosBLL.GetList(c => c.FechaIngreso.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = UsuariosBLL.GetList(c => c.FechaIngreso.Date <= HastaDatePicker.SelectedDate);

           // listado = UsuariosBLL.GetList();
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
