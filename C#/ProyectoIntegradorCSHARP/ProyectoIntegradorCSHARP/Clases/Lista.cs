using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ProyectoIntegradorCSHARP.Clases
{
    abstract class Lista
    {
        public  ArrayList lista;
		private  String archivo;

		//Constructor
		public Lista(String name)
		{
			lista = new ArrayList();
			archivo = name;
			leerArchivo();
		}

		//Archivos


		protected void escribirArchivo()
		{
			try
			{
				TextWriter esc = new StreamWriter(archivo);
				foreach (Object nodo in lista)
				{
					if (nodo.GetType().Equals(typeof(Producto))) esc.WriteLine(((Producto)nodo).txt());
					else if (nodo.GetType().Equals(typeof(Venta))) esc.WriteLine(((Venta)nodo).txt());
					else if (nodo.GetType().Equals(typeof(Almacen))) esc.WriteLine(((Almacen)nodo).txt());
				}
				esc.Close();
			}
			catch(IOException e1) {
				Console.WriteLine("ERROR AL SUBIR PRODUCTO" + e1.Message);
	}
}

	public void leerArchivo()
	{
		String linea = "";
		ArrayList objetos = new ArrayList();
		try
		{
			TextReader bf = new StreamReader(archivo);
			while (linea != null)
			{
				linea = bf.ReadLine();
				if (linea != null)
				{
					String[] cadena = linea.Split(',');
					if (cadena.Length == 4) objetos.Add(new Producto(cadena[0], cadena[1], cadena[2], cadena[3]));
					else if (cadena.Length == 8) objetos.Add(new Venta(cadena[0], cadena[1], cadena[2], cadena[3], cadena[4]));
					else if (cadena.Length == 7) objetos.Add(new Almacen(cadena[0], cadena[1], cadena[2], cadena[3], cadena[4], cadena[5], cadena[6]));
				}
			}
			lista = objetos;
				bf.Close();
		}
		catch (Exception e)
		{
				Console.WriteLine(e.Message);
		}
	}

	//Listas

	public void agregar(Object nodo)
	{
		lista.Add(nodo);
		this.escribirArchivo();
	}



	public abstract void mostrar();
	public abstract void eliminar(String id);

    }
}
