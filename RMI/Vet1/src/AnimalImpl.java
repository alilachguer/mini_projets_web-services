

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class AnimalImpl implements Animal {
	String nom;
	String race;
	Espece espece;
	DossierSuivi dossierSuivi;

	

	public AnimalImpl(String nom, String race, Espece espece) throws RemoteException {
		this.nom = nom;
		this.race = race;
		this.espece = espece;
		this.dossierSuivi = dossierSuivi = new DossierSuivi("dossier suivi Animal non modifie par client");
	}
	
	public Espece getEspece() throws RemoteException{
		return this.espece;
	}
	
	public String getEspeceNom() throws RemoteException{
		return this.espece.getNomEspece();
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
		return "nom animal: " + this.nom + "\nrace: " + this.race + "\nespece: " + this.espece;	
		
	}

	@Override
	public DossierSuivi getDossierSuivi() throws RemoteException {
		return this.dossierSuivi;
	}
	
}
	
	
	
	
