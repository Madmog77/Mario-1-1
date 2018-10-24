using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaChase : MonoBehaviour {

    public float speed = 2;
    public Animator animator;
    private Transform target;
    public bool death = false;

    // Use this for initialization
    void Start() {

        target = GameObject.FindGameObjectWithTag("Point1").GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point1"))
        {
            target = GameObject.FindGameObjectWithTag("Point2").GetComponent<Transform>();
        }
        if (other.gameObject.CompareTag("Point2"))
        {
            target = GameObject.FindGameObjectWithTag("Point1").GetComponent<Transform>();
        }

        /*if (other.gameObject.CompareTag("killcollider"))
        {

            animator.SetBool("GoombaDeath", true);

        } */


    }

        


    // Update is called once per frame
    void Update() {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (death == true)
        {
            animator.SetBool("GoombaDeath", true);
        }
    }


}
