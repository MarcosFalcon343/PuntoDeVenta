import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Libreria {

    public static String rellenarespacios(String dato, int tamano)
    {
        String cadena;
        cadena = dato;
        for (int ciclo = dato.length() - 1; ciclo < tamano; ciclo++)
            cadena = cadena + " ";
        return cadena;
    }
    
    public static String leerDato() throws IOException {
    	BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
    	return br.readLine();
    }
}
