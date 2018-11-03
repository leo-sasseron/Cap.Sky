using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class airplaneAI : MonoBehaviour
{
    Rigidbody rb;

    public float rotacaoOlhando;
    bool visivel;
    float rotacaoX, rotacaoY, rotacaoZ;
     float addrotacaoX, addrotacaoY, addrotacaoZ;
    public float fAddX, fAddY, fAddZ, random;
   



    public float velocidade;
    bool FrenteRayHit, CimaRayHit, BaixoRayHit, EsquerdaRayHit, DireitaRayHit;

    public bool seguindo, showGizmos;
    public float começoDistanciaRay, distanciaRaycast, distanciaRayFrente, distanciaRayBaixo;

    public GameObject player;
    public GameObject asaEsquerda, asaDireita;

    public Renderer render;
    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        distanciaRaycast = começoDistanciaRay;
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

        migue();
        movimentacao();

    }



    private void FixedUpdate()
    {
        detccoes();

     
    }


    void movimentacao()
    {
        float randomx, randomy, randomz;

        randomx = Random.Range(-random, random);
        randomy = Random.Range(-random, random);
        randomz = Random.Range(-random, random);

        if (FrenteRayHit == false && seguindo == true)
        {
            Vector3 seguePlayer = player.transform.position - this.transform.position;

            seguePlayer.Normalize();

            Vector3 lookat = Vector3.Cross(seguePlayer, transform.forward);

            Vector3 totalDeRotacao = new Vector3 (lookat.x + randomx, lookat.y + randomy, lookat.z + randomz );

            rb.angularVelocity = -totalDeRotacao * rotacaoOlhando;


           
        }

        

        else { detccoes(); }


            if (FrenteRayHit == false )
        {
            


          



            distanciaRaycast = começoDistanciaRay;

            CimaRayHit = false;
            BaixoRayHit = false;
            EsquerdaRayHit = false;
            DireitaRayHit = false;



            addrotacaoX = 0;
            addrotacaoY = 0;
            addrotacaoZ = 0;

        }

        if (FrenteRayHit == true)
        {
            seguindo = false;

        }

       

        if (FrenteRayHit == true && CimaRayHit == false)
        {
            
            addrotacaoX = fAddX * -1;

           

        }
        else  if (CimaRayHit == true && BaixoRayHit == false)
         {

             addrotacaoX = fAddX;

          }

         else if (BaixoRayHit == true && EsquerdaRayHit == false)
        {

            addrotacaoY = fAddY * -1;

        } 

        else if (EsquerdaRayHit == true && DireitaRayHit == false)
        {


            addrotacaoY = fAddY;

        }




        transform.Rotate(
            rotacaoX + addrotacaoX * Time.deltaTime,
            rotacaoY + addrotacaoY * Time.deltaTime,
            rotacaoZ + addrotacaoZ * Time.deltaTime,
            Space.Self);
        //cuida da rotacao da nave

        rb.velocity = transform.forward * (velocidade * Time.deltaTime);
        //manda a nave para frente

    }

    public Collider[] coliders;

    void migue()
    {
       
       

        
        float random = 0;
        



        if (render.isVisible == true)
            
          {
              visivel = true;

              foreach (Collider coll in coliders)
              {
                  coll.enabled = true;


              }
          }
          
       

        if (render.isVisible == false && visivel == true)
        {

            visivel = false;
            random = Random.Range(0, 101);
            

            
            
            if (random <= 85)
            {
                foreach (Collider coll in coliders)
                {
                    coll.enabled = false;


                }

            }


        }


     //   Debug.Log(visivel);
    }

        

    



    void detccoes()
    {

        int Layerignorar  = 9;


        RaycastHit frente;
        RaycastHit cima;
        RaycastHit baixo;
        RaycastHit esquerda;
        RaycastHit direita;

        

        Physics.Raycast(this.transform.position, this.transform.rotation * Vector3.forward, out frente, distanciaRayFrente , Layerignorar);


        if (frente.collider != null )
        {
            seguindo = false;
            Physics.Raycast(this.transform.position, this.transform.rotation * Vector3.up, out cima, distanciaRaycast);
            FrenteRayHit = true;

            if (cima.collider != null)
            {

                Physics.Raycast(this.transform.position, this.transform.rotation * Vector3.down, out baixo, distanciaRaycast);
                CimaRayHit = true;
                if (baixo.collider != null)
                {

                    Physics.Raycast(asaEsquerda.transform.position , this.transform.rotation * Vector3.left, out esquerda, distanciaRaycast);
                    BaixoRayHit = true;

                    if (esquerda.collider != null)
                    {
                        Physics.Raycast(asaDireita.transform.position, this.transform.rotation * Vector3.right, out direita, distanciaRaycast);
                        EsquerdaRayHit = true;

                        if (direita.collider != null)
                        {

                            distanciaRaycast -= 80;
                         /*   CimaRayHit = false;
                            BaixoRayHit = false;
                            EsquerdaRayHit = false;
                            DireitaRayHit = false;
                         */   

                            

                        }
                        

                    }
                    else
                    {

                        EsquerdaRayHit = false;
                    }

                }
                else
                {

                    BaixoRayHit = false;
                }
            }

            else
            {
                CimaRayHit = false;
            }

        }

        else
        {

            FrenteRayHit = false;

            seguindo = true;

        }

        

    }

    /*   IEnumerator voltaASeguir()
    {

        yield return new WaitForSeconds(3f);
       
        
    }
    */

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (showGizmos) { 




         Gizmos.DrawRay(this.transform.position, this.transform.rotation * Vector3.forward * distanciaRayFrente);
          Gizmos.DrawRay(this.transform.position, this.transform.rotation * Vector3.up * distanciaRaycast);
          Gizmos.DrawRay(this.transform.position, this.transform.rotation * Vector3.down * distanciaRayBaixo);
          Gizmos.DrawRay(asaEsquerda.transform.position,  this.transform.rotation * Vector3.left * distanciaRaycast);
           Gizmos.DrawRay(asaDireita.transform.position, this.transform.rotation * Vector3.right * distanciaRaycast);
        }
    }


    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer != 2 && coll.gameObject.layer != 31)
        {

            vidaPlayer vidaplayer = coll.transform.GetComponent<vidaPlayer>();

            if (vidaplayer != null)
            {

                vidaplayer.takeDamage(40);
                

            }

            this.gameObject.SetActive(false);


        }
    }
}