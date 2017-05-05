using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorOpener : MonoBehaviour
{
    public GameObject door;
    private static bool opened = false;
    public float timeToOpen = 1F;
    public Transform handMountingPosition;

    // Use this for initialization
    void Start()
    {
        opened = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (handMountingPosition.childCount > 0)
            gameObject.GetComponent<BoxCollider>().enabled = (handMountingPosition.GetChild(0).name.CompareTo("Key") == 0);
        //Debug.Log(gameObject.GetComponent<BoxCollider>().enabled);
    }

    public void PointerClick()
    {
        //Debug.Log("Begin opening door");
        StartCoroutine(OpenDoor());
    }

    private IEnumerator OpenDoor()
    {
        if (!opened)
        {
            // play unlock sound
            gameObject.GetComponents<AudioSource>()[0].Play();
            // show input Key and disable current holding Key
            transform.GetChild(0).gameObject.SetActive(true);
            handMountingPosition.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(1F);
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            gameObject.GetComponents<AudioSource>()[1].Play();
            door.GetComponent<Animation>().Play();
            opened = true;
            yield return new WaitForSeconds(timeToOpen);
        }
    }
}


// EOF
