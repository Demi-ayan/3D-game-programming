using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MerchStats : MonoBehaviour
{
    public float npcHealth = 30f; // variable for the maximum amount of health the user can have

    public StatsSystem stats;// variable used to store a different script

    public NavMeshAgent Nav;// used to store a nav mesh agent

    public GameObject explosionVFX;// A variable used to store a particle effect

    public AudioSource boom;//used in storing an audio source

    public void Start()
    {
        //gets the component for the nav mesh agent attached to this game object
        Nav = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Call the die() function
        Die();
    }

    private void OnTriggerEnter(Collider collision)
    {
        //if the cannon hits the collider of the ship...
        if (collision.gameObject.tag == "cannon")
        {
            //...object health is reduced by 10
            npcHealth -= 10;
            //destroy the game object
            Destroy(collision.gameObject);
        }

        //if the player ship collides with enemy ship...
        if (collision.gameObject.tag == "Player")
        {
            //...Enemy ship blows up
            npcHealth = 0;
        }

    }

    public void Die()
    {
        //If enemy health is empty...
        if (npcHealth <= 0)
        {
            //spawn the explosion particle effect
            Instantiate(explosionVFX, transform.position, transform.rotation);
            //then play the explosion sound effects
            boom.Play();

            //player score is incread by 3
            stats.score += 3;

            //destroy game object
            Destroy(gameObject);
        }
    }
}
