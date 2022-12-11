import Libreria.Libreria;
import Listas.LProductos;
import Productos.ProductosMenu;
import Ticket.PuntoVentaMenu;

public class Principal {
	
	private static String[] main = {"MENU PRINCIPAL\n","1.-PRODUCTOS","2.-PUNTO DE VENTA","3.-REPORTES DE VENTA","4.-SALIDA"};
	private static ProductosMenu PMenu;
	
	public static void main(String[] args) {
		String op = "0";
		inicializar();
		try {
			do {
				op = Libreria.leerDato(Libreria.mostrarMenu(main));
				
				switch(op) {
				case "1":
					PMenu.ProductosMain();
					break;
				case "2":
					System.out.println();
					PuntoVentaMenu VMenu = new PuntoVentaMenu(PMenu.getListado());
					VMenu.PuntoVentaMain();
					break;
				case "3":
					break;
				default:
					break;
				}
			}while(op.compareTo("4")!=0);
		}catch(Exception e) {
			
		}
	}
	
	public static void inicializar() {
		PMenu = new ProductosMenu();
	}
}
