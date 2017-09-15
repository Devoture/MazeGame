using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawning : MonoBehaviour {

	Vector3 lastWallEnd;
	Collider wall;

    void Start()
    {
        Invoke("lastWallEnd", 5);
        Invoke("wall", 5);
        spawnwall();

        // transform.TransformDirection(-Vector3.forward * 2));


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