using UnityEngine;
using System.Collections;

public class ButtonHowToPlay : MonoBehaviour {
    public GameObject HowToPlayCamera;
	
    void OnMouseDown()
    {
        HowToPlayCamera.SetActive(true);
    }
}
