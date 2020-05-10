using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public Transform[] spawnLocations;//An array for positions the game object can be spawned

    public bool spawnable = true;//A boolean to check if an object can be spawned

    public GameObject[] spawnObjects;//An array for game objects that can be spawned

    private void Start()
    {
        spawnable = true;
    }
    // Update is called once per frame
    void Update()
    {
        //if the bool spawnable is true 
        if (spawnable)
        {
            //Call the method WaitAndSpawn
            StartCoroutine(WaitAndSpawn());
        }

    }

    IEnumerator WaitAndSpawn()
    {
        spawnable = false;//Sets the bool to false
        float randWait = Random.Range(5, 20);//A variable for random time range between 5 and 20 seconds...
        yield return new WaitForSeconds(randWait);//...then waits the random amount of seconds
        float lengObj = spawnObjects.Length;//This checks the leanth of the array, and stores it in the variable lengObj
        float lengLoc = spawnLocations.Length;//This checks the leanth of the array, and stores it in the variable lengLoc
        Transform randSpawnLocation = spawnLocations[Mathf.FloorToInt(Random.Range(0, lengLoc))];//This chooses a random spawn location
        Instantiate(spawnObjects[Mathf.FloorToInt(Random.Range(0, lengObj))], randSpawnLocation.transform.position, randSpawnLocation.transform.rotation);//This spawns a random object from the array onto the spawn location
        spawnable = true;//Sets the bool back to true
    }
}
