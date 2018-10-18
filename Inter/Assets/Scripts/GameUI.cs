using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider Vida, AmmoAmount;

    
    
    vidaPlayer vidaPlayerScript;
    metranca Metralhadora;
	// Use this for initialization
	void Start () {

        vidaPlayerScript = this.GetComponent<vidaPlayer>();
        Metralhadora = this.GetComponent<metranca>();

        Vida.GetComponent<Slider>();


        AmmoAmount.GetComponent<Slider>();

   
        Vida.maxValue = vidaPlayerScript.health;


        AmmoAmount.maxValue = Metralhadora.tirosMaximos;



	}
	
	// Update is called once per frame
	void Update () {
        

        Vida.value = vidaPlayer.vidaAtual;


        AmmoAmount.value = metranca.tirosRestantes;


        if (AmmoAmount.value == 0)
        {

            AmmoAmount.gameObject.SetActive(false);

        }

        else {
            AmmoAmount.gameObject.SetActive(true);
        }

        if (Vida.value == 0)
        {

            Vida.gameObject.SetActive(false);

        }


    }
}
