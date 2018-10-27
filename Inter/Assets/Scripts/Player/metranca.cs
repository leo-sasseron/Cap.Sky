using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metranca : MonoBehaviour
{
    public LayerMask layermask;

   

    
   
   
    private AudioSource audioMetralha;
    public AudioClip tiros, reloadAudio;
    bool atirando;
    public float damage = 50;
    public float range = 100;
    bool recarrega;
    public bool ShowGizmos;
    float timerCooldown, timerReload;
    public int tirosMaximos;
    public static int tirosRestantes;
    public float maxTempoCooldown, maxTimerReload;
    public GameObject particula;
    public Transform firePoint;

    


    private void Start()
    {

        tirosRestantes = tirosMaximos;
        audioMetralha = GetComponent<AudioSource>();

        audioMetralha.clip = tiros;
        audioMetralha.Pause();
    }

    // Update is called once per frame
    void Update()
    {
      
            if (Input.GetKey(KeyCode.Space))
            {
                tiro();


            }
        
        


        if (Input.GetKeyDown(KeyCode.Space) && recarrega == false)
        {

           

            
            audioMetralha.clip = tiros;
            audioMetralha.loop = true;
            audioMetralha.Play();
            atirando = true;





        }

        if (Input.GetKeyUp(KeyCode.Space) && recarrega == false)
        {



            //audioMetralha.clip = null;
            audioMetralha.Pause();
            atirando = false;

        }

        if (atirando == true && recarrega == false)
        {

            


        }







        if (timerCooldown > 0)
        {
            timerCooldown -= Time.deltaTime;

        }

        if ((tirosRestantes <= 0 || (Input.GetKeyDown(KeyCode.R ) && tirosRestantes < tirosMaximos)) && recarrega == false)
        {

            audioMetralha.clip = reloadAudio;
            audioMetralha.Play();
            recarrega = true;

        }

        if (recarrega == true)
        {
            reload();
           
           
        }
       
        
           

        
    }



     void tiro()
     {


        RaycastHit shot;

        if (timerCooldown <= 0 && tirosRestantes > 0)
         {
            tirosRestantes--;
            timerCooldown = maxTempoCooldown;


            Physics.Raycast(firePoint.transform.position, -firePoint.transform.forward,  out shot, range, layermask);
        print(shot.collider.gameObject.name);


            //print(shot.collider.name);

            
            

            VidaBot bot = shot.transform.GetComponent<VidaBot>();




            // if (shot.collider != null)
            // {
                 if (bot != null)
                 {

                     bot.takeDamage(damage);
                }
             }



         }


        
    

     void reload()
     {

         timerReload += Time.deltaTime;

         if (timerReload >= maxTimerReload)
         {
             recarrega = false;
             tirosRestantes = tirosMaximos;
             timerReload = 0;

             audioMetralha.clip = null;
         }


    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (ShowGizmos) { Gizmos.DrawRay(firePoint.transform.position, firePoint.transform.forward * -range); }
        
    }
}


