using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour{

    public GameObject aSeguir;
    private float posX, posY;

    void Start(){
        
    }

    void Update(){
        float posX=aSeguir.transform.position.x;
        float posY=aSeguir.transform.position.y;
        transform.position=new Vector3 (posX, posY, transform.position.z);
    }

}