using UnityEngine;
using System.Collections;

public class MainScreeButton : MonoBehaviour {

    void OnMouseDown()
    {
        //Debug.Log("cargando!");
        Application.LoadLevel("Escena1");
    }
}
