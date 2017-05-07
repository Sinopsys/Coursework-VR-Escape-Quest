using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureLogic : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //gameObject.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().constraints.CompareTo(new RigidbodyConstraints()) == 0)
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }
}


// EOF
