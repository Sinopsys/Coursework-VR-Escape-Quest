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
        moveForward = (vrCam.eulerAngles.x >= angle && vrCam.eulerAngles.x <= 80F);
        if (moveForward
            && (((bool)GazeInputModule.pointingAt[1] && (float)GazeInputModule.pointingAt[2] >= 4)
            || !((bool)GazeInputModule.pointingAt[1])))
        {
            Vector3 forward = vrCam.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
    }
}


// EOF
