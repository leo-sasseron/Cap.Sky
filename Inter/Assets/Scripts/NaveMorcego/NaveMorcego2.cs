using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMorcego2 : MonoBehaviour {

    bool visivel;
    public Renderer render;
    public GameObject player;
    public float speed, rotateSpeed;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

       rb.velocity = (transform.forward * speed) * Time.deltaTime ;


        Vector3 seguePlayer = player.transform.position - this.transform.position;

        seguePlayer.Normalize();

        Vector3 lookat = Vector3.Cross(seguePlayer, transform.forward);

        Vector3 totalDeRotacao = new Vector3(lookat.x, lookat.y , lookat.z );

        rb.angularVelocity = -totalDeRotacao * rotateSpeed;


       

            migue();


     

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




            if (random <= 60)
            {
                foreach (Collider coll in coliders)
                {
                    coll.enabled = false;


                }

            }


        }


        //   Debug.Log(visivel);
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
