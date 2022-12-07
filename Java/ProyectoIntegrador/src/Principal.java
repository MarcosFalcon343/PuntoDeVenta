
public class Principal {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		productos productos = new productos("productos.txt");
		productos.mostrarLista();
		productos.eliminarObjecto();
		productos.mostrarLista();
	}

}
