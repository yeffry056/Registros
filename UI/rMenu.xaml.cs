using Registros.UI.Consultas;
using Registros.UI.Registros;
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

namespace Registros.UI
{
    /// <summary>
    /// Interaction logic for rMenu.xaml
    /// </summary>
    public partial class rMenu : Window
    {
        public rMenu()
        {
            InitializeComponent();
        }

        private void RolesClik(object sender, RoutedEventArgs e)
        {
            rRoles roles = new rRoles();
            roles.Show();
        }

        private void RegistrosClik(object sender, RoutedEventArgs e)
        {
            rUsuarios usuario = new rUsuarios();
            usuario.Show();
        }

        private void ConsultaUsuario(object sender, RoutedEventArgs e)
        {
            rConsulta c = new rConsulta();
            c.Show();
        }
    }
}
