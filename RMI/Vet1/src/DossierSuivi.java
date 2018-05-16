import java.io.Serializable;

public class DossierSuivi implements Serializable{

	String suivi;
	
	public String getSuivi() {
		return suivi;
	}

	public void setSuivi(String suivi) {
		this.suivi = suivi;
	}

	public DossierSuivi(String s) {
		this.suivi = s;
	}
}
