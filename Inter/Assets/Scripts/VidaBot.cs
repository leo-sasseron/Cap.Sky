using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBot : MonoBehaviour {

  

    public float health;


    [HideInInspector]
    public float vidaAtual;

   public bool debug;

    // Use this for initialization
    void Start()
    {
       
        vidaAtual = health;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (vidaAtual <= 0)
        {

         
           
            morto();

        }

    }

    void morto()
    {


        this.gameObject.SetActive(false);

    }
}
