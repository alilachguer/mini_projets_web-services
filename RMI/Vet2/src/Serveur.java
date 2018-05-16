
import java.rmi.registry.Registry;
import java.rmi.server.UnicastRemoteObject;
import java.rmi.registry.LocateRegistry;

public class Serveur {

	public Serveur() {}

	public static void main(String args[]) {
		
		try {
			CabinetImpl cabinet = new CabinetImpl("cabinet veto");
			
			//ajouter des patients au cabinet
			Espece chien = new Espece("chien", 10);
			Espece chat = new Espece("chat", 7);
			cabinet.addAnimal(new AnimalImpl("patient1", "berger allemand", chien));
			cabinet.addAnimal(new AnimalImpl("patient2", "chihuahua", chien));
			cabinet.addAnimal(new AnimalImpl("patient3", "siamois", chat));
			
			CabinetInterface skeleton = (CabinetInterface) UnicastRemoteObject.exportObject(cabinet, 0);
			//CabinetInterface patientSkeleton = (CabinetInterface) UnicastRemoteObject.exportObject(cabinet.getPatients(), 0);
			
			System.setProperty("java.security.policy","bin/policyFile.policy");
			if (System.getSecurityManager() == null)
	            System.setSecurityManager(new SecurityManager());
			
			//Registry registry = LocateRegistry.createRegistry(1099);
			Registry registry = LocateRegistry.getRegistry();
			if (registry==null){
				System.err.println("RmiRegistry not found");
			}else{
				registry.bind("cabinet", skeleton);
				System.err.println("Server ready");
			}
		} catch (Exception e) {
			System.err.println("Server exception: " + e.toString());
			e.printStackTrace();
		}
	}
}