using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController1 : MonoBehaviour {
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    public GameObject wallprefab;

    Collider wall;

    Vector3 lastWallEnd;
    Vector3 movement;

    public Rigidbody _rb;
    public Transform target;
    public int speed = 16;

    // Use this for initialization
    void Start() {
        Invoke("lastWallEnd", 5);
        Invoke("wall", 5);

        _rb =  GetComponent<Rigidbody>();

        _rb.velocity = Vector3.forward * speed;
        spawnwall();

       transform.TransformDirection(-Vector3.forward * 2);
    }

    void spawnwall() {
        lastWallEnd = transform.position;

        GameObject g = (GameObject)Instantiate(wallprefab, transform.position, Quaternion.identity);
        wall = g.GetComponent<Collider>();
    }

    void fitColliderBetween(Collider co, Vector3 a, Vector3 b) {
        co.transform.position = a + (b - a) * 0.5f;
        float dist = Vector3.Distance(a, b);
        if (a.x != b.x)
            co.transform.localScale = new Vector3(dist +1, 1, 1);
        else
            co.transform.localScale = new Vector3(1, 1, dist +1);

    }

    /* need to fix player rotation, possible fixes, Vector3.RotateTowards, or MoveTowards  */
    void FixedUpdate() {

        if (Input.GetKeyDown(upKey)) {
            _rb.velocity = Vector3.forward * speed;
            spawnwall();
        }
        else if (Input.GetKeyDown(downKey)) {
            _rb.velocity = -Vector3.forward * speed;
            spawnwall();
        }
        else if (Input.GetKeyDown(rightKey)) {
            _rb.velocity = Vector3.right * speed;
            spawnwall();
        }
        else if (Input.GetKeyDown(leftKey)) {
            _rb.velocity = -Vector3.right * speed;
            spawnwall();
        }

        fitColliderBetween(wall, lastWallEnd, transform.position);


    }

    void OnTriggerEnter(Collider co) {
    // Not the current wall?
        if (co != wall) {
            print("Player lost:" + name);
            Destroy(gameObject);
        }
    }
}

