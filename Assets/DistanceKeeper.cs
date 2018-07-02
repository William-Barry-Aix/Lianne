using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceKeeper : MonoBehaviour {
    private bool swinging;
    private DistanceJoint2D mapAnchorJoint;
    private Rigidbody2D mapAnchorRB;
    // Use this for initialization
    void Start () {
        swinging = false;
        mapAnchorJoint = GetComponent<DistanceJoint2D>();
        mapAnchorRB = mapAnchorJoint.connectedBody;

    }
	
	// Update is called once per frame
	void Update () {

        if (mapAnchorJoint.maxDistanceOnly)
        {
            float DistY = mapAnchorRB.transform.position.y - transform.position.y;
            float DistX = mapAnchorRB.transform.position.x - transform.position.x;

            float distance = Mathf.Sqrt(Mathf.Pow(DistY, 2) + Mathf.Pow(DistX, 2));

            if (distance >= mapAnchorJoint.distance)
            {
                //mapAnchorJoint.maxDistanceOnly = false;
            }
        }



        //Debug.Log(curentDist);
        //Debug.Log(mapAnchorJoint.distance);
    }
}
