using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAI : MonoBehaviour {
    Rigidbody rb;



    float rotacaoX, rotacaoY, rotacaoZ;
    float addrotacaoX, addrotacaoY, addrotacaoZ;
    public float fAddX, fAddY, fAddZ;



    public float velocidade;
    bool FrenteRayHit, CimaRayHit, BaixoRayHit, EsquerdaRayHit, DireitaRayHit;


    bool cimaLivre, BaixoLivre, EsquerdaLivre, DireitaLivre, colidindo;
    int direcaoASeguir;
    float random;

    public bool seguindo, showGizmos;
    public float começoDistanciaRay, distanciaRaycast, distanciaRayFrente;

    public Transform player;
    public GameObject asaEsquerda, asaDireita;
    // Use this for initialization
    void Start()
    {
        distanciaRaycast = começoDistanciaRay;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
       //  Debug.Log("FrenteRayHit" + FrenteRayHit);
        
        //Debug.Log(direcaoASeguir);
        //Debug.Log("cimalivre" + cimaLivre);
       //  Debug.Log("baixoLivre" + BaixoLivre);

        movimentacao();

    }



    private void FixedUpdate()
    {
        detccoes();
    }


    void movimentacao()
    {
        if (FrenteRayHit == false && seguindo == true)
        {
            Vector3 direcao = new Vector3((player.transform.position.x - this.transform.position.x), (player.transform.position.y - this.transform.position.y), (player.transform.position.z - this.transform.position.z));


        }


        if (FrenteRayHit == false)
        {


            colidindo = false;
            random = 0;
            direcaoASeguir = 0;



            distanciaRaycast = começoDistanciaRay;

            CimaRayHit = false;
            BaixoRayHit = false;
            EsquerdaRayHit = false;
            DireitaRayHit = false;
            


            addrotacaoX = 0;
            addrotacaoY = 0;
            addrotacaoZ = 0;

        }

       if (FrenteRayHit == true && colidindo == false)
        {

            GeraRandomDirecoes();

            colidindo = true;

        }




        transform.Rotate(
            rotacaoX + addrotacaoX * Time.deltaTime,
            rotacaoY + addrotacaoY * Time.deltaTime,
            rotacaoZ + addrotacaoZ * Time.deltaTime,
            Space.Self);
        //cuida da rotacao da nave

        rb.velocity = transform.forward * velocidade * Time.deltaTime;
        //manda a nave para frente

    }







    void detccoes()
    {




        RaycastHit frente;
        RaycastHit AsaEsquerdaFrenteRay;
        RaycastHit AsaDireitaFrenteRay;
        RaycastHit cima;
        RaycastHit baixo;
        RaycastHit esquerda;
        RaycastHit direita;

        

        Physics.Raycast(this.transform.position, this.transform.rotation * Vector3.forward, out frente, distanciaRayFrente);
        Physics.Raycast(asaEsquerda.transform.position, this.transform.rotation * Vector3.forward, out AsaEsquerdaFrenteRay, distanciaRayFrente);
        Physics.Raycast(asaDireita.transform.position, this.transform.rotation * Vector3.forward, out AsaDireitaFrenteRay, distanciaRayFrente);


        if (frente.collider != null)
        {

            

            Physics.Raycast(this.transform.position, this.transform.rotation * Vector3.up, out cima, distanciaRaycast);
            FrenteRayHit = true;

            Physics.Raycast(this.transform.position, this.transform.rotation * Vector3.down, out baixo, distanciaRaycast);
            CimaRayHit = true;

            Physics.Raycast(asaEsquerda.transform.position, this.transform.rotation * Vector3.left, out esquerda, distanciaRaycast);
            BaixoRayHit = true;


            Physics.Raycast(asaDireita.transform.position, this.transform.rotation * Vector3.right, out direita, distanciaRaycast);
            EsquerdaRayHit = true;

           

            if (cima.collider != null)
            {
                cimaLivre = false;
            }
            else if (cima.collider == null) { cimaLivre = true; }

            if (baixo.collider != null)
            {

                BaixoLivre = false;
            }

            else { BaixoLivre = true; }

            if (esquerda.collider != null)
            {
                EsquerdaLivre = false;

            }
            else { EsquerdaLivre = true; }

            if (direita.collider != null)
            {
                DireitaLivre = false;

            }
            else { DireitaLivre = true; }





        }

        else { FrenteRayHit = false; }

        if (FrenteRayHit == true && cimaLivre == false && BaixoLivre == false && EsquerdaLivre == false && DireitaLivre == false)
        {
            distanciaRaycast -= 80;



        }

        if (FrenteRayHit == false)
        {
            cimaLivre = true;
            BaixoLivre = true;
            EsquerdaLivre = true;
            DireitaLivre = true;


        }

     
    }

    void GeraRandomDirecoes()
    {

        if (FrenteRayHit == false)
        {
            Invoke(" movimentacao", 0.2f);

         
        }

        else { 
        random =  Random.Range(0, 5);

       direcaoASeguir = (int)  random ;

        if (direcaoASeguir == 1 && cimaLivre )
        {
            addrotacaoX = fAddX * -1;

        }

       

        else if (direcaoASeguir == 2 && BaixoLivre )
        {
            addrotacaoX = fAddX;

        }

       
       

        else if (direcaoASeguir == 3 && EsquerdaLivre )
        {
            addrotacaoY = fAddY * -1;

        }

       

        else if (direcaoASeguir == 4 && DireitaLivre )
        {
            addrotacaoY = fAddY;

        }

        

        else
        {
                print("reroll" + direcaoASeguir);
            GeraRandomDirecoes();
           
        }


        }


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (showGizmos)
        {
            Gizmos.DrawRay(this.transform.position, this.transform.rotation * Vector3.forward * distanciaRayFrente);
            Gizmos.DrawRay(asaEsquerda.transform.position, this.transform.rotation * Vector3.forward * distanciaRayFrente);
            Gizmos.DrawRay(asaDireita.transform.position, this.transform.rotation * Vector3.forward * distanciaRayFrente);
            Gizmos.DrawRay(this.transform.position, this.transform.rotation * Vector3.up * distanciaRaycast);
            Gizmos.DrawRay(this.transform.position, this.transform.rotation * Vector3.down * distanciaRaycast);
            Gizmos.DrawRay(asaEsquerda.transform.position, this.transform.rotation * Vector3.left * distanciaRaycast);
            Gizmos.DrawRay(asaDireita.transform.position, this.transform.rotation * Vector3.right * distanciaRaycast);
        }
    }
}
