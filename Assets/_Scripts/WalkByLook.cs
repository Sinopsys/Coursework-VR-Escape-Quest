using UnityEngine;

public class WalkByLook : MonoBehaviour
{
    public float angle = 30F;
    public float speed = 5F;
    private bool moveForward;
    private CharacterController cc;
    public Transform vrCam;
    private bool lookingToObject = false;
    private bool mustLookToTheObject = false;
    void Start()
    {
        GazeInputModule.pointingAt = null;
        cc = GetComponent<CharacterController>();
        vrCam = Camera.main.transform;
    }

    void Update()
    {
        mustLookToTheObject = GazeInputModule.pointingAt != null;
        if (mustLookToTheObject)
            lookingToObject = (((bool)GazeInputModule.pointingAt[1] && (float)GazeInputModule.pointingAt[2] >= 4F)
                || !((bool)GazeInputModule.pointingAt[1]));

        moveForward = (vrCam.eulerAngles.x >= angle && vrCam.eulerAngles.x <= 80F);

        if (moveForward && (!mustLookToTheObject || (mustLookToTheObject && lookingToObject)))
        {
            Vector3 forward = vrCam.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
    }
}


// EOF
