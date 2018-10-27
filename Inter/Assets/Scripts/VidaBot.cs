using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBot : MonoBehaviour {

  

    public float health, vidaParaLigarSegEstado;
    public GameObject ObjetoADesligar;
    public GameObject estado1, estado2;
    public bool temOutroEStado, letal;
   public ControlaCoisasBot CCB;

    Rigidbody rb;

    [HideInInspector]
    public float vidaAtual;

   public bool debug;

    // Use this for initialization
    void Start()
    {

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
        if (CCB.morto && rb != null)
        {
            Debug.Log(this.rb.isKinematic);
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
        vidaAtual -= amount;

        if (temOutroEStado)
        {
            if (vidaAtual < vidaParaLigarSegEstado && temOutroEStado)
            {
                estado1.SetActive(false);
                estado2.SetActive(true);


            }


        }


        if (vidaAtual <= 0)
        {

         
           
            morto();

        }

    }

    void morto()
    {
        

        if (letal)
        {

            CCB.morto = true;
            if (rb != null) { rb.isKinematic = false; }
            
        }

        ObjetoADesligar.gameObject.SetActive(false);
        this.gameObject.SetActive(false);

    }
}
