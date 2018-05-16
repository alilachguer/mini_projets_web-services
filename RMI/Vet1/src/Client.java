

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class Client {
	
	private Client() {}

	public static void main(String[] args) {

		String host = (args.length < 1) ? null : args[0];
		try {
			Registry registry = LocateRegistry.getRegistry(host);
			Animal stub = (Animal) registry.lookup("Animal");
			
			System.out.println(stub.afficher());
			
			System.out.println("modification dossier suivi...");
			stub.getDossierSuivi().setSuivi("dossier suivi " + stub.getNom());
			System.out.println(stub.getDossierSuivi().getSuivi());
			
			System.out.println(stub.getRace());
			
			System.out.println("recuperation espece: " + stub.getEspece());
			
		} catch (Exception e) {
			System.err.println("Client exception: " + e.toString());
			e.printStackTrace();
		}
	}
}