using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class Player : MonoBehaviour 
{ 
    private RaycastHit hit; 
    private Ray ray;
    public float rayDistance = 4;
    public Animator myAnimationController;
    //bool door = true;

    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        ray = new Ray(transform.position, transform.forward); 
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
  
        if (Physics.Raycast(ray, out hit)) 
        { 
            if (hit.distance < rayDistance) 
            { 
                print("something is detected");
                //print(hit.collider.gameObject.tag);

                if (hit.collider.gameObject.tag == "door") 
                { 
                    //print("There is a door!");
                    myAnimationController.SetBool("door_open", true);
       
                } else
                {
                    //print("closing ?");
                    myAnimationController.SetBool("door_open", false);
                }

            }



        }
    } 
}