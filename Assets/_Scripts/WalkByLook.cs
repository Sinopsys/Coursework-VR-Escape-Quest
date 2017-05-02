using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkByLook : MonoBehaviour
{

    public float angle = 30F;
    public float speed = 5F;
    private bool moveForward;
    private CharacterController cc;
    public Transform vrCam;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveForward = (vrCam.eulerAngles.x >= angle && vrCam.eulerAngles.x <= 90F);
        if (moveForward)
        {
            Vector3 forward = vrCam.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
    }
}
