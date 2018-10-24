using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBox : MonoBehaviour {

    public GameObject Mushroom;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Mushroom.SetActive(true);
            }

        }
    }

