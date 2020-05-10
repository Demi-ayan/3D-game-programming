using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float rotateSpeed = 1.2f;

    // Update is called once per frame
    void Update()
    {
        //This calls the rotation property of the skybox and is rotated by the rotatespeed multiplied by time elapsed since the project started
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed);
    }
}
