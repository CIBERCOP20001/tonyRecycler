using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour
{
    private int TotalPuntuacion = 0;
    public int LevelPuntuacion = 0;
    private int TotalPuntuacionVidrio = 0;
    private int LevelPuntuacionVidrio = 0;
    private int TotalPuntuacionLata = 0;
    private int LevelPuntuacionLata = 0;
    private int TotalPuntuacionPlastico = 0;
    private int LevelPuntuacionPlastico = 0;
    public TextMesh marcador;
    public TextMesh plasticoMarcador;
    public TextMesh vidrioMarcador;
    public TextMesh lataMarcador;
    public TextMesh LevelText;
    public TextMesh TotalGame;
    private int level = 1;
    private int PuntosAcumulados = 50;
    private int PuntosPorAlcanzar = 50;


    // Use this for initialization
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        NotificationCenter.DefaultCenter().AddObserver(this, "NuevoNivel");
        PuntosPorAlcanzar = 30 + (10 *  EstadoJuego.estadoJuego.level) ;
        //PuntosPorAlcanzar = 2 + (2 * EstadoJuego.estadoJuego.level);// for testing
        ActualizarMarcador();
    }

    void PersonajeHaMuerto()
    {
        //Debug.Log("personajehamuerto");
        if ((EstadoJuego.estadoJuego.puntuacionUltimoNivel + TotalPuntuacion) > EstadoJuego.estadoJuego.puntuacionMaxima)
        {

            EstadoJuego.estadoJuego.level = ((int)EstadoJuego.estadoJuego.level);
            EstadoJuego.estadoJuego.puntuacionMaxima = EstadoJuego.estadoJuego.puntuacionUltimoNivel + TotalPuntuacion;
            //EstadoJuego.estadoJuego.puntuacionUltimoNivel = EstadoJuego.estadoJuego.puntuacionUltimoNivel + TotalPuntuacion;
            EstadoJuego.estadoJuego.Guardar();
        }
    }

    void NuevoNivel()
    {
        if (LevelPuntuacion > 0)
        {
            ////PuntosPorAlcanzar = PuntosPorAlcanzar + 20;
            LevelPuntuacionLata = 0;
            LevelPuntuacionPlastico = 0;
            LevelPuntuacionVidrio = 0;
            LevelPuntuacion = 0;

            if ((EstadoJuego.estadoJuego.puntuacionUltimoNivel + TotalPuntuacion) > EstadoJuego.estadoJuego.puntuacionMaxima)
            {
                EstadoJuego.estadoJuego.level = ((int)EstadoJuego.estadoJuego.level) + 1;
                EstadoJuego.estadoJuego.puntuacionMaxima = EstadoJuego.estadoJuego.puntuacionUltimoNivel +  TotalPuntuacion;
                EstadoJuego.estadoJuego.puntuacionUltimoNivel = EstadoJuego.estadoJuego.puntuacionUltimoNivel  + TotalPuntuacion;
                EstadoJuego.estadoJuego.Guardar();
            }
            else
            {
                EstadoJuego.estadoJuego.level = ((int)EstadoJuego.estadoJuego.level + 1);
                EstadoJuego.estadoJuego.puntuacionMaxima = (int)EstadoJuego.estadoJuego.puntuacionMaxima;
                EstadoJuego.estadoJuego.puntuacionUltimoNivel = EstadoJuego.estadoJuego.puntuacionUltimoNivel  + TotalPuntuacion;
                EstadoJuego.estadoJuego.Guardar();
            }
        }
    }

    void IncrementarPuntos(Notification notification)
    {
        int puntosAIncrementar = (int)notification.data;
        if (notification.sender.ToString() == "Vidrio(Clone) (Vidrio)")
        {
            LevelPuntuacionVidrio += 1;
            TotalPuntuacionVidrio += 1;
        }
        else if (notification.sender.ToString() == "Plastico(Clone) (Plastico)")
        {
            LevelPuntuacionPlastico += 1;
            TotalPuntuacionPlastico += 1;
        }
        else
        {
            LevelPuntuacionLata += 1;
            TotalPuntuacionLata += 1;
        }
        LevelPuntuacion += puntosAIncrementar;
        TotalPuntuacion += puntosAIncrementar;

        if (LevelPuntuacion >= PuntosPorAlcanzar)
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "NuevoNivel");
        }
        ActualizarMarcador();
    }

    void ActualizarMarcador()
    {
        marcador.text = LevelPuntuacion.ToString() + "/" + PuntosPorAlcanzar.ToString();
        plasticoMarcador.text = LevelPuntuacionPlastico.ToString();
        vidrioMarcador.text = LevelPuntuacionVidrio.ToString();
        lataMarcador.text = LevelPuntuacionLata.ToString();
        LevelText.text = "Level " + (EstadoJuego.estadoJuego.level).ToString();
        TotalGame.text = "Points " + (EstadoJuego.estadoJuego.puntuacionUltimoNivel + LevelPuntuacion).ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }

























}
