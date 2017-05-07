using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoorAndLoadScene : MonoBehaviour
{
    public GameObject door;
    public static bool opened = false;
    public float timeToOpen = 0.6F;

    // Use this for initialization
    void Start()
    {
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator OnTriggerStay(Collider other)
    {
        if (!opened)
        {
            door.GetComponent<Animation>().Play();
            door.GetComponent<AudioSource>().Play();
            opened = true;
            yield return new WaitForSeconds(timeToOpen);
            if (Global.withStone)
                Global.cameWithStone = true;
            SceneManager.LoadScene("HouseInside1");
        }
    }
}


// EOF
