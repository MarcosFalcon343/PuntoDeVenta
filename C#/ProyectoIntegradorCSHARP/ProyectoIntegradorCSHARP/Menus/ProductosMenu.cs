using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIntegradorCSHARP.Listas;

namespace ProyectoIntegradorCSHARP.Menus
{
    class ProductosMenu
    {

		private static String[] main = { "MENU PRODUCTOS\n", "1.-ALTA", "2.-BAJAS", "3.-MODIFICAR", "4.-LISTADO", "5.-SALIDA" };
		private static LProductos listado;

		public ProductosMenu()
		{
			listado = new LProductos("productos.txt");
		}

		public void ProductosMain()
		{
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
							insertar();
							break;
						case "2":
							Console.Clear();
							eliminar();
							break;
						case "3":
							Console.Clear();
							actualizar();
							break;
						case "4":
							Console.Clear();
							Listado();
							Console.WriteLine("\nPRESIONE CUALQUIER TECLA PARA CONTINUAR");
							Console.ReadKey();
							break;
						default:
							Console.WriteLine("SALIDA DE PRODUCTOS");
							break;
					}
				} while (op.CompareTo("5") != 0);

			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}

		private static void insertar()
		{
			String nombre, precio, cantidad;
			try
			{
				Console.WriteLine("INGRESE EL NOMBRE DEL PRODUCTO");
				nombre = Libreria.Libreria.leerDato();
				Console.WriteLine("INGRESE EL PRECIO DEL PRODUCTO");
				precio = Libreria.Libreria.leerDato();
				Console.WriteLine("INGRESE LA CANTIDAD DE PRODUCTO");
				cantidad = Libreria.Libreria.leerDato();

				if (Libreria.Libreria.evaluarNumerico(precio, 2) || Libreria.Libreria.evaluarNumerico(cantidad, 1)) listado.insertar(nombre, precio, cantidad);
				else Console.WriteLine("ERROR AL INGRESAR LOS DATOS");

			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}

		private static void eliminar()
		{
			String id;
			try
			{
				Listado();
				id = Libreria.Libreria.leerDato("INGRESE EL ID CORRESPONDIENTE AL PRODUCTO A ELIMINAR");
				listado.eliminar(id);
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}

		private static void actualizar()
		{
			String idProducto, precio;
			try
			{
				Listado();
				idProducto = Libreria.Libreria.leerDato("INGRESE EL ID CORRESPONDIENTE AL PRODUCTO A MODIFICAR");
				precio = Libreria.Libreria.leerDato("INGRESE EL NUEVO PRECIO");
				if (Libreria.Libreria.evaluarNumerico(precio, 1)) if (!listado.actualizar(idProducto, precio)) Console.WriteLine("EL PRODUCTO NO EXISTE");
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR. LLAMA A SOPORTE TECNICO " + e.Message);
			}
		}

		private static void Listado()
		{
			Console.WriteLine("PRODUCTOS");
			listado.mostrar();
		}

		public ArrayList getListado()
		{
			return listado.getListado();
		}
	}
}
