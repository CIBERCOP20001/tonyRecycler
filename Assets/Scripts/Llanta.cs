using UnityEngine;
using System.Collections;
using System.Threading;

public class Llanta : MonoBehaviour {

    //private bool CollisionoPlayer = false;
    public GameObject DeadEffect;
	// Use this for initialization
	
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Player"){
            Vector3 Pos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
            GameObject go = Instantiate(DeadEffect, Pos, Quaternion.identity) as GameObject;
            Destroy(go, 1);
            Time.timeScale = 0.3f;
            GameObject personaje = GameObject.Find("Personaje");
            personaje.SetActive(false);
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
        }
    }

  
    
}
