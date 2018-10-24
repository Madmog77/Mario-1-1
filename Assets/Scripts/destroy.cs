using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

    public GameObject coin;
	// Use this for initialization
	void Start () {
        Destroy(coin, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
