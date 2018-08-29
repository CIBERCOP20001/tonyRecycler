using UnityEngine;
using System.Collections;

public class ValoresGameOver : MonoBehaviour {
    public TextMesh total;
    public TextMesh record;
    public Puntuacion puntuacion;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        if ((EstadoJuego.estadoJuego.puntuacionUltimoNivel + puntuacion.LevelPuntuacion) > EstadoJuego.estadoJuego.puntuacionMaxima)
            record.text = "NEW ";
        else
            record.text = "";
     
        total.text = "TOTAL : " +  (EstadoJuego.estadoJuego.puntuacionUltimoNivel +  puntuacion.LevelPuntuacion).ToString();
        record.text += "RECORD : " + EstadoJuego.estadoJuego.puntuacionMaxima.ToString();
             

    }
}
