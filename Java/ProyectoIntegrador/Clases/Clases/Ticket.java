package Clases;

import java.util.ArrayList;

public class Ticket implements ICuenta{

	private String idTicket;
	private String fecha;
	private ArrayList<Producto> productos;

	public Ticket(String id, String fecha) {
		this.idTicket = id;
		this.fecha = fecha;
		productos = new ArrayList<Producto>();
	}
	
	public void insertar(Producto producto) {
		try {
			if(existe(producto.getIdProducto(),1).equals("-1")) productos.add(producto);
		}catch(Exception e) {
			
		}
	}
	
	public void remover(String id) {
		try {
			int pos = Integer.parseInt(existe(id,2));
			if(!String.valueOf(pos).equals("-1") && Integer.parseInt(productos.get(pos).getCantidad()) <= 0) productos.remove(pos);
		}catch(Exception e) {
			
		}
	}
	
	private String existe(String id, int tipo) {
		int i = 0;
		int pos = -1;
		for(Producto p: productos) {
			if(p.getIdProducto().equals(id)) {
				pos = i;
				switch(tipo) {
				case 1: productos.get(pos).addCantidad(); break;
				case 2: productos.get(pos).removeCantidad(); break;
				}
			}
			i++;
		}
		return String.valueOf(pos);
	}
	
	
	//Visuales
	public String ticket() {
		String ticket = "IDTICKET: " + this.idTicket;
		ticket = ticket + "\nFECHA: " + this.fecha + "\n";
		ticket += this.mostrarProductos();
		ticket += "\nSUBTOTAL: " + this.subtotal();
		ticket += "\nIVA: " + this.IVA();
		ticket += "\nTOTAL: " + this.total();
		return ticket;
	}
	
	public String mostrarProductos() {
		String producto = "";
		if(productos.size() > 0)	for(Producto p: productos)	producto += p.toString() + "\n";
		else producto = "NO HAY NINGUN PRODUCTO AGREGADO";
		
		return producto;
	}
	
	//getters setters
	public int size() {
		return productos.size();
	}
	
	public String getIdTicket() {
		return idTicket;
	}

	public String getFecha() {
		return fecha;
	}

	public ArrayList<Producto> getProductos() {
		return productos;
	}

	@Override
	public String subtotal() {
		double subtotal = 0;
		// TODO Auto-generated method stub
		for(Producto nodo: productos) subtotal += (Integer.parseInt(nodo.getCantidad()) * Double.parseDouble(nodo.getPrecio()));

		return String.valueOf(subtotal);
	}

	@Override
	public String IVA() {
		double iva = 0;
		for(Producto nodo: productos) iva += (0.16 * Double.parseDouble(nodo.getPrecio()) * Integer.parseInt(nodo.getCantidad()));
		return String.valueOf(iva);
	}

	@Override
	public String total() {
		// TODO Auto-generated method stub
		double total = 0;
		total = Double.parseDouble(this.subtotal()) + Double.parseDouble(this.IVA());
		return String.valueOf(total);
	}

}
