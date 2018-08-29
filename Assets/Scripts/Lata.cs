using UnityEngine;
using System.Collections;

public class Lata : MonoBehaviour {
    //private bool haColisionadoConJugador = false;
    public int puntosAIncrementarLata = 5;

    void OnTriggerEnter2D(Collider2D collider){
        //Debug.Log("colision con :" + collider.tag);
        if (collider.tag == "Player"){
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosAIncrementarLata);
            Destroy(gameObject);
        }
    }
}

