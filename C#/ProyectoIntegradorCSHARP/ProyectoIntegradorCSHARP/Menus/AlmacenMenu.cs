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
    class AlmacenMenu
    {
		private static String[] main = { "MENU ALMACEN\n", "1.-VER MOVIMIENTOS", "2.-AGREGAR", "3.-SALIDA" };
		private static LAlmacen lista;
		private static ArrayList listado;

		public AlmacenMenu()
		{
			lista = new LAlmacen("almacen.txt");
		}

		public void AlmacenMain(ArrayList lista)
		{
			listado = lista;
			String op = "0";
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
							Listado();
							Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR");
							Console.ReadKey();
							break;
						case "2":
							Console.Clear();
							agregar();
							break;
						default:
							Console.WriteLine("SALIDA DE PRODUCTOS");
							break;
					}
				} while (op.CompareTo("3") != 0);

			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}


		private static void Listado()
		{
			Console.WriteLine("MOVIMIENTOS");
			lista.mostrar();
		}

		private static void agregar()
		{
			String id, cantidad, saldoA, saldoN;
			Producto producto;
			try
			{
				mostrarInventario();
				id = Libreria.Libreria.leerDato("\nINGRESE EL ID DEL PRODUCTO A AGREGAR MERCANCIA");
				LProductos productos = new LProductos("productos.txt");
				if (productos.existe(id) != -1)
				{
					producto = productos.obtener(id);
					saldoA = producto.getCantidad();
					cantidad = Libreria.Libreria.leerDato("INGRESE LA CANTIDAD A AGREGAR DEL PRODUCTO");
					if (productos.addCantidad(id, cantidad))
					{
						saldoN = (Int32.Parse(saldoA) + Int32.Parse(cantidad)).ToString();
						Almacen alm = new Almacen(Libreria.Libreria.Fecha(), producto.getIdProducto(), producto.getNombre(), cantidad, "ALTA", saldoA, saldoN);
						lista.insertar(alm);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}

		private static void mostrarInventario()
		{
			Console.WriteLine("PRODUCTOS");
			foreach (Producto nodo in listado)
			{
				Console.WriteLine(((Producto)nodo).toString());
			}
			Console.WriteLine("\n");
		}

	}
}
