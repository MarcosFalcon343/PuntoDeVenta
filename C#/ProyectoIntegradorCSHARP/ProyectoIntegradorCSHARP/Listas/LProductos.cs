using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIntegradorCSHARP.Clases;

namespace ProyectoIntegradorCSHARP.Listas
{
    class LProductos : Lista
    {

		public LProductos(String name) : base(name)
		{
			// TODO Auto-generated constructor stub
		}

		public void insertar(String nombre, String precio, String cantidad)
		{
			Producto producto;
			String idProducto;
			try
			{
				do
				{
					idProducto = sigID();
				} while (existe(idProducto) != -1);

				producto = new Producto(idProducto, nombre, precio, cantidad);
				this.agregar(producto);

			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR AL INSERTAR EL PRODUCTO" + e.Message);
			}
		}

		public int existe(String id)
		{
			int ck = -1;
			int pos = 0;
			foreach (Object nodo in lista)
			{
				if (((Producto)nodo).getIdProducto().Equals(id)) ck = pos;
				pos++;
			}
			return ck;
		}

		private String sigID()
		{
			String id = "-1";
			//int ultimo = Int32.Parse(((Producto)lista.get(lista.Count - 1)).getIdProducto());
			int ultimo = Int32.Parse(((Producto)lista[lista.Count - 1]).getIdProducto());
			id = Libreria.Libreria.idFormat((ultimo + 1).ToString());
			return (id).ToString();
		}

		public void mostrarT()
		{
			// TODO Auto-generated method stub
			this.leerArchivo();
			foreach (Object nodo in lista)
			{
				if (Int32.Parse(((Producto)nodo).getCantidad()) > 0) Console.WriteLine(((Producto)nodo).toString());
			}

		}

		public override void mostrar()
			{
				// TODO Auto-generated method stub
				this.leerArchivo();
				String producto = Libreria.Libreria.rellenarespacios("ID", 5) + " " + Libreria.Libreria.rellenarespacios("NOMBRE", 60) + " " + Libreria.Libreria.rellenarespacios("PRECIO", 6) + " " + Libreria.Libreria.rellenarespacios("CANT", 4);
				Console.WriteLine(producto);
				foreach (Object nodo in lista)
				{
					Console.WriteLine(((Producto)nodo).toString());
				}

			}

		public override void eliminar(String id)
			{
				int i = 0;
				int pos = -1;
				foreach (Object nodo in lista)
				{
					if (((Producto)nodo).getIdProducto().Equals(id.Trim())) pos = i;
					i++;
				}
				lista.RemoveAt(pos);
				this.escribirArchivo();
				this.leerArchivo();
			}


		public Boolean actualizar(String id, String precio)
		{
			Boolean c = false;
			try
			{
				if (existe(id) != 1)
				{
					((Producto)lista[existe(id)]).setPrecio(precio);
					this.escribirArchivo();
					this.leerArchivo();
					return c = true;
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return c;
		}

		public Boolean actualizarC(String id, String cant)
		{
			Boolean c = false;
			try
			{
				if (existe(id) != 1)
				{
					((Producto)lista[existe(id)]).setCantidad(cant);
					this.escribirArchivo();
					this.leerArchivo();
					return c = true;
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return c;
		}

		public Producto obtener(String id)
		{
			int i = 0;
			int pos = -1;
			this.leerArchivo();
			foreach (Object nodo in lista)
			{
				if (((Producto)nodo).getIdProducto().Equals(id)) pos = i;
				i++;
			}
			return (Producto)lista[pos];
		}

		public ArrayList getListado()
		{
			return this.lista;
		}

		public Boolean addCantidad(String id, String cantidad)
		{
			Boolean ck = false;
			foreach (Object nodo in lista)
			{
				if (((Producto)nodo).getIdProducto().Equals(id))
				{
					((Producto)nodo).addCantidad(Int32.Parse(cantidad));
					ck = true;
				}

			}

			this.escribirArchivo();
			this.leerArchivo();
			return ck;
		}

	}
}
