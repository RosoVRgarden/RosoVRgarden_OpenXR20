using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{ 
    public Animator animator;
    public GameObject vrPlayer;

    private bool topToBottomState = true;
    private bool inMovement = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public void StartElevator()
    {
        print("StartElevator");

        if (inMovement == false)
        {
            print("inMovement");

            if (topToBottomState)
            {
                animator.SetTrigger("ElevatorTop2BottomTrigger");
                print("ElevatorTopToBottomTrigger");
           
            }
            else
            {
                animator.SetTrigger("ElevatorBotton2TopTrigger");
                print("ElevatorBotton2TopTrigger");
            }
           
            vrPlayer.transform.parent = gameObject.transform;
            inMovement = true;
        }
    }

    public void OnAnimationStartEvelevator()
    {

        print("OnAnimationStartEvelevator");

        if (topToBottomState == false)
        {
            vrPlayer.transform.parent = null;

            topToBottomState = true;
            inMovement = false;

        }


    }

    public void OnAnimationEndEvelevator()
    {

        print("OnAnimationEndEvelevator");

        if (topToBottomState == true)
        {

            vrPlayer.transform.parent = null;

            topToBottomState = false;
            inMovement = false;

        }
    }
}