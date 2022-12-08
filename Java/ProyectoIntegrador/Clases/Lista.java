import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;

public abstract class Lista {

	public ArrayList<Object> lista;
	private File archivo;
	
	//Constructor
	public Lista(String name){
		lista = new ArrayList<Object>();
		archivo = new File(name);
		crearArchivo();
		leerArchivo();
	}
	
	//Archivos
	private void crearArchivo() {
		try {
			archivo.createNewFile();
		}catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	protected void escribirArchivo() {
		try {
			FileWriter esc = new FileWriter(archivo);
				for(Object nodo: lista) {
					if(nodo instanceof Producto) esc.write(((Producto) nodo).txt());
				}
				esc.close();
			}catch(IOException e1) {
				System.out.println("ERROR AL SUBIR PRODUCTO" + e1.getMessage());
			}	
	}
	
	private void leerArchivo() {
		String linea = "";
		try {
			BufferedReader bf = new BufferedReader(new FileReader(archivo));
			while(linea != null) {
				linea = bf.readLine();
				if(linea != null) {
					String[] cadena = linea.split(",");
					if(cadena.length == 4) lista.add(new Producto(cadena[0],cadena[1],cadena[2],Integer.parseInt(cadena[3])));
				}
			}
		}catch(IOException e) {
			System.out.println(e.getMessage());
		}
	}
	
	//Listas
	
	protected void agregar(Object nodo) {
		lista.add(nodo);
		this.escribirArchivo();
	}

	
	public abstract void mostrar();
	public abstract void eliminar();
	public abstract void actualizar();
}
