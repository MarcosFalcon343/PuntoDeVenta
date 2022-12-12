using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIntegradorCSHARP.Clases;
using ProyectoIntegradorCSHARP.Listas;

namespace ProyectoIntegradorCSHARP.Menus
{
    class PuntoVentaMenu
    {

		private static String[] main = { "1.-Alta", "2.-Baja", "3.-Inventario", "4.-Pagar", "5.-Cancelar venta" };
		private static LVenta venta;
		private static LProductos listado = new LProductos("productos.txt");
		private static Ticket ticket;

		public PuntoVentaMenu()
		{
			venta = new LVenta("ventas.txt");
			ticket = new Ticket(Libreria.Libreria.idFormat(venta.sigID()), Libreria.Libreria.Fecha());
		}

		public void PuntoVentaMain()
		{
			String op = "0";
			try
			{
				while (op.CompareTo("5") != 0)
				{
					Console.Clear();
					Console.WriteLine(ticket.ticket());
					op = Libreria.Libreria.leerDato(Libreria.Libreria.mostrarMenu(main));

					switch (op)
					{
						case "1":
							Console.Clear();
							this.alta();
							break;
						case "2":
							Console.Clear();
							this.baja();
							break;
						case "3":
							Console.Clear();
							this.mostrarInventario();
							Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR");
							Console.ReadKey();
							break;
						case "4":
							Console.Clear();
							pagar();
							op = "5";
							Console.WriteLine("SALIDA DE PRODUCTOS");
							break;
					}
				}

			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}


		private void alta()
		{
			String id;
			Producto producto = null;
			try
			{
				this.mostrarInventario();
				id = Libreria.Libreria.leerDato("INGRESE EL ID DEL PRODUCTO A INSERTAR");
				producto = this.obtener(id);
				ticket.insertar(producto);
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}

		private void baja()
		{
			String id;
			try
			{
				if (ticket.size() > 0)
				{
					Console.WriteLine(ticket.mostrarProductos());
					id = Libreria.Libreria.leerDato("INGRESE EL ID DEL PRODUCTO A REMOVER");
					ticket.remover(id);
				}
				else Console.WriteLine("NO HAY NINGUN PRODUCTO, AGREGUE UNO"); ;
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}

		private void mostrarInventario()
		{
			Console.WriteLine("PRODUCTOS");
			listado.mostrarT();
			Console.WriteLine("\n");
		}

		private void pagar()
		{
			ArrayList productos = ticket.getProductos();
			try
			{
				if (productos.Count > 0)
				{
					foreach (Producto nodo in productos)
					{
						venta.insertar(new Venta(ticket.getFecha(), ticket.getIdTicket(), nodo.getIdProducto(), nodo.getPrecio(), nodo.getCantidad()));
					}
				}
				else
				{
					Console.WriteLine("CANCELANDO COMPRA");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}

		private Producto obtener(String id)
		{
			return listado.obtener(id);
		}

	}
}
