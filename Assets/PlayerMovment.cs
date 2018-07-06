using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    private Rigidbody2D rb2D;
    private Rigidbody2D playerAnchor;
    private Rigidbody2D mapAnchor;
    private float thrust;


    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        playerAnchor = GetComponent<DistanceJoint2D>().connectedBody;
        setMapAnchor(playerAnchor.gameObject.GetComponent<DistanceJoint2D>().connectedBody);
        thrust = 35.0f;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (playerAnchor)
        {
            if (mapAnchor)
            {
                if (playerAnchor.GetComponent<DistanceKeeper>().isFixed())
                {
                    if (Input.GetKey("right"))
                    {                        
                        rb2D.AddForce(transform.right * thrust);
                    }
                    else if (Input.GetKey("left"))
                    {
                        rb2D.AddForce(transform.right * -thrust);
                    }
                    else if (Input.GetKey("down"))
                    {
                        //stopSwinging();
                    }
                }
            }
        }
    }

    private bool stopedSwinging()
    {
        if (transform.position.x <= mapAnchor.position.x + 0.2 &&
            transform.position.x >= mapAnchor.position.x - 0.2)
        {
            
            return rb2D.velocity.magnitude < 0.5f;
        }
        return false;
    }


    private void stopSwinging()
    {
        if (rb2D.velocity.y < 0)
        {

            if (transform.position.x < mapAnchor.position.x)
            {
                rb2D.AddForce(transform.right * -rb2D.velocity* thrust);
            }
            else if (transform.position.x > mapAnchor.position.x)
            {
                rb2D.AddForce(transform.right * -rb2D.velocity* thrust);
            }
        }
        
    }


    private void OnGUI()
    {
        //
    }
    
    public void setMapAnchor(Rigidbody2D mapAnchor)
    {
        this.mapAnchor = mapAnchor;
        playerAnchor.gameObject.GetComponent<DistanceJoint2D>().connectedBody = mapAnchor;
    }
}
