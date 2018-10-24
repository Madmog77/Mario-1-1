using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public GameObject player;
    public GameObject playercam;
    public Vector3 offset;
    private PlayerController cam;

    // Use this for initialization
    void Start () {

            offset = transform.position - player.transform.position;
            cam = playercam.GetComponent<PlayerController>();

    }

    // Update is called once per frame

    /*private void Update()
    {
        if (cam.death == true)
        {
            offset = new Vector3(0, 0, 0);
        }

    }*/

    // Update is called once per frame
    void LateUpdate()
        {

            transform.position = player.transform.position + offset;
           
        }

    }
