using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIntegradorCSHARP.Menus;

namespace ProyectoIntegradorCSHARP
{
    class Program
    {
        private static String[] main = { "MENU PRINCIPAL\n", "1.-PRODUCTOS", "2.-PUNTO DE VENTA", "3.-ALMACEN", "4.-REPORTES DE VENTA", "5.-SALIDA" };
        private static ProductosMenu PMenu;
        private static AlmacenMenu AMenu;
        private static ReportesMenu RMenu;
        static void Main(string[] args)
        {
			String op = "0";
			inicializar();
			try
			{
				do
				{
					Console.Clear();
					op = Libreria.Libreria.leerDato(Libreria.Libreria.mostrarMenu(main));

					switch (op)
					{
						case "1":
							Console.Clear();
							PMenu.ProductosMain();
							break;
						case "2":
							Console.Clear();
							Console.WriteLine();
							PuntoVentaMenu VMenu = new PuntoVentaMenu();
							VMenu.PuntoVentaMain();
							break;
						case "3":
							Console.Clear();
							AMenu.AlmacenMain(PMenu.getListado());
							break;
						case "4":
							Console.Clear();
							RMenu.ReportesMain();
							break;
						default:
							break;
					}
				} while (op.CompareTo("5") != 0);
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO" + e.Message);
			}
		}

		public static void inicializar()
		{
			PMenu = new ProductosMenu();
			AMenu = new AlmacenMenu();
			RMenu = new ReportesMenu();
		}
	}
}
