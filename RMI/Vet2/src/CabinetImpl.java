import java.io.Serializable;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.List;

public class CabinetImpl implements CabinetInterface, Serializable{

	String nom;
	
	
	List<AnimalImpl> patients;
	
	public CabinetImpl(String nom) {
		this.nom = nom;
		patients = new ArrayList<AnimalImpl>();
	}

	@Override
	public AnimalImpl rechercheAnimal(String nom) {
		AnimalImpl a = null;
		for (AnimalImpl animalImpl : patients) {
			try {
				if(animalImpl.getNom() == nom)
					a = animalImpl;
			} catch (RemoteException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		return a;
	}

	@Override
	public void addAnimal(AnimalImpl animal) {
		// TODO Auto-generated method stub
		this.patients.add(animal);
	}

	@Override
	public String afficher() throws RemoteException {
		return "le nom du cabinet est: " + this.nom;
	}

	@Override
	public List<AnimalImpl> getPatients() {
		// TODO Auto-generated method stub
		return this.patients;
	}

	@Override
	public String getCabinetNom() throws RemoteException {
		return this.nom;
	}
	
}
