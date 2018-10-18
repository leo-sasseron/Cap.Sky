using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroMorcego : MonoBehaviour
{

    public float damage;
    public float range;
    float timerCooldown, timerReload;
    public float maxTempoCooldown, maxTimerReload;
    public bool showGizmos;
    public LayerMask layermask;
    airplaneAI airplaneai;

   

    public int tirosMaximos, tirosRestantes;

    private void Start()
    {
        airplaneai = GetComponent<airplaneAI>();
    }


    private void Update()
    {

        

        if (timerCooldown > 0)
        {
            timerCooldown -= Time.deltaTime;

        }

        if (tirosRestantes <= 0)
        {

            reload();

        }

    }

    private void FixedUpdate()
    {
        Physics.BoxCast(this.transform.position - new Vector3(-5.195679f, 0.1856079f, 244.1569f), new Vector3(95.33374f, 41.49817f, 488.5338f), Vector3.forward);
    }






    /* private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            tirosRestantes = 0;
        }
    }

    */


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            tiro();

        }
    }

   
    void tiro()
    {
        float randomShot;
        


        RaycastHit shot;
      
        if (timerCooldown <= 0 && tirosRestantes > 0)
        {
            
            randomShot = Random.Range(0, 100);

            if (randomShot < 90) { 
            Physics.Raycast(this.transform.position, this.transform.forward, out shot, range, layermask);

                vidaPlayer vidaplayer = shot.transform.GetComponent<vidaPlayer>();
               

                if (vidaplayer != null)
                {

                    vidaplayer.takeDamage(damage);

                }

            }
           

            

            timerCooldown = maxTempoCooldown;
            tirosRestantes--;
        }

       

    }

    void reload()
    {
       // Debug.Log(timerCooldown);



        timerReload += Time.deltaTime;

        if (timerReload >= maxTimerReload)
        {

            tirosRestantes = tirosMaximos;
            timerReload = 0;
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (showGizmos)
        {

            
                Gizmos.DrawRay(this.transform.position, this.transform.forward * range);

            
        }
    }
}

