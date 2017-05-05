using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public Vector3 handPosition;
    public Vector3 handRotation;
    Vector3 oldScale;
    public Transform handMountingPosition;
    public Transform vrCam;
    public float angle = 280F;
    private bool tilted;
    bool pickedUp = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pickedUp = handMountingPosition.childCount == 1;
        tilted = (vrCam.eulerAngles.x >= 275F && vrCam.eulerAngles.x <= 300F);
        //Debug.Log(vrCam.eulerAngles.x + " " + tilted);
        if (tilted)
            ThrowObject();
    }

    public void MoveToPlayersHand()
    {
        if (!pickedUp)
        {
            oldScale = gameObject.transform.localScale;
            gameObject.transform.parent = handMountingPosition;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.localPosition = handPosition;
            gameObject.transform.localScale = oldScale;
            gameObject.GetComponent<Rigidbody>().constraints = new RigidbodyConstraints();
        }
    }

    public void ThrowObject()
    {
        oldScale = gameObject.transform.localScale;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.transform.parent = null;
        gameObject.transform.localScale = oldScale;
    }
}


// EOF
