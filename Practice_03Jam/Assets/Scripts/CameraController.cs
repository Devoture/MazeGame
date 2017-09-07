using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Player;
    private Vector3 offset;

    Transform Follow;


    // Use this for initialization
    void Start () {

        offset = transform.position - Player.transform.position;
       Follow = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Player.transform.position + offset;
       // transform.position = new Vector3(Follow.position.x, transform.position.y, transform.position.z);
    }
}
