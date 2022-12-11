package Ticket;

import java.util.ArrayList;

import Clases.Producto;
import Clases.Ticket;
import Clases.Venta;
import Libreria.Libreria;
import Listas.LVenta;

public class PuntoVentaMenu {

	private static String[] main = {"1.-Alta","2.-Baja","3.-Inventario","4.-Pagar","5.-Cancelar venta"};
	private static LVenta venta;
	private static ArrayList<Producto> listado;
	private static Ticket ticket;
	
	public PuntoVentaMenu(ArrayList lista) {
		venta = new LVenta("ventas.txt");
		listado = lista;
		ticket = new Ticket(Libreria.idFormat(venta.sigID()),Libreria.Fecha());
	}

	public void PuntoVentaMain() {
		String op = "0";
		try {
			while(op.compareTo("5")!=0){
				System.out.println(ticket.ticket());
				op = Libreria.leerDato(Libreria.mostrarMenu(main));
				
				switch(op) {
				case "1":
					this.alta();
					break;
				case "2":
					this.baja();
					break;
				case "3":
					this.mostrarInventario();
					break;
				case "4":
					pagar();
				default:
					op = "5";
					System.out.println("SALIDA DE PRODUCTOS");
					break;
				}
			}
			
		}catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	
	private void alta() {
		String id;
		Producto producto = null;
		try {
			this.mostrarInventario();
			id = Libreria.leerDato("INGRESE EL ID DEL PRODUCTO A INSERTAR");
			producto = this.obtener(id);
			producto.setCantidad("1");
			//System.out.println(producto);
			ticket.insertar(producto);
		}catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	private void baja() {
		String id;
		try {
			if(ticket.size() > 0) {
				System.out.println(ticket.mostrarProductos());
				id = Libreria.leerDato("INGRESE EL ID DEL PRODUCTO A REMOVER");
				ticket.remover(id);
			}else System.out.println("NO HAY NINGUN PRODUCTO, AGREGUE UNO");;
		}catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	private void mostrarInventario() {
		System.out.println("PRODUCTOS");
		for(Producto nodo: listado) {
			System.out.println(nodo);
		}
		System.out.println("\n");
	}
	
	private void pagar() {
		ArrayList<Producto> productos = ticket.getProductos();
		try {
			for(Producto nodo: productos) {
				venta.insertar(new Venta(ticket.getFecha(),ticket.getIdTicket(),nodo.getIdProducto(),nodo.getPrecio(),nodo.getCantidad()));
			}
		}catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	private Producto obtener(String id) {
		int i = 0;
		int pos = -1;
		for(Producto nodo: listado) {
			if((nodo).getIdProducto().equals(id)) pos = i;
			i++;
		}
		return listado.get(pos);
	}
	
	
	
}
