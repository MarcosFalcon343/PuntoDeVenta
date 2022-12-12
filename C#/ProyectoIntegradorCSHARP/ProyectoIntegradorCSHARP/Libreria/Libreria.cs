using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorCSHARP.Libreria
{
    class Libreria
    {

        //Visual
        public static String rellenarespacios(String dato, int tamano)
        {
            String cadena;
            cadena = dato;
            for (int ciclo = dato.Length - 1; ciclo < tamano; ciclo++)
                cadena = cadena + " ";
            return cadena;
        }

        public static String mostrarMenu(String[] op)
        {
            String cadena = "";
            foreach (String nodo in op) cadena += nodo + "\n";
            cadena = cadena + "\nQUE OPCION DESEA...:";
            return cadena;
        }

        public static String separador(char sep, int cant)
        {
            String separador = "";
            for (int i = 0; i < cant; i++) separador += sep;
            separador += "\n";
            return separador;
        }


        //Lectura
        public static String leerDato()
        {
            String br = Console.ReadLine();
            return br;
        }


    public static String leerDato(String msg) { 

    	Console.WriteLine(msg);
           String br = Console.ReadLine();
           return br;
     }

//Fecha

public static String Fecha()
{
    String date = DateTime.UtcNow.ToString("MM-dd-yyyy");
    return date;
}

public static String idFormat(String ID)
{
    String id = "";
    int num = Int32.Parse(ID);
            if (num < 10) id = "00" + num.ToString().Trim();
            else if (num > 9 && num < 100) id = "0" + num.ToString().Trim();
            else id = num.ToString().Trim();

    return id;
}

public static Boolean evaluarNumerico(String dato, int tipo)
{
    Boolean valido = true;
    try
    {
        switch (tipo)
        {
            case 1: { int x = Int32.Parse(dato); } break;
            case 2: { double x = Double.Parse(dato); } break;
        }
    }
    catch (Exception e)
    {
        valido = false;
    }
    return valido;
}

    }
}
