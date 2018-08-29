using UnityEngine;
using System.Collections;

public class Plastico : MonoBehaviour {

    //private bool haColisionadoConJugador = false;
    public int puntosAIncrementar = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosAIncrementar);
           Destroy(gameObject);
        }
        
    }
}
