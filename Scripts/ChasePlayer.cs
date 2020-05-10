using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    //game object for the player 
    public GameObject player;

    public PlayerNav nav;

    public float shootDistance;

    public float chaseDistance;

    private NavMeshAgent navAgent;

    //Variable for calling another script to be used
    public EnemyShoot shooter;

    public void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        Follow();
    }

    void Follow()
    {
        //a variable is set for the directiom betweent the player and enemy object
        Vector3 direction = player.transform.position - this.transform.position;

        //Distance between the player and enemy object is calculated
        float spaceBetween = Vector3.Distance(player.transform.position, this.transform.position);

        //If the space between is less than the value of chace distance but not within shooting range...
        if (spaceBetween <= chaseDistance & direction.magnitude > shootDistance)
        {
            //...value of the y-axis in the direction is set to 0
            direction.y = 0;

            //The enemy ship rotates towards the player ship...
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            Vector3 newFocus = this.transform.position + direction * 0.6f;

            //...then moves towards the player
            navAgent.SetDestination(newFocus);
        }

        //If the enemy object is within shooting range...
        else if (direction.magnitude <= shootDistance)
        {
            //... object faces the player...
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            //...then the shoot scrpt is called
            shooter.shootCannon();


        }

        //if the enemy distance to the player is higher than the chase distance...
        else
        {
           //...enemy ship just patrols round the environment
            nav.Patrol();
        }
    }
}
