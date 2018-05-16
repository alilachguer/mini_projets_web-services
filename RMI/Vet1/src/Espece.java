import java.io.Serializable;

public class Espece implements Serializable{
	
	String nomEspece;
	int dureeVieMoyenne;
	
	public Espece(String nom, int dv) {
		this.nomEspece = nom;
		this.dureeVieMoyenne = dv;
	}
	
	public String getNomEspece() {
		return nomEspece;
	}

	public void setNomEspece(String nomEspece) {
		this.nomEspece = nomEspece;
	}

	public int getDureeVieMoyenne() {
		return dureeVieMoyenne;
	}

	public void setDureeVieMoyenne(int dureeVieMoyenne) {
		this.dureeVieMoyenne = dureeVieMoyenne;
	}

	@Override
	public String toString() {
		// TODO Auto-generated method stub
		return this.nomEspece + ", duree vie moyenne: " + dureeVieMoyenne;
	}

}
