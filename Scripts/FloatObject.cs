using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ensures that a rigidbody is on the game object this script is attached to
[RequireComponent(typeof(Rigidbody))]
public class FloatObject : MonoBehaviour
{

    public float waterLevel = 0f;
    public float waterThreshold = 2f;
    public float waterDensity = 0.125f;
    public float downForce = 4.0f;

    float forceFactor;
    Vector3 floatForce;
    

    void FixedUpdate()
    {
        forceFactor = 1.0f - ((transform.position.y - waterLevel) / waterThreshold);

        if (forceFactor > 0.0f)
        {
            floatForce = -Physics.gravity * GetComponent<Rigidbody>().mass * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0.0f, -downForce * GetComponent<Rigidbody>().mass, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);

        }

    }
}
