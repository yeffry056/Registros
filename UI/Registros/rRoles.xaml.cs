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

namespace Registros.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles roles = new Roles();
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = roles;
        }
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (TextRolID.Text.Length == 0 || Convert.ToInt32(TextRolID.Text) == 0)
            {
               
                MessageBox.Show("RolID vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var roles = RolesBLL.Buscar(Convert.ToInt32(TextRolID.Text));
            if (roles != null)
                this.roles = roles;
            else
            {
                Limpiar();
                MessageBox.Show("No existe el rol que intenta buscar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
                

            this.DataContext = this.roles;
        }
        private void Limpiar()
        {
            this.roles = new Roles();
            this.DataContext = roles;
            FechaCreacionDatePicker.SelectedDate = DateTime.Now;
        }
        private bool Validar()
        {
            bool esValido = true;
            if(TextRolID.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TextDescripcion.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = RolesBLL.Guardar(roles);

            if (paso)
            {
                //MessageBox.Show(roles.Descripcion);
                Limpiar();
                MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
           // else
           //     MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        private void BtnEliminar(object sender, RoutedEventArgs e)
        {
            if (TextRolID.Text.Length != 0)
            {

                if (!RolesBLL.Existe(Convert.ToInt32(TextRolID.Text)))
                {
                    MessageBox.Show("El registro no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("RolID vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
               

            if (TextRolID.Text.Length == 0 || TextDescripcion.Text.Length ==0)
            {
                MessageBox.Show("Para eliminar un registro primero debe buscarlo", "Exito", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (RolesBLL.Eliminar(Convert.ToInt32(TextRolID.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void TextDescripc(object sender, TextChangedEventArgs e)
        {
            TextDescripcion.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextDescripcion.Text);
            TextDescripcion.SelectionStart = TextDescripcion.Text.Length;
        }
    }
}
