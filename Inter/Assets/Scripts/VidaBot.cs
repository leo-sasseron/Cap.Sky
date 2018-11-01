using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBot : MonoBehaviour {

    Collider coll;

    public float health, vidaParaLigarSegEstado;
    public GameObject ObjetoADesligar;
    public GameObject estado1, estado2;
    public bool temOutroEStado, letal, Tronco, soMorre, NdaPraMatar;
   public ControlaCoisasBot CCB;
    Rigidbody rb;

    
    public float vidaAtual;

   public bool debug;

    // Use this for initialization
    void Start()
    {
        
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;


        if (temOutroEStado == false)
        {
           estado1 = ObjetoADesligar ;
            estado2 = estado1;
        }

        else {
            ObjetoADesligar = estado2;

                }


        if (rb != null) { rb.GetComponent<Rigidbody>(); }
        

        //CCB.GetComponent<ControlaCoisasBot>();
        


        vidaAtual = health;
    }

    // Update is called once per frame
    void Update()
    {
     
       

        if (temOutroEStado)
        {
            if (vidaAtual < vidaParaLigarSegEstado && temOutroEStado)
            {
                estado1.SetActive(false);
                estado2.SetActive(true);


            }


        }



        if (CCB.morto == true || soMorre)
        {
           
            morto();
          
        }

       


      

        if (CCB.morto && rb != null)
        {
            
            this.rb.isKinematic = false;

        }


        // if (debug) { print(vidaAtual); }


        if (vidaAtual >= health)
        {
            vidaAtual = health;

        }

        if (vidaAtual <= 0)
        {
            vidaAtual = 0;

        }

    }

    public void takeDamage(float amount)
    {

        if (NdaPraMatar == false) { 
        vidaAtual -= amount;

       

        


        if (vidaAtual <= 0)
        {

         
           
            morto();

        }
        }

    }
  
    void morto()
    {




        

        transform.SetParent(null);



        for ( int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).SetParent(null);
       
            


        }
     

       

        if (letal)
        {
           
            CCB.morto = true;
            
            
        }

        
     
        if (rb != null) { rb.isKinematic = false; }


       
    }
}
