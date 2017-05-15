using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorOpener : MonoBehaviour
{
    public GameObject door, final;
    private static bool opened = false;
    private float timeToOpen = 1F;
    public Transform handMountingPosition;

    void Start()
    {
        opened = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        if (handMountingPosition.childCount > 0)
            gameObject.GetComponent<BoxCollider>().enabled = (handMountingPosition.GetChild(0).name.CompareTo("Key") == 0);
    }

    public void PointerClick()
    {
        StartCoroutine(LoadFinalScene());
        StartCoroutine(OpenDoor());
    }

    private IEnumerator LoadFinalScene()
    {
        final.SetActive(true);
        yield return null;
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
            OpenDoorAndLoadScene.opened = opened = true;
            yield return new WaitForSeconds(timeToOpen);
        }
    }
}


// EOF
