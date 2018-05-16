
import java.rmi.Remote;
import java.rmi.RemoteException;

public interface Animal extends Remote  {
	
	
	String afficher() throws RemoteException;
	
	String getNom() throws RemoteException;
	
	Espece getEspece() throws RemoteException;
	
	String getRace() throws RemoteException;
	
	DossierSuivi getDossierSuivi() throws RemoteException;
	
	//String getEspeceNom() throws RemoteException;
	
}
