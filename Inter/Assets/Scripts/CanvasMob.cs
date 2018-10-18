using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMob : MonoBehaviour {

    public Slider slider;

    VidaBot vb;

    // Use this for initialization

       
    void Start()
    {

       

        vb = GetComponent<VidaBot>();

        slider = GetComponent<Slider>();
        slider.maxValue = vb.health;

    }

    // Update is called once per frame
    void Update()
    {

        slider.value = vb.vidaAtual;

    }
}
