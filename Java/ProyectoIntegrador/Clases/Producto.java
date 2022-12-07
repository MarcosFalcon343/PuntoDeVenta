public class Producto {

	private String IdProducto;
	private String Nombre;
	private String Precio;
	private int Cantidad;
	
	
	public Producto(String idProducto, String nombre, String precio, int cantidad) {
		super();
		IdProducto = idProducto;
		Nombre = nombre;
		Precio = precio;
		Cantidad = cantidad;
	}


	public String getNombre() {
		return Nombre;
	}


	public void setNombre(String nombre) {
		Nombre = nombre;
	}


	public String getPrecio() {
		return Precio;
	}


	public void setPrecio(String precio) {
		Precio = precio;
	}


	public int getCantidad() {
		return Cantidad;
	}


	public void setCantidad(int cantidad) {
		Cantidad = cantidad;
	}


	public String getIdProducto() {
		return IdProducto;
	}

	public String txt() {
		return this.getIdProducto() + "," + this.getNombre() + "," + this.Precio + "," + this.Cantidad + "\n";
	}

	@Override
	public String toString() {
		return Libreria.rellenarespacios(getIdProducto(), 5) + " " +Libreria.rellenarespacios(getNombre(), 60) + " " + Libreria.rellenarespacios(getPrecio(), 6) + " " + Cantidad;
	}
	
	
	
	
}
