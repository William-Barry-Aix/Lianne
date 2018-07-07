using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceKeeper : MonoBehaviour {
    private DistanceJoint2D mapAnchorJoint;
    private Rigidbody2D mapAnchorRB;
    private float maxLength;
    private float resizeSpeed;


    // Use this for initialization
    void Start () {
        mapAnchorJoint = GetComponent<DistanceJoint2D>();
        mapAnchorRB = mapAnchorJoint.connectedBody;
        maxLength = 10;
        resizeSpeed = 0.1f;
    }
	
	// Update is called once per frame
	void Update () {
        if (mapAnchorJoint.maxDistanceOnly)
        {        
            if (getCurrentDistance() >= mapAnchorJoint.distance)
            {
                mapAnchorJoint.maxDistanceOnly = false;
            }
        }        
    }
    

    public bool isFixed()
    {
        return !mapAnchorJoint.maxDistanceOnly;
    }
    public void extend()
    {
        if (GetComponent<DistanceJoint2D>().distance < maxLength)
        {
            GetComponent<DistanceJoint2D>().distance += resizeSpeed*1.2f;
        }
    }

    public void shorten()
    {
        if (GetComponent<DistanceJoint2D>().distance > 0)
        {
            GetComponent<DistanceJoint2D>().distance -= resizeSpeed;
        }
    }

    public float getCurrentDistance()
    {
        return Vector2.Distance(mapAnchorRB.transform.position, transform.position);
    }
}
