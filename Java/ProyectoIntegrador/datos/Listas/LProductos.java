package Listas;

import java.util.ArrayList;
import Clases.Lista;
import Clases.Producto;
import Libreria.Libreria;

public class LProductos extends Lista{

	public LProductos(String name) {
		super(name);
		// TODO Auto-generated constructor stub
	}

	public void insertar(String nombre, String precio,String cantidad){
		Producto producto;
		String idProducto;
		try {
			do {
				idProducto = sigID();
			}while(existe(idProducto) != -1);
			
			producto = new Producto(idProducto,nombre,precio,cantidad);
			this.agregar(producto);
			
		}catch(Exception e) {
			System.out.println("ERROR AL INSERTAR EL PRODUCTO" + e.getMessage());
		}
	}
	
	private int existe(String id) {
		int ck  = -1;
		int pos = 0;
		for(Object nodo: lista) {
			if(((Producto)nodo).getIdProducto().equals(id)) ck = pos;
			pos++;
		}
		return ck;
	}
	
	private String sigID() {
		String id = "-1";
		int ultimo = Integer.parseInt(((Producto)lista.get(lista.size()-1)).getIdProducto());
		id = Libreria.idFormat(String.valueOf(ultimo + 1));
		return String.valueOf(id);
	}
	
	@Override
	public void mostrar() {
		// TODO Auto-generated method stub
		for(Object nodo: lista) {
			System.out.println(((Producto)nodo).toString());
		}
		
	}

	@Override
	public void eliminar(String id) {
		int i = 0;
		int pos = -1;
		for(Object nodo: lista) {
			if(((Producto)nodo).getIdProducto().equals(id)) pos = i;
			i++;
		}
		lista.remove(pos);
		this.escribirArchivo();
	}


	public boolean actualizar(String id,String precio) {
		boolean c = false;
		try {
			if(existe(id) != 1) {
				((Producto)lista.get(existe(id))).setPrecio(precio);
				this.escribirArchivo();
				return c = true;
			}
			
		}catch(Exception e) {
			System.out.println(e.getMessage());
		}
		return c;
	}
	
	public Producto obtener(String id) {
		int i = 0;
		int pos = -1;
		for(Object nodo: lista) {
			if(((Producto)nodo).getIdProducto().equals(id)) pos = i;
			i++;
		}
		return (Producto) lista.get(pos);
	}
	
	public ArrayList<Object> getListado() {
		return this.lista;
	}

		
		

}
