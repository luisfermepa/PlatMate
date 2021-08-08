using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ocultarMostrar : MonoBehaviour{
    
    public GameObject VidasImg3, VidasImg2, VidasImg1;

    void Update(){
        if(Jugador.vidas==3){
            VidasImg1.SetActive(false);
            VidasImg2.SetActive(false);
            VidasImg3.SetActive(true);
        } else if (Jugador.vidas==2){
            VidasImg1.SetActive(false);
            VidasImg2.SetActive(true);
            VidasImg3.SetActive(false);
        } else if (Jugador.vidas==1){
            VidasImg1.SetActive(true);
            VidasImg2.SetActive(false);
            VidasImg3.SetActive(false);
        }
    }
}