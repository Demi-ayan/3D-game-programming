using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsSystem : MonoBehaviour
{
    public float maxHealth = 100f; // variable for the maximum amount of health the user can have
    public float currentHealth; // variable for the players present health

    public int score = 0;//A variable used to store points scored
    public Text scoreText;//A variable that can be used to change and display the value of the score in-game
    public Text ammoLeftText;//This displays how much ammo the user has left

    public Slider healthSlider;//This shows how much health the player has left

    public int StartAmmo = 50;//This is used to set the value of the ammo user starts with
    public int AmmoLeft;//This stores how much ammo is left

    //Game objects to store texts 
    public GameObject ammoPickedText;
    public GameObject hitBarrelText;

    //Game object used to store the game over screen
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        //Speed of the game is set to normal time
        Time.timeScale = 1f;

        //Initial stats set to the max to start the game
        currentHealth = maxHealth;
        AmmoLeft = StartAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        //The UI gets updated every frame
        healthSlider.value = (currentHealth / maxHealth);
        scoreText.text = score.ToString();
        ammoLeftText.text = AmmoLeft.ToString();

        //The Die() function is called
        Die();
    }


    //If the game object with a specific tag comes in contact with the player...
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ammo")
        {
            //...add more ammo
            AmmoLeft += 3;
            // then destroy the game object
            Destroy(collision.gameObject);
            //and show the 'ammo picked' text
            StartCoroutine(DisplayText());
        }
        
        if (collision.gameObject.tag == "barrel")
        {
            //..instantly kills player
            currentHealth = 0;
            //then destroy the game object
            Destroy(collision.gameObject);
            //and show the 'barrel hit' text
            StartCoroutine(HitText());
        }

        if (collision.gameObject.tag == "cannon2")
        {
            //...user loses health
            currentHealth -= 10;
            //then destroy the game object
            Destroy(collision.gameObject);
        }

    }

    //A function to display the 'ammo picked' text for 2 seconds
    public IEnumerator DisplayText()
    {
        ammoPickedText.SetActive(true);
        yield return new WaitForSeconds(2);
        ammoPickedText.SetActive(false);
    }

    //A function to display the 'barrel hit' text for 1 second
    public IEnumerator HitText()
    {
        hitBarrelText.SetActive(true);
        yield return new WaitForSeconds(1);
        hitBarrelText.SetActive(false);
    }

    public void Die()
    {
        //If enemy health is empty...
        if (currentHealth <= 0)
        {
            //...all scripts attached to the game object is disabled
            gameObject.GetComponent<FloatObject>().enabled = false;
            gameObject.GetComponent<BoatController>().enabled = false;

            //If the object goes below a certain point...
            if (this.gameObject.transform.position.y < -7)
            {
                //...the game over screen is shown 
                gameOver.SetActive(true);
                //and the game is stopped
                Time.timeScale = 0f;
            }

        }
    }
}

