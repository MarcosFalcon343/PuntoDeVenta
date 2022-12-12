using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIntegradorCSHARP.Clases;

namespace ProyectoIntegradorCSHARP.Listas
{
    class LVenta : Lista
    {

		private ArrayList fechas = new ArrayList();
		private ArrayList idProductos = new ArrayList();

		public LVenta(String name) : base(name)
		{
			// TODO Auto-generated constructor stub
		}
		public void insertar(Venta venta)
		{
			Venta sell = venta;

			LProductos productos = new LProductos("productos.txt");
			Producto producto = productos.obtener(sell.getIdProducto());

			String sN = (Int32.Parse(producto.getCantidad()) - Int32.Parse(sell.getCantidad())).ToString();

			Almacen alm = new Almacen(sell.getFecha(), producto.getIdProducto(), producto.getNombre(), sell.getCantidad(), "BAJA", producto.getCantidad(), sN);
			LAlmacen Lalm = new LAlmacen("almacen.txt");
			Lalm.insertar(alm);
			Console.WriteLine(producto.getIdProducto() + " " + sN);
			productos.actualizarC(producto.getIdProducto(), sN);

			this.agregar(sell);
		}

		public String sigID()
		{
			String id = "1";
			if (lista.Count > 0)
			{
				int ultimo = Int32.Parse(((Venta)lista[lista.Count - 1]).getIdTicket());
				id = Libreria.Libreria.idFormat((ultimo + 1).ToString());
			}
			else id = "1";
			return (id).ToString();
		}

		private int existe(String dato, int tipo)
		{
			int ck = -1;
			int pos = 0;
			switch (tipo)
			{
				case 1:
					foreach (Object nodo in fechas)
					{
						if (nodo.Equals(dato)) ck = pos;
						pos++;
					}
					break;
				case 2:
					foreach (Object nodo in idProductos)
					{
						if (nodo.Equals(dato)) ck = pos;
						pos++;
					}
					break;
			}
			return ck;
		}


		public void mostrarDia(String Fecha)
		{
			// TODO Auto-generated method stub
			foreach (Object nodo in lista)
			{
				if (((Venta)nodo).getFecha().Equals(Fecha)) Console.WriteLine(((Venta)nodo).toString());
			}

		}

		public void mostrarF()
		{
			int pos = 0;
			foreach (String nodo in fechas)
			{
				Console.WriteLine((pos + 1) + "  " + nodo);
				pos++;
			}
		}

		public  void mostrarP()
		{
			int cantidad = 0;
			LProductos productos = new LProductos("productos.txt");
			ArrayList Lproductos = new ArrayList();

			foreach (String nodo in idProductos)
			{
				cantidad = 0;
				foreach (Object aux in lista) if (((Venta)aux).getIdProducto().Equals(nodo)) cantidad += Int32.Parse(((Venta)aux).getCantidad());

				Producto producto = productos.obtener(nodo);
				producto.setCantidad((cantidad).ToString());
				Lproductos.Add(producto);
			}

			foreach (Producto nodo in Lproductos)
			{
				double subtotal = Double.Parse(nodo.getPrecio()) * Double.Parse(nodo.getCantidad());
				double iva = (Double.Parse(nodo.getPrecio()) * 0.16) * Double.Parse(nodo.getCantidad());
				double total = subtotal + iva;
				Console.WriteLine(((Producto)nodo).toString() + Libreria.Libreria.rellenarespacios((subtotal).ToString(), 6) + Libreria.Libreria.rellenarespacios((iva).ToString(), 6) + Libreria.Libreria.rellenarespacios((total).ToString(), 6));
			}


		}

		public String getFecha(int pos)
		{
			return fechas[pos].ToString();
		}

	public override void eliminar(String id)
		{
			// TODO Auto-generated method stub
			Console.WriteLine("O_o No se pueden borrar ventas. Con que haciendo fraudes 7-7");
		}

	public override void mostrar()
		{
			// TODO Auto-generated method stub
			foreach (Object nodo in lista)
			{
				if (existe(((Venta)nodo).getFecha(), 1) == -1) fechas.Add(((Venta)nodo).getFecha());
				if (existe(((Venta)nodo).getIdProducto(), 2) == -1) idProductos.Add(((Venta)nodo).getIdProducto());
			}

		}
	}
}
