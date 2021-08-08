using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour{

    public float velocidad, velocidadMax, fuerzaSalto, friccionSuelo;
    public bool colPies=false;
    public Text vidasTxt, resultado1P1,resultado2P1, resultado3P1, resultado1P2, resultado2P2, resultado3P2, resultado1P3,
            resultado2P3, resultado3P3, valor1Pregunta1, valor2Pregunta1, valor1Pregunta2, valor2Pregunta2, valor1Pregunta3, 
            valor2Pregunta3;
    public GameObject Correcto1P1, Correcto2P1, Correcto3P1, Correcto1P2, Correcto2P2, Correcto3P2, Correcto1P3, Correcto2P3,
    Correcto3P3, Incorrecto1P1, Incorrecto2P1, Incorrecto3P1, Incorrecto1P2, Incorrecto2P2, Incorrecto3P2, Incorrecto1P3, 
    Incorrecto2P3, Incorrecto3P3;

    private Rigidbody2D rPlayer;
    private float h;
    private bool miraDerecha;
    private float velocidadReal;
    private int cantidadSaltos;
    private Animator aJugador;
    public static int vidas;

    void Awake(){
        int resultado1P1int, resultado2P1int, resultado3P1int, resultado1P2int, resultado2P2int, resultado3P2int, resultado1P3int,
        resultado2P3int, resultado3P3int, valor1Pregunta1int, valor2Pregunta1int, valor1Pregunta2int, valor2Pregunta2int, 
        valor1Pregunta3int, valor2Pregunta3int, resultadoCorrecto1, resultadoCorrecto2, resultadoCorrecto3, cajaCorrecta1, cajaCorrecta2, 
        cajaCorrecta3;

        valor1Pregunta1int=Random.Range(0,12);
        valor2Pregunta1int=Random.Range(0,12);
        valor1Pregunta2int=Random.Range(0,12);
        valor2Pregunta2int=Random.Range(0,12);
        valor1Pregunta3int=Random.Range(0,12);
        valor2Pregunta3int=Random.Range(0,12);

        valor1Pregunta1.text=valor1Pregunta1int.ToString();
        valor2Pregunta1.text=valor2Pregunta1int.ToString();
        valor1Pregunta2.text=valor1Pregunta2int.ToString();
        valor2Pregunta2.text=valor2Pregunta2int.ToString();
        valor1Pregunta3.text=valor1Pregunta3int.ToString();
        valor2Pregunta3.text=valor2Pregunta3int.ToString();
        
        resultadoCorrecto1=valor1Pregunta1int*valor2Pregunta1int;
        resultadoCorrecto2=valor1Pregunta2int*valor2Pregunta2int;
        resultadoCorrecto3=valor1Pregunta3int*valor2Pregunta3int;
        
        cajaCorrecta1=Random.Range(0,2);
        cajaCorrecta2=Random.Range(0,2);
        cajaCorrecta3=Random.Range(0,2);

        if(cajaCorrecta1==0){
            resultado1P1int=resultadoCorrecto1;
            resultado1P1.text=resultado1P1int.ToString();
            Correcto1P1.SetActive(true);
            Correcto2P1.SetActive(false);
            Correcto3P1.SetActive(false);
            Incorrecto1P1.SetActive(false);
            Incorrecto2P1.SetActive(true);
            Incorrecto3P1.SetActive(true);
        } else if(cajaCorrecta1==1){
            resultado2P1int=resultadoCorrecto1;
            resultado2P1.text=resultado2P1int.ToString();
            Correcto1P1.SetActive(false);
            Correcto2P1.SetActive(true);
            Correcto3P1.SetActive(false);
            Incorrecto1P1.SetActive(true);
            Incorrecto2P1.SetActive(false);
            Incorrecto3P1.SetActive(true);
        } else if(cajaCorrecta1==2){
            resultado3P1int=resultadoCorrecto1;
            resultado3P1.text=resultado3P1int.ToString();
            Correcto1P1.SetActive(false);
            Correcto2P1.SetActive(false);
            Correcto3P1.SetActive(true);
            Incorrecto1P1.SetActive(true);
            Incorrecto2P1.SetActive(true);
            Incorrecto3P1.SetActive(false);
        }
        if(cajaCorrecta2==0){
            resultado1P2int=resultadoCorrecto2;
            resultado1P2.text=resultado1P2int.ToString();
            Correcto1P2.SetActive(true);
            Correcto2P2.SetActive(false);
            Correcto3P2.SetActive(false);
            Incorrecto1P2.SetActive(false);
            Incorrecto2P2.SetActive(true);
            Incorrecto3P2.SetActive(true);
        } else if(cajaCorrecta2==1){
            resultado2P2int=resultadoCorrecto2;
            resultado2P2.text=resultado2P2int.ToString();
            Correcto1P2.SetActive(false);
            Correcto2P2.SetActive(true);
            Correcto3P2.SetActive(false);
            Incorrecto1P2.SetActive(true);
            Incorrecto2P2.SetActive(false);
            Incorrecto3P2.SetActive(true);
        } else if(cajaCorrecta2==2){
            resultado3P2int=resultadoCorrecto2;
            resultado3P2.text=resultado3P2int.ToString();
            Correcto1P2.SetActive(false);
            Correcto2P2.SetActive(false);
            Correcto3P2.SetActive(true);
            Incorrecto1P2.SetActive(true);
            Incorrecto2P2.SetActive(true);
            Incorrecto3P2.SetActive(false);
        }
        if(cajaCorrecta3==0){
            resultado1P3int=resultadoCorrecto3;
            resultado1P3.text=resultado1P3int.ToString();
            Correcto1P3.SetActive(true);
            Correcto2P3.SetActive(false);
            Correcto3P3.SetActive(false);
            Incorrecto1P3.SetActive(false);
            Incorrecto2P3.SetActive(true);
            Incorrecto3P3.SetActive(true);
        } else if(cajaCorrecta3==1){
            resultado2P3int=resultadoCorrecto3;
            resultado2P3.text=resultado2P3int.ToString();
            Correcto1P3.SetActive(false);
            Correcto2P3.SetActive(true);
            Correcto3P3.SetActive(false);
            Incorrecto1P3.SetActive(true);
            Incorrecto2P3.SetActive(false);
            Incorrecto3P3.SetActive(true);
        } else if(cajaCorrecta3==2){
            resultado3P3int=resultadoCorrecto3;
            resultado3P3.text=resultado3P3int.ToString();
            Correcto1P3.SetActive(false);
            Correcto2P3.SetActive(false);
            Correcto3P3.SetActive(true);
            Incorrecto1P3.SetActive(true);
            Incorrecto2P3.SetActive(true);
            Incorrecto3P3.SetActive(false);
        }
    }

    void Start(){
        cantidadSaltos=0;
        rPlayer=GetComponent<Rigidbody2D>();
        aJugador=GetComponent<Animator>();
        vidas=3;
    }

    void Update(){
        girarJugador(h);
        aJugador.SetFloat("velocidadX", Mathf.Abs(rPlayer.velocity.x));
        aJugador.SetFloat("velocidadY", rPlayer.velocity.y);
        aJugador.SetBool("tocaSuelo", checkGround.colPies);
        colPies=checkGround.colPies;
        if(colPies){
            cantidadSaltos=0;
        }
        if((Input.GetButtonDown("Jump")) && cantidadSaltos<2){
            checkGround.colPies=false;
            cantidadSaltos++;
            rPlayer.velocity=new Vector2(rPlayer.velocity.x, 0f);
            rPlayer.AddForce(new Vector2(0,fuerzaSalto), ForceMode2D.Impulse);
        }
        if(vidas<=0){
            transform.position=new Vector3(0f,-1f,0f);
            vidas=3;
        }
        vidasTxt.text=vidas.ToString();
        
    }

    void FixedUpdate(){
        h=Input.GetAxisRaw("Horizontal");
        rPlayer.AddForce(Vector2.right*velocidad*h);
        velocidadReal=Mathf.Clamp(rPlayer.velocity.x, -velocidadMax, velocidadMax);
        rPlayer.velocity=new Vector2(velocidadReal, rPlayer.velocity.y);
        if(h==0){
            Vector3 velocidadArreglada=rPlayer.velocity;
            velocidadArreglada.x*=friccionSuelo;
            rPlayer.velocity=velocidadArreglada;
        }
    }

    void girarJugador(float horizontal){
        if((horizontal>0 && miraDerecha) || (horizontal<0 && !miraDerecha)){
            miraDerecha=!miraDerecha;
            Vector3 escalaGiro = transform.localScale;
            escalaGiro.x=escalaGiro.x*-1;
            transform.localScale=escalaGiro;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Correcto"){
            checkGround.colPies=true;
        }
        if(collision.gameObject.tag=="Incorrecto"){
            vidas--;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag=="Correcto"){
            checkGround.colPies=false;
        }
    }

}