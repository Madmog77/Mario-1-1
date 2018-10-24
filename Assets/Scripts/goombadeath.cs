using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goombadeath : MonoBehaviour
{
    
    private GoombaChase goomba;
    public Animator animator;
    public GameObject otherGameobject;
    public GameObject othercollider;
    public float time = 2;

    private void Awake()
    {
        goomba = otherGameobject.GetComponent<GoombaChase>();
    }
    // Use this for initialization
    void Start()
    {
        

    }


    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collider"))
        {
            
            goomba.speed = 0;
            Destroy(othercollider);
            Destroy(otherGameobject, time);
            goomba.death = true;
            //animator.SetBool("GoombaDeath", true);
        }
    }
}
