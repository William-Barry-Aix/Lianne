using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    private Rigidbody2D rb2D;
    Rigidbody2D playerAnchor;
    Rigidbody2D mapAnchor;
    public float thrust;


    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        thrust = 20.0f; 
        playerAnchor = GetComponent<DistanceJoint2D>().connectedBody;
        setMapAnchor(playerAnchor.gameObject.GetComponent<DistanceJoint2D>().connectedBody);
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
                        stopSwinging();
                    }
                }
            }
        }
    }
        {
            rb2D.AddForce(transform.up * -2*thrust);
        }
    }

    private void OnGUI()
    {
        //
    }
}
