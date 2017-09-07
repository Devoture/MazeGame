using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float speed;

    float extraRotationSpeed;

   /* void extraRotation()
    {
        Vector3 lookrotation = .Rigidbody - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), extraRotationSpeed * Time.deltaTime);
    } */

    //public float RotateSpeed = 30f;
    //public float Torque;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();

    }

  
    // Update is called once per frame
    void FixedUpdate () {

       // extraRotation();
        /*  if (Input.GetKeyDown("Left"))
              transform.Rotate(0, 90, 0);

          if (Input.GetKeyDown("Right"))
              transform.Rotate(0, -90, 0);

          if (Input.GetKeyDown("Up"))
             transform.Rotate(0, 0, 90);

           if (Input.GetKeyDown("Down"))
              transform.Rotate(0, 0, -90); */
        float moveHorizontal = Input.GetAxis("Horizontal");

        // float delta = Input.GetAxis("Horizontal");
        //   Vector3 axis = Vector3.forward;

        //  transform.Rotate(axis * speed * delta);
        // rb.AddTorque(axis * speed * delta);

        float moveVertical = Input.GetAxis("Vertical");
       // float moveHorizontal = Mathf.Atan2(Input.GetAxis("Horizontal"), ("Vertical")) * Mathf.Rad2Deg;


       //ransform.Rotate(0, Time.deltaTime, 0, Space.World);
       // moveVertical = Mathf.Clamp01(moveVertical);

       Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // Vector3 movement = new Vector3(0.0f, moveVertical);
        //rb.AddTorque(movement * speed);
        //rb.AddForce(movement * speed);
        rb.AddForce(movement * speed);
        


        /* this.rigidbody.velocity = Vector3.zero;
          this.rigidbody.angularvelocity = Velocity3.zero; */

        // rb.AddTorque(transform.up * Torque * moveHorizontal);
      /*  var speed = 3.0;
        var rotateSpeed = 3.0;
        var yRotation = 5.0;

         function Update()
        {
            var controller : CharacterController = GetComponent(CharacterController);

        // Rotate around y - axis
        yRotation += Input.GetAxis("Horizontal");
        transform.eulerAngles = Vector3(10, yRotation, 0);

        // Move forward / backward
        var forward = transform.TransformDirection(Vector3.forward);
        var curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }

    @script RequireComponent(CharacterController) */
    }
}
   