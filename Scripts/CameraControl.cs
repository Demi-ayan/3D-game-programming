using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Game object variables for both 1st and 3rd person cameras
    public GameObject firstCam, thirdCam;

    private void Start()
    {
        //Default camera is set to 3rd person camera
        thirdCam.SetActive(true);
        firstCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //If the key 'C' is pressed...
        if (Input.GetKeyDown(KeyCode.C))
        {
            //...the cameras are switched
            SwitchCameras();
        }
    }

    void SwitchCameras()
    {
        //If the third person camera is active then it switches to first person
        if (firstCam.activeInHierarchy == false)
        {
            firstCam.SetActive(true);
            thirdCam.SetActive(false);
        }


        //If the first person camera is active then it switches to third person
        else
        {
            firstCam.SetActive(false);
            thirdCam.SetActive(true);
        }
    }
}
