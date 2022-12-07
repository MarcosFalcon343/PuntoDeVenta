
public class productos extends Archivo{

	public productos(String name) {
		super(name);
		// TODO Auto-generated constructor stub
	}

	
	@Override
	public void mostrarLista() {
		// TODO Auto-generated method stub
		for(Object nodo: lista) {
			System.out.println(((Producto)nodo).toString());
		}
		
	}

	@Override
	public void eliminarObjecto() {
		String id = null;
		int i = 0;
		int pos = -1;
		this.mostrarLista();
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
		
		

}
