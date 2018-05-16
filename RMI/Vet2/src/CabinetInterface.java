import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.List;

public interface CabinetInterface extends Remote{

	Animal rechercheAnimal(String nom) throws RemoteException;
	
	void addAnimal(AnimalImpl animal) throws RemoteException;
	
	String afficher() throws RemoteException;
	
	List<AnimalImpl> getPatients() throws RemoteException;
	
	String getCabinetNom() throws RemoteException;
}
