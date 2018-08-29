using UnityEngine;
using System.Collections;

public class Vidrio : MonoBehaviour {

    //private bool haColisionadoConJugador = false;
    public int puntosAIncrementarVidrio = 3;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosAIncrementarVidrio);
             Destroy(gameObject);
        }
       
    }
}
