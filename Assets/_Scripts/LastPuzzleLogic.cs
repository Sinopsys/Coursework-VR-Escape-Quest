using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPuzzleLogic : MonoBehaviour
{
    char[] numbers;
    bool solved;

    // Use this for initialization
    void Start()
    {
        solved = false;
        numbers = new char[7];
    }

    // Update is called once per frame
    void Update()
    {
        if (!solved)
        {
            int i = 0;
            foreach (Transform child in transform)
            {
                numbers[i] = child.GetComponent<TextMesh>().text[0];
                ++i;
            }

            if (new String(numbers).CompareTo("4118956") == 0)
            {
                solved = true;
                GameObject.Find("Door_a").GetComponent<Animation>().Play();
                OpenDoorAndLoadScene.opened = true;
                gameObject.SetActive(false);
            }
        }
    }
}


// EOF
