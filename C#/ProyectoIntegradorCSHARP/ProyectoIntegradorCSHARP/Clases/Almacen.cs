using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorCSHARP.Clases
{
    class Almacen
    {
		private String Fecha;
		private String IdProducto;
		private String Nombre;
		private String Cantidad;
		private String tipo;
		private String saldoA;
		private String saldoN;

		public Almacen(String fecha,String idProducto, String nombre, String cantidad, String tipo, String saldoA,String saldoN) {
		this.Fecha = fecha;
		this.IdProducto = idProducto;
		this.Nombre = nombre;
		this.Cantidad = cantidad;
		this.tipo = tipo;
		this.saldoA = saldoA;
		this.saldoN = saldoN;
	}
	
	public String txt() {
		return this.Fecha + "," + this.IdProducto + "," + this.Nombre + "," + this.Cantidad + "," + this.tipo + "," + this.saldoA + "," + this.saldoN+"\n";
	}
	
	public String toString() {
		return Libreria.Libreria.rellenarespacios(Fecha, 12) + Libreria.Libreria.rellenarespacios(IdProducto, 5) + Libreria.Libreria.rellenarespacios(Nombre, 60) + Libreria.Libreria.rellenarespacios(Cantidad, 5)
		+ Libreria.Libreria.rellenarespacios(tipo, 5) + Libreria.Libreria.rellenarespacios(saldoA, 5) + Libreria.Libreria.rellenarespacios(saldoN, 5);
	}
	
	public String getIdProducto() {
		return IdProducto;
	}
	public String getNombre() {
		return Nombre;
	}
	public String getCantidad() {
		return Cantidad;
	}
	public String getTipo() {
		return tipo;
	}
	public String getSaldoA() {
		return saldoA;
	}
	public String getSaldoN() {
		return this.saldoN;
	}
	
	}
}
