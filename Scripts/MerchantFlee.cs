using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MerchantFlee : MonoBehaviour
{
    private NavMeshAgent _agent;

    //game object used to store player
    public GameObject Player;

    //a variable used to store the value of the run distance
    public float runDistance = 200f;

    public PlayerNav navG;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Flee() function is called
        Flee();

    }


    void Flee()
    {
        //This gets the magnitude of the distance between this game object and the player
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);

        //if the distance is less that the run distance...
        if (distance < runDistance)
        {
            //... get vector3 of the direction from the player
            Vector3 dirToPlayer = this.transform.position - Player.transform.position;

            //game object rotatates to the opposite direction from the player
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dirToPlayer), 0.1f);

            //Then moves in that direction
            Vector3 newPos = this.transform.position + dirToPlayer * 1.5f;

            _agent.speed = 15;

            //using the nav mesh agent
            _agent.SetDestination(newPos);
        }

        //if the distance is not less then run distance...
        else
        {
            _agent.speed = 10;
            //... patrol around the environment
            navG.Patrol();
        }
    }
}
