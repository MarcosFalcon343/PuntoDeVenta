using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorCSHARP.Clases
{
    class Ticket : ICuenta
    {
		private String idTicket;
		private String fecha;
		private ArrayList productos;

		public Ticket(String id, String fecha)
		{
			this.idTicket = id;
			this.fecha = fecha;
			productos = new ArrayList();
		}

		public void insertar(Producto producto)
		{
			try
			{
				Producto p = producto;
				p.setCantidad("1");
				if (existe(producto.getIdProducto(), 1).Equals("-1")) productos.Add(p);
			}
			catch (Exception e)
			{

			}
		}

		public void remover(String id)
		{
			try
			{
				int pos = Int32.Parse(existe(id, 2));
				if (!(pos).ToString().Equals("-1") && Int32.Parse(((Producto)productos[pos]).getCantidad()) <= 0) productos.RemoveAt(pos);
			}
			catch (Exception e)
			{

			}
		}

		private String existe(String id, int tipo)
		{
			int i = 0;
			int pos = -1;
			foreach (Producto p in productos)
			{
				if (p.getIdProducto().Equals(id))
				{
					pos = i;
					switch (tipo)
					{
						case 1: ((Producto)productos[pos]).addCantidad(1); break;
						case 2: ((Producto)productos[pos]).removeCantidad(1); break;
					}
				}
				i++;
			}
			return (pos).ToString();
		}


		//Visuales
		public String ticket()
		{
			int cant = 100;
			String ticket = Libreria.Libreria.separador('_', cant) + "IDTICKET: " + this.idTicket;
			ticket = ticket + "\nFECHA: " + this.fecha + "\n";
			ticket += Libreria.Libreria.separador('-', cant);
			ticket += this.mostrarProductos();
			ticket += "\n" + Libreria.Libreria.separador('-', cant);
			ticket += "SUBTOTAL: " + this.subtotal();
			ticket += "\nIVA: " + this.IVA();
			ticket += "\nTOTAL: " + this.total();
			ticket += "\n" + Libreria.Libreria.separador('_', cant);
			return ticket;
		}

		public String mostrarProductos()
		{
			String producto = Libreria.Libreria.rellenarespacios("ID", 5) + " " + Libreria.Libreria.rellenarespacios("NOMBRE", 60) + " " + Libreria.Libreria.rellenarespacios("PRECIO", 6) + " " + Libreria.Libreria.rellenarespacios("CANT", 4) + "\n";
			if (productos.Count > 0) foreach (Producto p in productos) producto += p.toString() + "\n";
			else producto = "NO HAY NINGUN PRODUCTO AGREGADO";

			return producto;
		}

		//getters setters
		public int size()
		{
			return productos.Count;
		}

		public String getIdTicket()
		{
			return idTicket;
		}

		public String getFecha()
		{
			return fecha;
		}

		public ArrayList getProductos()
		{
			return productos;
		}

		public String subtotal()
		{
			double subtotal = 0;
			// TODO Auto-generated method stub
			foreach (Producto nodo in productos) subtotal += (Int32.Parse(nodo.getCantidad()) * Double.Parse(nodo.getPrecio()));

			return (subtotal).ToString();
		}

		public String IVA()
			{
				double iva = 0;
				foreach (Producto nodo in productos) iva += (0.16 * Double.Parse(((Producto)nodo).getPrecio()) * Int32.Parse(((Producto)nodo).getCantidad()));
				return (iva).ToString();
			}

		public String total()
		{
			// TODO Auto-generated method stub
			double total = 0;
			total = Double.Parse(this.subtotal()) + Double.Parse(this.IVA());
			return (total).ToString();
		}

	}
}
