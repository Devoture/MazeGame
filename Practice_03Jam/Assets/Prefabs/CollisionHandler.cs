using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
   void OnCollisionEnter (Collision collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Debug.Log("Collision");
        }
    }
}