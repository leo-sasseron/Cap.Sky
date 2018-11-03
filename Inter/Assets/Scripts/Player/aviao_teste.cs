using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class aviao_teste : MonoBehaviour
{



    public GameObject seguePlayer;
    public float rotacaoX, rotacaoY, rotacaoZ;
    public float MaxVel;
    public float aceleracao, velocidadeAtual, velocidadeInicial, velocidadeMinima;
    public float levaDanoAoColidir;
    Vector3 OndeRayAcertaChao;
    float distChao;
    string tagHitray;


    bool OnWater;

    public float perdeVelAgua, perdeVelMaxAgua;
    Rigidbody rb;
    string totalaceleracao;



    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        velocidadeAtual += velocidadeInicial;

    }

    // Update is called once per frame
    void Update()
    {
        controles();
    }

    void controles()
    {

        totalaceleracao = "" + aceleracao * Time.deltaTime;

        // Time.timeScale = 0.1f;



        velocidadeAtual += (Input.GetAxis("Vertical") * aceleracao) * Time.deltaTime;
        //acelera aviao


        if (velocidadeAtual <= velocidadeMinima)
        {

            velocidadeAtual = velocidadeMinima;

        }




        rb.velocity = -transform.forward * (velocidadeAtual);


        transform.Rotate(
            Input.GetAxis("RotacaoX") * rotacaoX * Time.deltaTime,
            Input.GetAxis("RotacaoY") * rotacaoY * Time.deltaTime * velocidadeAtual / 100,
            Input.GetAxis("RotacaoZ") * rotacaoZ * Time.deltaTime * velocidadeAtual / 10,
            Space.Self);
        // cuida da rotacao do aviao




        if (velocidadeAtual >= MaxVel)
        {

            velocidadeAtual = MaxVel;
        }
        //vel max do aviao

        if (Input.GetAxis("Vertical") > 0)
        {

            velocidadeAtual -= Time.deltaTime;

        }
        // reduz vel aviao

    }

    private void FixedUpdate()
    {
        Deteccoes();
    }

    void Deteccoes()
    {



        // Debug.Log(distChao);




        RaycastHit ray;


        Physics.Raycast(seguePlayer.transform.position, seguePlayer.transform.TransformDirection(Vector3.down), out ray);



        // distancia do player do chao
        distChao = ray.distance;
        // vector 3 de onde o ray acerta o chao
        OndeRayAcertaChao = ray.point;
        //tag do objeto q é acertado pelo raio

        
       // tagHitray = ray.collider.tag;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(seguePlayer.transform.position, OndeRayAcertaChao);
    }


    private void OnCollisionEnter(Collision coll)
    {


        if (coll.gameObject.layer != 2 && coll.gameObject.layer != 31 && coll.gameObject.layer != 9)
        {

            vidaPlayer vidaplayer = this.transform.GetComponent<vidaPlayer>();

            if (vidaplayer != null)
            {

                vidaplayer.takeDamage(levaDanoAoColidir);


            }
        }
    }
}

/*
 void OnTriggerEnter(Collider coll)
 {

     if (coll.gameObject.tag == "agua")
     {
         OnWater = true;



             velocidadeAtual -= velocidadeAtual/5;

         MaxVel -= perdeVelMaxAgua;

     }

 }

 void OnTriggerExit(Collider coll)
 {

     if (coll.gameObject.tag == "agua")
     {

         OnWater = false;
         MaxVel += perdeVelMaxAgua;
     }

 }
 */

