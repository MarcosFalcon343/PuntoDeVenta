using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorCSHARP.Clases
{
    class Producto
    {
        private String IdProducto;
        private String Nombre;
        private String Precio;
        private String Cantidad;

		public Producto(String idProducto, String nombre, String precio, String cantidad)
		{
			IdProducto = idProducto;
			Nombre = nombre;
			Precio = precio;
			Cantidad = cantidad;
		}



		public String getNombre()
		{
			return Nombre;
		}


		public void setNombre(String nombre)
		{
			Nombre = nombre;
		}


		public String getPrecio()
		{
			return Precio;
		}


		public void setPrecio(String precio)
		{
			Precio = precio;
		}


		public String getCantidad()
		{
			return Cantidad;
		}


		public void setCantidad(String cantidad)
		{
			Cantidad = cantidad;
		}

		public void addCantidad(int cant)
		{
			this.setCantidad((Int32.Parse(Cantidad) + cant).ToString());
		}

		public void removeCantidad(int cant)
		{
			this.setCantidad((Int32.Parse(Cantidad) - cant).ToString());
		}

		public String getIdProducto()
		{
			return IdProducto;
		}

		public String txt()
		{
			return this.getIdProducto() + "," + this.getNombre() + "," + this.Precio + "," + this.Cantidad + "\n";
		}

		public String toString()
		{
			return Libreria.Libreria.rellenarespacios(getIdProducto(), 5) + " " + Libreria.Libreria.rellenarespacios(getNombre(), 60) + " " + Libreria.Libreria.rellenarespacios(getPrecio(), 6) + " " + Libreria.Libreria.rellenarespacios(Cantidad, 4);
		}




	}
}
