using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class AutoWalkByClick : MonoBehaviour
{
    public float speed = 10F;
    public bool moveForward;
    private CharacterController controller;
    private Transform vrHead;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        vrHead = Camera.main.transform;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
            moveForward = !moveForward;

        if (moveForward)
        {
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
    }
}


// EOF
