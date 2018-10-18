using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metranca : MonoBehaviour
{
    public LayerMask layermask;

    public bool mostraNoInspector;

    [HideInInspector]
    public GameObject BotHitted;
   
    [HideInInspector]
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
    }

    // Update is called once per frame
    void Update()
    {
        print(atirando);
        

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
        if (timerReload == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                
                audioMetralha.clip = tiros;
                audioMetralha.loop = true;
                audioMetralha.Play();
                atirando = true;


               

            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) {

            

            audioMetralha.Pause();
            atirando = false;

        }

        if (atirando && recarrega == false)
         {
           
        tiro();
           
            
        }

        
    }

    

    void tiro()
    {

        

        RaycastHit shot;
        if (timerCooldown <= 0 && tirosRestantes > 0)
        {

          


            Physics.Raycast(firePoint.transform.position, firePoint.transform.forward * -range, out shot, layermask);
            //print(shot.collider.name);

            print(shot.collider.name);
            tirosRestantes--;

            VidaBot bot = shot.transform.GetComponent<VidaBot>();

           


            if (shot.collider != null)
            {


                Debug.Log(shot.collider.name);



                if (bot != null)
                {


                  
                    bot.takeDamage(damage);

                }

            }


            
        }

        timerCooldown = maxTempoCooldown;

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


