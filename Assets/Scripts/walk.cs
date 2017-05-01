using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class walk : MonoBehaviour
{
    // How fast to move
    public float speed = 10F;
    // Should I move forward or not
    public bool moveForward;
    // CharacterController script
    private CharacterController controller;
    // GvrViewer Script
    private GvrViewer gvrViewer;
    // VR Head
    private Transform vrHead;

    // Use this for initialization
    void Start()
    {
        // Find the CharacterController
        controller = GetComponent<CharacterController>();
        //Find the Viewer on Child 0
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
        // Find the VRhead
        vrHead = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

        // In the Google VR button...
        if (Input.GetButtonDown("Fire1"))
        {
            // Change state of moveForward
            moveForward = !moveForward;
        }

        //Check to see if I should move
        if (moveForward)
        {
            //Find the forward direction
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            // Tell Character Controller to move forward
            controller.SimpleMove(forward * speed);
        }
    }
}
