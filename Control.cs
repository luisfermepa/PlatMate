using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour{

    public  GameObject Confi;
    //public  GameObject Apoyar;
    protected bool configurando;
    //protected bool apoyando;

    void Update(){
        /*if(!apoyando && Input.GetKeyDown(KeyCode.A)){
            abrirApoyar();
        } else if(apoyando && Input.GetKeyDown(KeyCode.A)){
            cerrarApoyar();
        }*/
        if(!configurando && Input.GetKeyDown(KeyCode.C)){
            abrirConf();
        } else if(configurando && Input.GetKeyDown(KeyCode.C)){
            cerrarConf();
        }
    }
    
    public void irAMenu(){
        SceneManager.LoadScene(0);
    }

    public void irANivel1(){
        SceneManager.LoadScene(1);
    }

    public void irACreditos(){
        SceneManager.LoadScene(2);
    }

    public void salir(){
        Application.Quit();
    }

    public void abrirConf(){
        configurando=true;
        Confi.SetActive(true);
        Time.timeScale = 0f;
    }

    public void cerrarConf(){
        configurando=false;
        Confi.SetActive(false);
        Time.timeScale = 1f;
    }

    public void goURL(string URL){
        Application.OpenURL(URL);
    }

    /*public void abrirApoyar(){
        apoyando=true;
        Apoyar.SetActive(true);
        Time.timeScale = 0f;
    }

    public void cerrarApoyar(){
        apoyando=false;
        Apoyar.SetActive(false);
        Time.timeScale = 1f;
    }*/

}