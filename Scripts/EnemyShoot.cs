using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //Game object used to store the cannon ball
    public GameObject CannonPrefab;
    [Space (15)]

    //A variable that stored the force of the cannon ball
    public float shootForce = 100f;

    //Check if player is able to shoot
    private bool shootable = true;

    //Audio source variable for the shooting sound
    public AudioSource cannonSound;

    public void shootCannon()
    {
        //If the bool 'shootable' is true...
        if (shootable)
        {
            //...Call coroutine for fire rate
            StartCoroutine(FireRate(2f));
            //The game object is then spawned in
            GameObject instCannon = Instantiate(CannonPrefab, transform.position, transform.rotation);

            //...and audio clip is played
            cannonSound.Play();
            Rigidbody instCannonRb = instCannon.GetComponent<Rigidbody>();
            //Then a forward force is added to the game object's rigidbody
            instCannonRb.AddForce(transform.forward * shootForce, ForceMode.VelocityChange);
        }
      
    }

    //waits certain amounts of seconds between each fire
    IEnumerator FireRate(float waitTime)
    {
        shootable = false;

        yield return new WaitForSeconds(waitTime);

        shootable = true;
    }
}
