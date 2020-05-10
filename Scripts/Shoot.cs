using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject CannonPrefab; //Game object variable for cannon ball

    public float shootForce = 100f;//A variable that stored the force of the cannon ball

    public StatsSystem stats; //A variable called to access a different script

    private bool shootable = true;//Check if player is able to shoot

    public AudioSource cannonSound;//Audio source variable for the shooting sound


    // Update is called once per frame
    void Update()
    {
        //If the 'Space' key is pressed, ammo is above 0 and 
        if (Input.GetKeyDown(KeyCode.Space) & stats.AmmoLeft > 0 && shootable)
        {
            //...Call coroutine for fire rate
            StartCoroutine(FireRate(0.5f));
            //Then the shoot function is called...
            shootCannon();
            //...and audio clip is played
            cannonSound.Play();
            //amount of ammo left is reduced by one
            stats.AmmoLeft--;
        }
    }

    void shootCannon()
    {
        //The game object is then spawned in
        GameObject instCannon = Instantiate(CannonPrefab, transform.position, transform.rotation);
        Rigidbody instCannonRb = instCannon.GetComponent<Rigidbody>();

        //Then a forward force is added to the game object's rigidbody
        instCannonRb.AddForce(transform.forward * shootForce, ForceMode.VelocityChange);
    }

    //waits certain amounts of seconds between each fire
    IEnumerator FireRate(float waitTime)
    {
        shootable = false;

        yield return new WaitForSeconds(waitTime);

        shootable = true;
    }
}
