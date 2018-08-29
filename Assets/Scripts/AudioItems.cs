using UnityEngine;
using System.Collections;

public class AudioItems : MonoBehaviour {
    public AudioClip Background;
    public AudioClip GetItem;
    public AudioClip Dead;
    public AudioClip LevelCompleted;
    private AudioSource FuenteAudio;
    private AudioSource AudioBackground;
    public GameObject GetItemEffect2;
    public GameObject LevelFinished;
    public GameObject DeadEffect;
    public GameObject FinishLevelEffect;
	
    // Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        NotificationCenter.DefaultCenter().AddObserver(this, "NuevoNivel");
        FuenteAudio = gameObject.AddComponent<AudioSource>();
        AudioBackground = gameObject.AddComponent<AudioSource>();
        AudioBackground.PlayOneShot(Background);
	}

    void PersonajeHaMuerto()
    {
        AudioBackground.Stop();
        FuenteAudio.PlayOneShot(Dead);
    }

    void NuevoNivel()
    {
        AudioBackground.Stop();
        FuenteAudio.PlayOneShot(LevelCompleted);
    }

    void IncrementarPuntos(Notification notification){
        FuenteAudio.PlayOneShot(GetItem);
        Vector3 Pos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject go = Instantiate( GetItemEffect2, Pos, Quaternion.identity) as GameObject;
        Destroy(go, 1);
    }
  
}
