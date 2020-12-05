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
using BLL;
using MahApps.Metro.Controls;
using Oracle.ManagedDataAccess.Client;

namespace Restaurantexxi
{
	/// <summary>
	/// Lógica de interacción para MenuClienteNuevo.xaml
	/// </summary>
	public partial class MenuClienteNuevo : Window
	{
		public MenuClienteNuevo()
		{
			InitializeComponent();


            loadGarzones();
        }

		private void btn_cancelar_Click(object sender, RoutedEventArgs e)
		{
            Close();
		}

        private void Win_load_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void loadGarzones()
        {
            MesaBLL mesabll = new MesaBLL();
            dtgMesas.ItemsSource = mesabll.getmesasvacias().DefaultView;
            cbox_cantidad.ItemsSource = mesabll.getmesasvacias().DefaultView;
            cbox_cantidad.DisplayMemberPath = "ID_MESA";
            cbox_cantidad.SelectedValuePath = "ID_MESA";

            usuarioBLL usrBLL = new usuarioBLL();
            cbGarzon.ItemsSource = usrBLL.getGarzones().DefaultView;
            cbGarzon.DisplayMemberPath = "Nombre";
            cbGarzon.SelectedValuePath = "ID_USER";
        }

        private void Btn_ingresar_Click(object sender, RoutedEventArgs e)
        {
            if (rbClienteNuevo.IsChecked == true)
            {
                if (MessageBox.Show("Ingresar Cliente " + txt_nombre.Text + " " + "a mesa " + cbox_cantidad.SelectedValue + "?", "Seguro?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    usuarioBLL usrBLL = new usuarioBLL();
                    int rut = int.Parse(txt_rut.Text);
                    string nombre = txt_nombre.Text;
                    string apellido = txt_apellido.Text;
                    string email = txt_email.Text;
                    bool status = usrBLL.CreateCliente(rut, nombre, apellido, email);
                    if (status)
                    {
                        BoletaBLL bolBLL = new BoletaBLL();

                        int id_mesa = int.Parse(cbox_cantidad.SelectedValue.ToString());
                        int id_garzon = int.Parse(cbGarzon.SelectedValue.ToString());
                        if (bolBLL.insertBoleta(id_mesa, id_garzon, rut))
                        {
                            MessageBox.Show("Asignacion Ingresada Correctamente");
                        }
                        else
                        {
                            MessageBox.Show("El Cliente Fue ingresado, Pero ocurrio un error al ingresar la asignacion de mesa");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al ingresar el cliente");
                    }
                }
                loadGarzones();
            }
            else if (rbClienteRegistrado.IsChecked == true)
            {
                BoletaBLL bolBLL = new BoletaBLL();
                int id_mesa = int.Parse(cbox_cantidad.SelectedValue.ToString());
                int id_garzon = int.Parse(cbGarzon.SelectedValue.ToString());
                int rut = int.Parse(txt_rut.Text);
                if (bolBLL.insertBoleta(id_mesa, id_garzon, rut))
                {
                    MessageBox.Show("Asignacion Ingresada Correctamente");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al ingresar la asignacion de mesa");
                }
            }
        }

        private void RbClienteRegistrado_Checked(object sender, RoutedEventArgs e)
        {
            lbl_email.Visibility = Visibility.Hidden;
            txt_email.Visibility = Visibility.Hidden;
            lbl_apellido.Visibility = Visibility.Hidden;
            txt_apellido.Visibility = Visibility.Hidden;
            txt_nombre.IsEnabled = false;
        }

        private void RbClienteNuevo_Checked(object sender, RoutedEventArgs e)
        {
            lbl_email.Visibility = Visibility.Visible;
            txt_email.Visibility = Visibility.Visible;
            lbl_apellido.Visibility = Visibility.Visible;
            txt_apellido.Visibility = Visibility.Visible;
            txt_nombre.IsEnabled = true;
        }

        private void Txt_rut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_rut.Text.Length;

            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 48 && ascii <= 57)
            {
                if (tamanio < 9)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_nombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_rut.Text.Length;

            if (tamanio < 24)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void Txt_apellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_rut.Text.Length;

            if (tamanio < 24)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txt_rut.Text.Length;

            if (tamanio < 49)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
