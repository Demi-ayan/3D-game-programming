using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySpike());
    }

    //Function to destroy the game object is called after 5 seconds
    public IEnumerator DestroySpike()
    {
        yield return new WaitForSeconds(3);

        EndObject();
    }

    //Function to destroy the game object
    public void EndObject()
    {
        Destroy(gameObject);
    }
}
