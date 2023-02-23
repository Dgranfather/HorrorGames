using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[RequireComponent(typeof(SignalReceiver))]
public class PlayerHealth : Interactable
{
    public int startingHealth;
    public int currentHealth;
    private Enemy theEnemy;
    [SerializeField] private float invulnerableTime;
    private bool onInvulnerable;

    [SerializeField] private GameObject _cutsceneToPlay;
    void Start()
    {
        currentHealth = startingHealth;
        theEnemy = FindObjectOfType<Enemy>();
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
            if (!theEnemy.cursing)
            {
                if (onInvulnerable == false)
                {
                    currentHealth--;
                    Active();
                    StartCoroutine(theEnemy.WarpandStunt(invulnerableTime));
                    if (currentHealth <= 0)
                    {
                        Debug.Log("dead");
                        // player is dead
                        // you can add code here to handle the death of the player
                        // for example, you can load a game over scene or restart the level
                    }
                }
            }
        }
    }

    public override void Active()
    {
        base.Active();
        _cutsceneToPlay.SetActive(true);
        PlayerControler.Instance.CutsceneCamera.SetActive(true);
        //PlayerControler.Instance.CutscenePlayerCamera.SetActive(true);
        PlayerControler.Instance.FirstPersonCamera.SetActive(false);
    }

    IEnumerator Invul()
    {
        onInvulnerable = true;
        //Physics.IgnoreLayerCollision(8, 11, true);
        yield return new WaitForSeconds(invulnerableTime);
        //Physics.IgnoreLayerCollision(8, 11, false);
        onInvulnerable = false;
    }

    public override void Deactive()
    {
        base.Deactive();
        _cutsceneToPlay.SetActive(false);
        PlayerControler.Instance.CutsceneCamera.SetActive(false);
        //PlayerControler.Instance.CutscenePlayerCamera.SetActive(false);
        PlayerControler.Instance.FirstPersonCamera.SetActive(true);
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
