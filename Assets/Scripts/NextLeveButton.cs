using UnityEngine;
using System.Collections;

public class NextLeveButton : MonoBehaviour {
    public GameObject CameraMain;
    public GameObject CameraNextLevel;

    void OnMouseDown()
    {
        Time.timeScale = 1;
        CameraMain.SetActive(true);
        CameraNextLevel.SetActive(false);
    }
}
