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

namespace Restaurantexxi
{
    /// <summary>
    /// Lógica de interacción para GestionReservas.xaml
    /// </summary>
    /// 
    public partial class GestionReservas : Window
    {
        bool clienteexiste = false;
        public GestionReservas()
        {
            InitializeComponent();
            rbNuevaReserva.IsChecked = true;
            lbApellido.Visibility = Visibility.Hidden;
            lbNom.Visibility = Visibility.Hidden;
            lbEmail.Visibility = Visibility.Hidden;
            txtApe.Visibility = Visibility.Hidden;
            txtNom.Visibility = Visibility.Hidden;
            txtEmail.Visibility = Visibility.Hidden;

            cbHora.SelectedIndex = 0;
            cbMinuto.SelectedIndex = 0;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            dtgReservas.Visibility = Visibility.Visible;
            lbIdReserva.Visibility = Visibility.Visible;
            txtIdReserva.Visibility = Visibility.Visible;
            btnBuscar.Visibility = Visibility.Visible;

            
            lbFecha.Visibility = Visibility.Hidden;
            lbHora.Visibility = Visibility.Hidden;
            cbHora.Visibility = Visibility.Hidden;
            cbMinuto.Visibility = Visibility.Hidden;
            dtpFecha.Visibility = Visibility.Hidden;
            dtpFecha.IsEnabled = false;
            cbHora.IsEnabled = false;
            cbMinuto.IsEnabled = false;
            lbIdReserva.Content = "ID Reserva:";
            btnAgregar.Content = "Eliminar Reserva";


            dtgReservas.ItemsSource = null;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rbNuevaReserva.IsChecked == true)
            {
                DateTime? fecha = dtpFecha.SelectedDate;
                if (fecha.HasValue)
                {
                    bool createcli = false;
                    if (clienteexiste == false && txtNom.Text.Length > 0 && txtApe.Text.Length > 0 && txtEmail.Text.Length > 0)
                    {
                        usuarioBLL usrBLL = new usuarioBLL();
                        createcli = usrBLL.CreateCliente(Int32.Parse(txtrut.Text), txtNom.Text, txtApe.Text, txtEmail.Text);
                        if (createcli)
                        {
                            clienteexiste = true;
                        }
                    }

                    if (clienteexiste == true && cbHora.SelectedIndex != 0 && cbMinuto.SelectedIndex > 0)
                    {

                        string formatted = fecha.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        string hora = cbHora.Text;
                        string minuto = cbMinuto.Text;
                        formatted += " " + hora + ":" + minuto + ":00";
                        DateTime fechahora = DateTime.Parse(formatted);

                        int numMesa = int.Parse(txtIdReserva.Text);
                        ReservasBLL resBLL = new ReservasBLL();
                        int rut = int.Parse(txtrut.Text);
                        bool stado = resBLL.InsertReserva(rut, fechahora, numMesa);
                        if (stado)
                        {
                            MessageBox.Show("Reserva Ingresada Correctamente");
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al Ingresar la Reserva");
                        }
                    }
                }
                else {
                    MessageBox.Show("ingrese un valor para la fecha");
                }

            }
            else if (rbCancelarReserva.IsChecked == true)
            {
                if (txtIdReserva.Text.Length > 0)
                {


                    int idreserva = Int32.Parse(txtIdReserva.Text);
                    ReservasBLL resBLL = new ReservasBLL();
                    if (resBLL.DeleteReserva(idreserva))
                    {
                        MessageBox.Show("Reserva Eliminada Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al eliminar la resevra");
                    }
                }

            }

            
        }

        private void RbNuevaReserva_Checked(object sender, RoutedEventArgs e)
        {
            
            

            lbIdReserva.Content = "Numero Mesa:";
            txtIdReserva.Visibility = Visibility.Visible;
            

            lbRutCliente.Visibility = Visibility.Visible;
            txtrut.Visibility = Visibility.Visible;
            lbFecha.Visibility = Visibility.Visible;
            lbHora.Visibility = Visibility.Visible;
            cbHora.Visibility = Visibility.Visible;
            cbMinuto.Visibility = Visibility.Visible;
            dtpFecha.Visibility = Visibility.Visible;
            dtpFecha.IsEnabled = false;
            cbHora.IsEnabled = false;
            cbMinuto.IsEnabled = false;

            dtpFecha.IsEnabled = true;
            btnAgregar.Content = "Agregar Reserva";


            MesaBLL mesBLL = new MesaBLL();
            dtgReservas.ItemsSource = mesBLL.GetlAllMesas().DefaultView;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

            if (rbCancelarReserva.IsChecked == true)
            {
                ReservasBLL resBLL = new ReservasBLL();
                int rutCliente = Int32.Parse(txtrut.Text);

                dtgReservas.ItemsSource = resBLL.GetReservasByRut(rutCliente).DefaultView;
                if (dtgReservas.Items.Count == 0)
                {
                    MessageBox.Show("El cliente no tiene reservas Registradas");
                }
                else
                {

                }
                dtgReservas.IsEnabled = true;
                dtgReservas.IsReadOnly = true;
            }
            else if (rbNuevaReserva.IsChecked == true)
            {
                ClienteBLL cliBLL = new ClienteBLL();
                int rut =  int.Parse( txtrut.Text);
                clienteexiste = cliBLL.getCliente(rut);
                if (clienteexiste)
                {
                    dtpFecha.IsEnabled = true;
                    cbHora.IsEnabled = true;
                    cbMinuto.IsEnabled = true;

                    lbApellido.Visibility = Visibility.Hidden;
                    lbNom.Visibility = Visibility.Hidden;
                    lbEmail.Visibility = Visibility.Hidden;
                    txtApe.Visibility = Visibility.Hidden;
                    txtNom.Visibility = Visibility.Hidden;
                    txtEmail.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbApellido.Visibility = Visibility.Visible;
                    lbNom.Visibility = Visibility.Visible;
                    lbEmail.Visibility = Visibility.Visible;
                    txtApe.Visibility = Visibility.Visible;
                    txtNom.Visibility = Visibility.Visible;
                    txtEmail.Visibility = Visibility.Visible;
                }
                dtgReservas.IsEnabled = true;
                dtgReservas.IsReadOnly = true;
            }

        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Txtrut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txtrut.Text.Length;

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

        private void TxtIdReserva_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 48 && ascii <= 57)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txtrut.Text.Length;

            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

                if (tamanio < 49)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

        }

        private void TxtApe_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txtrut.Text.Length;

            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (tamanio < 24)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtNom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txtrut.Text.Length;

            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (tamanio < 24)
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
