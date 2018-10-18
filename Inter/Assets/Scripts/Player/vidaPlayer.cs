using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaPlayer : MonoBehaviour {

    public float health;
   public static float vidaAtual;


	// Use this for initialization
	void Start () {
        vidaAtual = health;
	}
	
	// Update is called once per frame
	void Update () {

        if (vidaAtual <= 0)
        {
            morto();

        }


       // Debug.Log(vidaAtual);

        if (vidaAtual > health)
        {
            vidaAtual = health;

        }

        if (vidaAtual <= 0)
        {
            vidaAtual = 0;

        }

	}

    public void takeDamage( float amount)
    {
        vidaAtual -= amount;

       

    }

    void morto()
    {

        
        Time.timeScale = 0;

    }
}
