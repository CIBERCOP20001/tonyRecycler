using UnityEngine;
using System.Collections;

public class GeneradorItems : MonoBehaviour {

	public GameObject[] obj;
	public float tiempoMin = 1f;
	public float tiempoMax = 2f;
    private bool Corriendo = false;
	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
	}

    void PersonajeEmpiezaACorrer(Notification notification)
    {
        Corriendo = true;
        GenerarItems();
    }

    void PersonajeHaMuerto()
    {
        Corriendo = false;
    }

	void GenerarItems(){
        if (Corriendo) { 
		Vector3 position = new Vector3 (transform.position.x + Random.Range (0, 6), 
		                                transform.position.y +  Random.Range (0, 6), 
		                                transform.position.z);

		Instantiate (obj[Random.Range (0, obj.Length)], position, Quaternion.identity);
        Invoke ("GenerarItems", Random.Range(1,2));
        }
	}
}
