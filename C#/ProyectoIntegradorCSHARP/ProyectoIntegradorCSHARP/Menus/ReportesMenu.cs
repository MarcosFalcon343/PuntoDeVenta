using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIntegradorCSHARP.Listas;

namespace ProyectoIntegradorCSHARP.Menus
{
    class ReportesMenu
    {
		private static String[] main = { "MENU REPORTES", "1.-VENTA DIARIA", "2.-VENTA DETERMINADA POR FECHA", "3.-VENTA POR PRODUCTO", "4.-CANCELAR" };
		private static LVenta ventas;

		public ReportesMenu()
		{
			ventas = new LVenta("ventas.txt");
		}

		public void ReportesMain()
		{
			String op = "0";
			ventas.leerArchivo();
			try
			{
				while (op.CompareTo("4") != 0)
				{
					Console.Clear();
					op = Libreria.Libreria.leerDato(Libreria.Libreria.mostrarMenu(main));

					switch (op)
					{
						case "1":
							Console.Clear();
							mostrarDia();
							Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR");
							Console.ReadKey();
							break;
						case "2":
							Console.Clear();
							mostrarFecha();
							Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR");
							Console.ReadKey();
							break;
						case "3":
							Console.Clear();
							mostrarProductos();
							Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR");
							Console.ReadKey();
							break;
						default:
							op = "4";
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

		private static void mostrarDia()
		{
			String diaHoy = Libreria.Libreria.Fecha();
			String venta = Libreria.Libreria.rellenarespacios("IDT", 5) + Libreria.Libreria.rellenarespacios("IDP", 5) + Libreria.Libreria.rellenarespacios("PRECIO", 6) + Libreria.Libreria.rellenarespacios("CANT", 4) + Libreria.Libreria.rellenarespacios("SUBTO", 5) + Libreria.Libreria.rellenarespacios("IVA", 5) + Libreria.Libreria.rellenarespacios("TOTAL", 5);
			Console.WriteLine("VENTAS DEL DIA DE HOY " + diaHoy + "\n" + venta);
			ventas.mostrarDia(diaHoy);
		}

		private static void mostrarFecha()
		{
			try
			{
				ventas.mostrar();
				Console.WriteLine("VENTAS POR FECHAS:");
				ventas.mostrarF();
				int fecha = Int32.Parse(Libreria.Libreria.leerDato("SELECCIONE EL NUMERO CORRESPONDIENTE A LA FECHA DESEADA"));
				String venta = Libreria.Libreria.rellenarespacios("IDT", 5) + Libreria.Libreria.rellenarespacios("IDP", 5) + Libreria.Libreria.rellenarespacios("PRECIO", 6) + Libreria.Libreria.rellenarespacios("CANT", 4) + Libreria.Libreria.rellenarespacios("SUBTO", 5) + Libreria.Libreria.rellenarespacios("IVA", 5) + Libreria.Libreria.rellenarespacios("TOTAL", 5);
				Console.WriteLine(venta);
				ventas.mostrarDia(ventas.getFecha((fecha - 1)));
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}

		private static void mostrarProductos()
		{
			try
			{
				ventas.mostrar();
				Console.WriteLine("VENTAS POR PRODUCTOS:");
				String producto = Libreria.Libreria.rellenarespacios("ID", 5) + " " + Libreria.Libreria.rellenarespacios("NOMBRE", 60) + " " + Libreria.Libreria.rellenarespacios("PRECIO", 6) + " " + Libreria.Libreria.rellenarespacios("CANT", 4)
				+ Libreria.Libreria.rellenarespacios("SUBT", 6) + Libreria.Libreria.rellenarespacios("IVA", 6) + Libreria.Libreria.rellenarespacios("TOTAL", 6);
				Console.WriteLine(producto);
				ventas.mostrarP();
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}
	}
}
