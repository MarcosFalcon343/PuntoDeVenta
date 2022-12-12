using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorCSHARP.Clases
{
    class Venta : ICuenta
    {
		//Fecha, idTicket, idProducto, Precio, Cantidad, subtotal, Iva, Total
		private String fecha;
		private String idTicket;
		private String idProducto;
		private String precio;
		private String cantidad;



		public Venta(String fecha, String idTicket, String idProducto, String precio, String cantidad)
		{
			this.fecha = fecha;
			this.idTicket = idTicket;
			this.idProducto = idProducto;
			this.precio = precio;
			this.cantidad = cantidad;
		}


		public String getFecha()
		{
			return fecha;
		}
		public String getIdTicket()
		{
			return idTicket;
		}
		public String getIdProducto()
		{
			return idProducto;
		}
		public String getPrecio()
		{
			return precio;
		}
		public String getCantidad()
		{
			return cantidad;
		}

		//Fecha, idTicket, idProducto, Precio, Cantidad, subtotal, Iva, Total
		public String txt()
		{
			return this.getFecha() + "," + this.getIdTicket() + "," + this.getIdProducto() + "," + this.getPrecio() + "," + this.getCantidad() + "," + this.subtotal() + "," + this.IVA() + "," + this.total() + "\n";
		}

		public String toString()
		{

			return Libreria.Libreria.rellenarespacios(this.idTicket, 5) + Libreria.Libreria.rellenarespacios(idProducto, 5) + Libreria.Libreria.rellenarespacios(precio, 6) + Libreria.Libreria.rellenarespacios(cantidad, 4) + Libreria.Libreria.rellenarespacios(this.subtotal(), 5) + Libreria.Libreria.rellenarespacios(this.IVA(), 5) + Libreria.Libreria.rellenarespacios(this.total(), 5);
		}

		public String subtotal()
			{
				// TODO Auto-generated method stub
				double subtotal = Double.Parse(this.getPrecio()) * Double.Parse(this.getCantidad());
				return (subtotal).ToString();
			}
		
		public String IVA()
			{
				// TODO Auto-generated method stub
				double iva = Double.Parse(this.subtotal()) * 0.16;
				return (iva).ToString();
			}
		
		public String total()
			{
				// TODO Auto-generated method stub
				double total = Double.Parse(this.subtotal()) + Double.Parse(this.IVA());
				return (total).ToString();
			}
	}
}
