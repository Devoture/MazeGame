using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController1 : MonoBehaviour
{

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    public GameObject wallprefab;

    Collider wall;

    Vector3 lastWallEnd;
    

    public float speed = 16;

    // Use this for initialization
    void Start()
    {
        Invoke("lastWallEnd", 5);
        Invoke("wall", 5);

        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
        spawnwall();

       // transform.TransformDirection(-Vector3.forward * 2);


    }

    void spawnwall()
    {
        lastWallEnd = transform.position;

        GameObject g = (GameObject)Instantiate(wallprefab, transform.position, Quaternion.identity);
        wall = g.GetComponent<Collider>();
    }

    void fitColliderBetween(Collider co, Vector3 a, Vector3 b)
    {
        co.transform.position = a + (b - a) * 0.5f;
        float dist = Vector3.Distance(a, b);
        if (a.x != b.x)
            co.transform.localScale = new Vector3(dist +1, 1, 1);
        else
            co.transform.localScale = new Vector3(1, 1, dist +1);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
           // transform.Rotate(0, 0, 0);
            spawnwall();
        }
        else if (Input.GetKeyDown(downKey))
        {
            GetComponent<Rigidbody>().velocity = -Vector3.forward * speed;
           // transform.Rotate(0, 90, 0);
            spawnwall();
        }
        else if (Input.GetKeyDown(rightKey))
        {
            GetComponent<Rigidbody>().velocity = Vector3.right * speed;
          //  transform.Rotate(0, 0, 0);
            spawnwall();
        }
        else if (Input.GetKeyDown(leftKey))
        {
            GetComponent<Rigidbody>().velocity = -Vector3.right * speed;
          //  transform.Rotate(0, 0, -90);
            spawnwall();
        }

        fitColliderBetween(wall, lastWallEnd, transform.position);


    }
}

