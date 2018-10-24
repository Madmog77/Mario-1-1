using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static float deltaTime;
    public GameObject prefab;
    public GameObject instantiatedObj;
    public float time = 2;
    void Start()
    {

    }


    public Coin coinPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collider")
        {
            instantiatedObj = (GameObject)Instantiate(prefab, new Vector2(other.transform.position.x, other.transform.position.y + 2), Quaternion.identity);
            Destroy(prefab, time);
        }
    }
    // Update is called once per frame
    void Update()
    {}
}
