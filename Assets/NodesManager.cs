using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodesManager : MonoBehaviour {
    public GameObject node;
    private DistanceJoint2D mapAnchorJoint;
    private GameObject nodes;

    // Use this for initialization
    void Start () {
        mapAnchorJoint = GetComponent<DistanceJoint2D>();
        //nodes = 
    }
	
	// Update is called once per frame
	void Update () {
        // si pas assez de noeuds
        //creation d'un nouveau depuis la tête

        //si trop de noeuds
        //supréssion du dernier
	}
}
