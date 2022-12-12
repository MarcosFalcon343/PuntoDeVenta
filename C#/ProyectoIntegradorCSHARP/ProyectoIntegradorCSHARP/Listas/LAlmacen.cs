using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoIntegradorCSHARP.Clases;

namespace ProyectoIntegradorCSHARP.Listas
{
    class LAlmacen : Lista
    {
		public LAlmacen(String name) : base(name)
		{
		}

		public void insertar(Almacen alm)
		{
			Almacen ALM = alm;
			this.agregar(ALM);
		}
		public override void mostrar()
		{
			// TODO Auto-generated method stub
			this.leerArchivo();
			String almacen = Libreria.Libreria.rellenarespacios("FECHA", 12) + Libreria.Libreria.rellenarespacios("ID", 5) + Libreria.Libreria.rellenarespacios("NOMBRE", 60) + Libreria.Libreria.rellenarespacios("CANT", 5)
			+ Libreria.Libreria.rellenarespacios("TIPO", 5) + Libreria.Libreria.rellenarespacios("SA", 5) + Libreria.Libreria.rellenarespacios("SN", 5);
			Console.WriteLine(almacen);
			if (lista.Count > 0) foreach (Object nodo in lista)Console.WriteLine(((Almacen)nodo).toString());
			else Console.WriteLine("\nNO HAY MOVIENTOS REGISTRADOS\n");
		}

		public override void eliminar(String id)
		{
			// TODO Auto-generated method stub
			Console.WriteLine("\nNO SE PUEDE ALTERAR LOS REGISTROS DE ALMACEN O_o\n");

		}

    }
}
