using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlatform : MonoBehaviour {

    public float SlowSpeed;
    public float PlayerSpeed;

    

    void OnCollisionEnter2D (Collision2D YellowPlatform)
    {
        if (YellowPlatform.transform.tag == "Player")
        {
            YellowPlatform.gameObject.GetComponent<PlayerMovement>().speed = SlowSpeed;
        }
    }

    void OnCollisionExit2D (Collision2D YellowPlatform)
    {
        if (YellowPlatform.transform.tag == "Player")
        {
            YellowPlatform.gameObject.GetComponent<PlayerMovement>().speed = PlayerSpeed;
        }
    }
}