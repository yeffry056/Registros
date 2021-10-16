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
        private void Limpiar()
        {
            this.roles = new Roles();
            this.DataContext = roles;
            FechaCreacionDatePicker.SelectedDate = DateTime.Now;
            CheckBoxAsignado.IsChecked = false;

        }
        private bool Validar()
        {
            bool esValido = true;
            if (TextRolID.Text.Length == 0)
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
        private void Cargar()
        {
            this.DataContext = null;
            CheckBoxAsignado.IsChecked = false;
            this.DataContext = roles;
        }
        private bool ValidarBusqueda()
        {
            bool esValido = true;
            if (TextRolID.Text.Length == 0 || Convert.ToInt32(TextRolID.Text) == 0)
            {
                esValido = false;
                MessageBox.Show("RolID vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }
            return esValido;
        }
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (!ValidarBusqueda())
                return;

            var roles = RolesBLL.Buscar(Convert.ToInt32(TextRolID.Text));
            if (roles != null) { 
                this.roles = roles;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe el rol que intenta buscar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
                

            //this.DataContext = this.roles;
        }
        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (!Validar())
                return;
    
            paso = RolesBLL.Guardar(roles);

            if (paso)
            {
                
                Limpiar();
                MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            else
              MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

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
        private void BtnRemover(object sender, RoutedEventArgs e)
        {
            if(DataGridDetalle.Items.Count >= 1 && DataGridDetalle.SelectedIndex <= DataGridDetalle.Items.Count - 1)
            {
                roles.Detalle.RemoveAt(DataGridDetalle.SelectedIndex);
                Cargar();
            }
        }
        private void BtnAgregar(object sender, RoutedEventArgs e)
        {
            string asignar;
            if (CheckBoxAsignado.IsChecked.Value)
            {
                 asignar = "Si";
            } else
                asignar = "No";

            roles.Detalle.Add(new RolesDetalles(roles.RolId, Convert.ToInt32(TextPermidoId.Text), 
               asignar, TextDescripcion.Text));
            
            Cargar();
            
            TextPermidoId.Focus();
            TextPermidoId.Clear();
            TextPermidoId.Focus();
        }
        
    }
}
