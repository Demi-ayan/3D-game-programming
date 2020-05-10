using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseCanvas; 

    // Update is called once per frame
    void Update()
    {
        //checks if the 'escape' button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Calles the Pause game function
            PauseGame();
        }
    }

    public void PauseGame()
    {
            if(pauseCanvas.gameObject.activeInHierarchy == false) //check if the pause canvas is active 
            {
                pauseCanvas.gameObject.SetActive(true); //if not activate it
                Time.timeScale = 0f;//When the game is paused, the time freezes
            }

            else
            {
                pauseCanvas.gameObject.SetActive(false);//if active, deactivate it 
                Time.timeScale = 1f; //time goes back to normal when game is resumed
            }
    }
}
