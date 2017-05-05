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
    //private float angle = 280F;
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
        //if (pickedUp)
        //    pickedUp = handMountingPosition.GetChild(0).name.CompareTo(gameObject.name) == 0;
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
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().constraints = new RigidbodyConstraints();
            gameObject.transform.localScale = oldScale;

            gameObject.transform.localPosition = new Vector3(0F, 0F, 0F);
            gameObject.transform.localRotation = Quaternion.Euler(0F, 0F, 0F);
            handMountingPosition.localRotation = Quaternion.Euler(handRotation);
            handMountingPosition.localPosition = handPosition;
            handMountingPosition.localScale = new Vector3(1F, 1F, 1F);
        }
    }

    public void ThrowObject()
    {
        if (pickedUp && handMountingPosition.GetChild(0).name.CompareTo(gameObject.name) == 0)
        {
            //oldScale = gameObject.transform.localScale;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Collider>().enabled = true;
            gameObject.transform.parent = null;
            gameObject.transform.localScale = oldScale;
        }
    }
}


// EOF
