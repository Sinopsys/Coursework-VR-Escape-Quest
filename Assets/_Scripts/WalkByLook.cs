using System.Collections;
using UnityEngine;

public class WalkByLook : MonoBehaviour
{
    public float angle1 = 30F, angle2 = 80F;
    public float speed = 5F;
    private bool moveForward;
    private CharacterController cc;
    public Transform vrCam;
    private bool lookingToObject = false;
    private bool mustLookToTheObject = false;
    public AudioSource[] footSteps;
    private bool shouldMove = false, playing = false;

    void Start()
    {
        GazeInputModule.pointingAt = null;
        cc = GetComponent<CharacterController>();
    }


    void Update()
    {
        shouldMove = false;
        mustLookToTheObject = GazeInputModule.pointingAt != null;
        if (mustLookToTheObject && GazeInputModule.pointingAt.Count > 0)
            lookingToObject = (((bool)GazeInputModule.pointingAt[1] && (float)GazeInputModule.pointingAt[2] >= 4F)
                || !((bool)GazeInputModule.pointingAt[1]));

        moveForward = (vrCam.eulerAngles.x >= angle1 && vrCam.eulerAngles.x <= angle2);

        if (moveForward && (!mustLookToTheObject || (mustLookToTheObject && lookingToObject)))
        {
            shouldMove = true;
            Vector3 forward = vrCam.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
            if (!playing)
                StartCoroutine(PlaySteps());
        }
    }
    private IEnumerator PlaySteps()
    {
        playing = true;
        for (int i = 0; i < footSteps.Length; ++i)
        {
            int k = Random.Range(0, 4);
            //Debug.Log(k);
            if (shouldMove)
                footSteps[k].Play();
            yield return new WaitForSeconds(0.65F);
        }
        playing = false;
    }
}


// EOF
