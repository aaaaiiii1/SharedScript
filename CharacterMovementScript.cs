using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovementScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
  

    //NavMeshAgent variable control player movement
    public NavMeshAgent playerNavMeshAgent;
    //A Camera that follow player movement
    public Camera playerCamera;
    // Update is called once per frame
    private void Update()
    {
        //if the left button of is clicked
        if (Input.GetMouseButton(0))
        {
            //Unity cast a ray from the position of mouse cursor on-screen toward the 3D scene.
            Ray myRay = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit myRaycastHit;

            if (Physics.Raycast(myRay, out myRaycastHit))
            {
                //Assign ray hit point as Destination of Navemesh Agent (Player)
                playerNavMeshAgent.SetDestination(myRaycastHit.point);
            }
        }
    }
}
