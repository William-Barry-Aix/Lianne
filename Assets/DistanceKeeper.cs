using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceKeeper : MonoBehaviour {
    private DistanceJoint2D mapAnchorJoint;
    private Rigidbody2D mapAnchorRB;

    // Use this for initialization
    void Start () {
        mapAnchorJoint = GetComponent<DistanceJoint2D>();
        mapAnchorRB = mapAnchorJoint.connectedBody;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("MaxOnly: " + mapAnchorJoint.maxDistanceOnly);
        if (mapAnchorJoint.maxDistanceOnly)
        {
            
            float DistY = mapAnchorRB.transform.position.y - transform.position.y;
            float DistX = mapAnchorRB.transform.position.x - transform.position.x;

            float distance = Mathf.Sqrt(Mathf.Pow(DistY, 2) + Mathf.Pow(DistX, 2));
            Debug.Log(distance);
            if (distance >= mapAnchorJoint.distance)
            {
                mapAnchorJoint.maxDistanceOnly = false;
            }
        }        
    }
    

    }
}
