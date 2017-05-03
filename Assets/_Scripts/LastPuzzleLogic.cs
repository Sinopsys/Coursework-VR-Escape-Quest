using System;
using UnityEngine;

public class LastPuzzleLogic : MonoBehaviour
{
    char[] numbers;
    bool solved, wentOut;
    Transform character, target;
    float step;
    string key = "4118956";
    // Use this for initialization
    void Start()
    {
        solved = false;
        wentOut = false;
        numbers = new char[7];
        character = GameObject.Find("Character").gameObject.transform;
        target = GameObject.Find("FinishPos").gameObject.transform;
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

            if (new String(numbers).CompareTo(key) == 0)
            {
                solved = true;
                GameObject.Find("Door_a").GetComponent<Animation>().Play();
                OpenDoorAndLoadScene.opened = true;
                gameObject.SetActive(false);
            }
        }

        if (solved)
        {
            step = 4F * Time.deltaTime;
            character.position = Vector3.MoveTowards(character.position, target.position, step);
        }
    }
}


// EOF
