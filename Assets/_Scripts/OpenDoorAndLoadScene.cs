using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoorAndLoadScene : MonoBehaviour
{

    public GameObject door;
    private bool opened;

    // Use this for initialization
    void Start()
    {
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (!opened)
        {
            door.GetComponent<Animation>().Play();
            opened = true;
            Debug.Log("opened");

            SceneManager.LoadScene("HouseInside1");
        }
    }
}


// EOF
