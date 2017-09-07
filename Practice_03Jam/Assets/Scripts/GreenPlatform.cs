using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlatform : MonoBehaviour
{
    public float PlayerSpeed;
    public float FastSpeed;

    void OnCollisionEnter2D (Collision2D GreenPlatform)
    {
        if(GreenPlatform.transform.tag == "Player")
        {
            GreenPlatform.gameObject.GetComponent<PlayerMovement>().speed = FastSpeed;
        }
    }
    

    void OnCollisionExit2D (Collision2D GreenPlatform)
    {
        if(GreenPlatform.transform.tag == "Player")
        {
            GreenPlatform.gameObject.GetComponent<PlayerMovement>().speed = PlayerSpeed;
        }
    }
}