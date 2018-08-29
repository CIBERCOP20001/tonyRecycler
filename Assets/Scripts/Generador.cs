using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {
	public GameObject piso;
	public float tiempoMin = 1f;
	public float tiempoMax = 2f;
	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
	}

    void PersonajeEmpiezaACorrer(Notification notification)
    {
    }

	void Generar(){
	}
	
}
