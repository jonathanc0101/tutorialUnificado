using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeManagerSingleton : MonoBehaviour
{
    private int cantidadDeEscenas;
    #region singleton

    private static LevelChangeManagerSingleton instance;

    public static LevelChangeManagerSingleton GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    #endregion

    void Start()
    {
        cantidadDeEscenas = SceneManager.sceneCountInBuildSettings;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CargarEscenaSiguiente();
        }

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            CargarEscenaAnterior();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RecargarEscena();
        }
    }

    public void CargarEscenaSiguiente()
    {
        SceneManager.LoadScene((EscenaActual() + 1 + cantidadDeEscenas) % cantidadDeEscenas  );
    }

    public void CargarEscenaAnterior()
    {
        SceneManager.LoadScene((EscenaActual() - 1 + cantidadDeEscenas) % cantidadDeEscenas);
    }

    public void RecargarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    int EscenaActual()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
