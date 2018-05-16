
import java.rmi.registry.Registry;
import java.rmi.server.UnicastRemoteObject;
import java.rmi.registry.LocateRegistry;

public class Serveur {

	public Serveur() {}

	public static void main(String args[]) {
		
		try {
			Espece e = new Espece("Chat", 7);
			AnimalImpl chat = new AnimalImpl("isabelle", "ragdoll", e);
			
//			chat.setEspece(e);
			Animal skeleton = (Animal) UnicastRemoteObject.exportObject(chat, 0);
			
			System.setProperty("java.security.policy","./policyFile.policy");
			if (System.getSecurityManager() == null)
	            System.setSecurityManager(new SecurityManager());
			
			//Registry registry = LocateRegistry.createRegistry(1099);
			Registry registry = LocateRegistry.getRegistry();
			if (registry==null){
				System.err.println("RmiRegistry not found");
			}else{
				registry.bind("Animal", skeleton);
				System.err.println("Server ready");
			}
		} catch (Exception e) {
			System.err.println("Server exception: " + e.toString());
			e.printStackTrace();
		}
	}
}