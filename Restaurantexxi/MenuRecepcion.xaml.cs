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

namespace Restaurantexxi
{
	/// <summary>
	/// Lógica de interacción para MenuRecepcion.xaml
	/// </summary>
	public partial class MenuRecepcion : Window
	{
		public MenuRecepcion()
		{
			InitializeComponent();
		}

		private void Button_registro(object sender, RoutedEventArgs e)
		{
			MenuRegistrados mregis = new MenuRegistrados();

			mregis.ShowDialog();
		}

		private void btn_reserva_Click(object sender, RoutedEventArgs e)
		{
			GestionReservas mreserv = new GestionReservas();

			mreserv.ShowDialog();
		}

		private void btn_cliente_Click(object sender, RoutedEventArgs e)
		{
			MenuClienteNuevo mcli = new MenuClienteNuevo();

			mcli.ShowDialog();
		}
	}
}
