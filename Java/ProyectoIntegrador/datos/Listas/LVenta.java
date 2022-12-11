package Listas;

import Clases.Lista;
import Clases.Venta;
import Libreria.Libreria;

public class LVenta extends Lista{

	public LVenta(String name) {
		super(name);
		// TODO Auto-generated constructor stub
	}
	public void insertar(Venta venta) {
		Venta sell = venta;
		this.agregar(sell);
	}
	
	public String sigID() {
		String id = "1";
		if(lista.size() > 0) {
			int ultimo = Integer.parseInt(((Venta)lista.get(lista.size()-1)).getIdTicket());
			id = Libreria.idFormat(String.valueOf(ultimo + 1));
		}else  id = "1";
		return String.valueOf(id);
	}
	
	private int existe(String id) {
		int ck  = -1;
		int pos = 0;
		for(Object nodo: lista) {
			if(((Venta)nodo).getIdTicket().equals(id)) ck = pos;
			pos++;
		}
		return ck;
	}
	
	

	@Override
	public void mostrar() {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void eliminar(String id) {
		// TODO Auto-generated method stub
		System.out.println("O_o No se pueden borrar ventas. Con que haciendo fraudes 7-7");
	}
}
