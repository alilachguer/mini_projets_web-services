

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class Client {
	
	private Client() {}

	public static void main(String[] args) {

		String host = (args.length < 1) ? null : args[0];
		try {
			Registry registry = LocateRegistry.getRegistry(host);
			CabinetInterface stub = (CabinetInterface) registry.lookup("cabinet");
			
			//System.out.println(stub.afficher());
			System.out.println("les patients de " + stub.getCabinetNom());
			for (AnimalImpl a : stub.getPatients()) {
				System.out.println(a.afficher());
			}
			
			
		} catch (Exception e) {
			System.err.println("Client exception: " + e.toString());
			e.printStackTrace();
		}
	}
}