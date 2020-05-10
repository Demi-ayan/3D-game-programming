using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(FloatObject))]
public class BoatController : MonoBehaviour
{
    //A variable for the centre of mass of the ship
    public Vector3 COM;
    [Space (15)]

    //Variables for the values for the ship movement
    public float speed = 1.0f;
    public float steerSpeed = 1.0f;
    public float movementThreshold = 10.0f;

    private Transform m_COM;
    float verticalInput;
    float movementFactor;
    float horizontalInput;
    float steerFactor;

    //Game object used for ship animations
    public GameObject Wheels;

    // Update is called once per frame
    void Update()
    {
        Balance();
        Movement();
        Steer();
    }

    void Balance()
    {
        //If there is no Transform for m_COM
        if (!m_COM)
        {
            //create a new game object with the name COM, and make it a child of the game object
            m_COM = new GameObject("COM").transform;
            m_COM.SetParent(transform);

        }

        //Value of m_COM is set to the vector COM
        m_COM.position = COM;

        //Then set the center of mass of the rigidbody to the transform
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;
    }

    void Movement()
    {
        //Value of vertical input is put into this variable
        verticalInput = Input.GetAxis("Vertical");
        //
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThreshold);
        //Object moves in the z-axis by the movementFactor by the speed
        transform.Translate(0.0f, 0.0f, movementFactor * speed);
    }

    void Steer()
    {
        //Value of horizontal input is put into this variable
        horizontalInput = Input.GetAxis("Horizontal");
        //
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput , Time.deltaTime / movementThreshold);
        //Object moves in the y-axis by the steerFactor by the speed
        transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);

        //Wheel animation rotate right is played when steering right
        if (horizontalInput > 0)
        {
            Wheels.GetComponent<Animator>().enabled = true;
            Wheels.GetComponent<Animator>().Play("Wheel Animation");       
        }

        //Wheel animation rotate left is played when steering left
        if (horizontalInput < 0)
        {
            Wheels.GetComponent<Animator>().enabled = true;
            Wheels.GetComponent<Animator>().Play("Wheel anim L");

        }

        //Wheel animation is turned off when stationary
        if (horizontalInput == 0)
        {
            Wheels.GetComponent<Animator>().enabled = false;
        }
    }
}
