using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {
	public float fuerzaSalto = 100f;
	public Transform comprobadorSuelo;
	public LayerMask mascaraSuelo;
	private float comprobadorRadio = 0.07f;
	public bool enSuelo = true;
	private bool dobleSalto = false;
	private Animator animator;
    private bool corriendo = false;
    public float velocidad = 1f;

	void Awake(){
		animator = GetComponent<Animator> ();
        Time.timeScale = 1f;
		}

	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "NuevoNivel");
        if (EstadoJuego.estadoJuego.level >= 10) { 
            int VelocityIncrement =((int)EstadoJuego.estadoJuego.level / 10) * 10;
            velocidad = 7 + (((int)EstadoJuego.estadoJuego.level % VelocityIncrement) + 3);
        }
        else
            velocidad = 7 + (int)EstadoJuego.estadoJuego.level;
	}

    void NuevoNivel(){
        if (EstadoJuego.estadoJuego.level >= 10)
        {
            int VelocityIncrement = ((int)EstadoJuego.estadoJuego.level / 10) * 10;
            velocidad = 7 +( ((int)EstadoJuego.estadoJuego.level % VelocityIncrement) + 3);
        }
        else
            velocidad = 7 + (int)EstadoJuego.estadoJuego.level;
    }

	void FixedUpdate() {
        if (corriendo){
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
        }
        animator.SetFloat("VelX", GetComponent<Rigidbody2D>().velocity.x);
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool ("IsGrounded", enSuelo);
		if (enSuelo) {  
			dobleSalto = false;
		}
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (corriendo){
                //que salte si puede 
                if (enSuelo || !dobleSalto)  {
			        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
			        if (!dobleSalto &&  !enSuelo) {
				        dobleSalto=true;
			        }		
		        } 
            }
            else{
                corriendo = true;
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
            }
                
        }
    }
	
}
