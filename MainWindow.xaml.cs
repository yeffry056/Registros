using Registros.BLL;
using Registros.Entidades;
using Registros.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registros
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Usuarios usuarios = new Usuarios();
        
       
        public MainWindow()
        {
            InitializeComponent();
           
        }
        
        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = UsuariosBLL.Validar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

            if (paso)
            {
                
                rMenu m = new rMenu();
                m.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Error Nombre Usuario o Contraseña incorrecta!", "Error!");
                ContrasenaPasswordBox.Clear();
                NombreUsuarioTextBox.Focus();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            
            Application.Current.Shutdown();
        }
    }
}
