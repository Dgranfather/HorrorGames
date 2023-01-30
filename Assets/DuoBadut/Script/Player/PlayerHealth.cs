using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log("take damage");
    //        currentHealth--;
    //        if (currentHealth <= 0)
    //        {
    //            Debug.Log("dead");
    //            // player is dead
    //            // you can add code here to handle the death of the player
    //            // for example, you can load a game over scene or restart the level
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                Debug.Log("dead");
                // player is dead
                // you can add code here to handle the death of the player
                // for example, you can load a game over scene or restart the level
            }
        }
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if(hit.gameObject.tag == "Enemy")
    //    {
    //        currentHealth--;
    //        if (currentHealth <= 0)
    //        {
    //            Debug.Log("dead");
    //            // player is dead
    //            // you can add code here to handle the death of the player
    //            // for example, you can load a game over scene or restart the level
    //        }
    //    }
    //}
}
