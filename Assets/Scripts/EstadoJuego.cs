using UnityEngine;
using System.Collections;
using Parse;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Runtime.Serialization;
using System.Reflection;
using System.Threading;

public class EstadoJuego : MonoBehaviour {
    public int puntuacionMaxima = 0;
    public int level = 1;
    public int puntuacionUltimoNivel = 0;
    public static EstadoJuego estadoJuego;
    private string rutaArchivo;

    void Awake()
    {

        ParseClient.Initialize("fFVlg4IOqE6znGsI8ZazKbLLQo7Mq0bj9ouGyvGV", "tSynwHRZQK5c7Ay1fVMcOoJAvkUjspmeO79LY5Fi");

        rutaArchivo = Application.persistentDataPath + "/datos.dat";
        if (estadoJuego == null)
        {
            estadoJuego = this;
            DontDestroyOnLoad(gameObject);
           
        }
        else if (estadoJuego != this)
        {
            
            Destroy(gameObject);
        }
        Cargar();
        int lastPM = puntuacionMaxima;
        puntuacionMaxima = lastPM;
        //puntuacionMaxima = 0;
        level = 1;
        Guardar();
        
    }
	// Use this for initialization
	void Start () {
       

        Cargar();
	}


    //public async void testing()
    //{

    //    var testObject = new ParseObject("TestObject");
    //    testObject["foo"] = "bar";
    //    await testObject.SaveAsync();
    //}
	
    // Update is called once per frame

	void Update () {
	
	}

    public void Guardar()
    {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        System.IO.FileStream file = new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Create);
        DatosAGuardar datos = new DatosAGuardar();
        datos.puntuacionMaxima = puntuacionMaxima;
        datos.Level = level;
        datos.puntuacionUltimoNivel = 0;
        bf.Serialize(file, datos);
        file.Close();
    }

    void Cargar()
    {
        if (File.Exists(rutaArchivo)) {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        System.IO.FileStream file = new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Open);
        DatosAGuardar datos = (DatosAGuardar)bf.Deserialize(file);
        puntuacionMaxima = datos.puntuacionMaxima;
        level = datos.Level;
        puntuacionUltimoNivel = datos.puntuacionUltimoNivel;
        file.Close();
        }
        else
        {
            puntuacionMaxima = 0;
        }
    }
}
[Serializable]
class DatosAGuardar  
{
    public int puntuacionMaxima;
    public int Level;
    public int puntuacionUltimoNivel;
    
}