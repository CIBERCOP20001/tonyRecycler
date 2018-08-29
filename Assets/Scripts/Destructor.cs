using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Piso"){
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x + 30, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
        }
        else { 
            Destroy(other.gameObject);
        }
    }
        
}
