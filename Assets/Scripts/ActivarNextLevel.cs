using UnityEngine;
using System.Collections;

public class ActivarNextLevel : MonoBehaviour {
    public GameObject CameraNextLevel;
    public GameObject CameraGameOver;
	// Use this for initialization
	void Start () {
	 NotificationCenter.DefaultCenter().AddObserver(this, "NuevoNivel");
     NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
	}

    void PersonajeHaMuerto()
    {
        CameraGameOver.SetActive(true);
    }

    void NuevoNivel()
    {
        Time.timeScale = 0;
        CameraNextLevel.SetActive(true);
    }

	void Update () {
	
	}
}
