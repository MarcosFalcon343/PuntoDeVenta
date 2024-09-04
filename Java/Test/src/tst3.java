
public class tst3 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int n[] = {5,2,4,6,1,3};
		int clave, i;
		
		for(int j = 1; j < n.length; j++) {
			clave = n[j];
			i = j - 1;
			
			while(i > -1 && n[i] > clave) {
				n[i+1] = n[i];
				i--;
			}
			n[i+1] = clave;
			
		}
		
		for(i = 0; i < n.length; i++) {
			System.out.println(n[i] + " ");
		}
	}

}
