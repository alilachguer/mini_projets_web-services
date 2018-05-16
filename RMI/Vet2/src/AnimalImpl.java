

import java.io.Serializable;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class AnimalImpl implements Animal, Serializable {
	String nom;
	String race;
	Espece espece;
	DossierSuivi dossierSuivi;

	public AnimalImpl(String nom, String race, Espece espece) throws RemoteException {
		this.nom = nom;
		this.race = race;
		this.espece = espece;
	}
	
	public Espece getEspece() throws RemoteException{
		return this.espece;
	}
	
	public String getEspeceNom() throws RemoteException{
		return this.espece.getNomEspece();
	}

	@Override
	public DossierSuivi getDossierSuivi() throws RemoteException {
		return this.dossierSuivi;
	}

	public String getRace() throws RemoteException{
		return race;
	}

	public void setEspece(Espece espece) {
		this.espece = espece;
	}


	@Override
	public String getNom() throws RemoteException{
		return nom;
	}

	
	@Override
	public String afficher() throws RemoteException {
		return "nom animal: " + this.nom + "\n--race: " + this.race + "\n--espece: " + this.espece;	
		
	}}
	
	
	
	
