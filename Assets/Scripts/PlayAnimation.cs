using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator myAnimationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { 

            myAnimationController.SetBool("jump", true);
            //print("jump...");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){

            myAnimationController.SetBool("jump", false);
            //print("stop jumping...");
        }
    }
   
}
