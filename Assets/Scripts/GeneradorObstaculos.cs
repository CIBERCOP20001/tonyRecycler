using UnityEngine;
using System.Collections;

public class GeneradorObstaculos : MonoBehaviour {

    public GameObject[] obj;
    private GameObject Tire;
    private GameObject WaterTake;
    private GameObject Fire;
    private bool Corriendo = false;
    private float tiempoMin = 3f;
    private float tiempoMax = 7f;
    // Use this for initialization
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
    }

    void PersonajeEmpiezaACorrer(Notification notification)
    {
        Corriendo = true;
        GenerarItems();
        GenerarWaterTake();
        GenerarFire();
    }

    private void GenerarWaterTake()
    {
        if (Corriendo)
        {
            if (EstadoJuego.estadoJuego.level >= 10)
            {
                Vector3 position1 = new Vector3(transform.position.x,
                                                -3.486165f,
                                                0);
                WaterTake = (GameObject)Instantiate(obj[1], position1, Quaternion.identity);
                Invoke("GenerarWaterTake", Random.Range(tiempoMin + 10, tiempoMax + 10));
            }
        }
    }

    private void GenerarFire()
    {
        if (Corriendo)
        {
            if (EstadoJuego.estadoJuego.level >= 20)
            {
                Vector3 position1 = new Vector3(transform.position.x + Random.Range(5,15) ,
                                                -4.8f,
                                                0);
                Fire = (GameObject)Instantiate(obj[2], position1, Quaternion.identity);
                Invoke("GenerarFire", Random.Range(tiempoMin + 15, tiempoMax + 15));
            }
        }
    }

    void PersonajeHaMuerto() {
        Corriendo = false;
    }
    
    void GenerarItems()
    {
        if (Corriendo)
        {
            Vector3 position = new Vector3(transform.position.x,
                                            transform.position.y + Random.Range(-6, 5),
                                            transform.position.z);
            Tire = (GameObject)Instantiate(obj[0], position, Quaternion.identity);
            Tire.GetComponent<Rigidbody2D>().AddForce(transform.forward * 5000f);
            Invoke("GenerarItems", Random.Range(tiempoMin, tiempoMax));
        }

    }
}
