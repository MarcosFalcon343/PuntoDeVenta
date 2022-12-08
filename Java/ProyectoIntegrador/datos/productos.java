import java.io.IOException;

public class productos extends Lista{

	public productos(String name) {
		super(name);
		// TODO Auto-generated constructor stub
	}

	public void insertarProducto(){
		String idProducto,nombre,precio; 
		int cantidad;
		Producto producto;
		try {
			System.out.println("INGRESE EL NOMBRE DEL PRODUCTO");
			nombre = Libreria.leerDato();
			System.out.println("INGRESE EL PRECIO DEL PRODUCTO");
			precio = Libreria.leerDato();
			System.out.println("INGRESE LA CANTTIDAD DE PRODUCTO");
			cantidad = Integer.parseInt(Libreria.leerDato());
			
			do {
				idProducto = sigID();
			}while(existe(idProducto) != -1);
			
			producto = new Producto(idProducto,nombre,precio,cantidad);
			this.agregar(producto);
			
		}catch(Exception e) {
			System.out.println(e.getMessage());
		}
		
	}
	
	public int existe(String id) {
		int ck  = -1;
		int pos = 0;
		for(Object nodo: lista) {
			if(((Producto)nodo).getIdProducto().equals(id)) ck = pos;
			pos++;
		}
		return ck;
	}
	
	private String sigID() {
		int id = -1;
		int ultimo = Integer.parseInt(((Producto)lista.get(lista.size()-1)).getIdProducto());
		id = ultimo + 1;
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
	public void eliminar() {
		String id = null;
		int i = 0;
		int pos = -1;
		this.mostrar();
		System.out.println("\nINGRESE EL ID DEL PRODUCTO A ELIMINAR");
		try {
			id = Libreria.leerDato();
		}catch(Exception e) {
			System.out.println(e.getMessage());
		}
		for(Object nodo: lista) {
			if(((Producto)nodo).getIdProducto().equals(id)) pos = i;
			i++;
		}
		lista.remove(pos);
		this.escribirArchivo();
	}


	@Override
	public void actualizar() {
		try {
			String idProducto,precio;
			this.mostrar();
			System.out.println("INGRESE EL ID DEL PRODUCTO A MODIFICAR");
			idProducto = Libreria.leerDato();
			if(existe(idProducto) != 1) {
				System.out.println("INGRESE EL PRECIO DEL PRODUCTO A MODIFICAR");
				precio = Libreria.leerDato();
				((Producto)lista.get(existe(idProducto))).setPrecio(precio);
				this.escribirArchivo();
			}
			
		}catch(Exception e) {
			System.out.println(e.getMessage());
		}
		
	}
		
		

}
