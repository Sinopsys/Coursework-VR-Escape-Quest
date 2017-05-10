using System;
using UnityEngine;

public class LastPuzzleLogic : MonoBehaviour
{
    char[] numbers;
    bool solved;
    float step;
    string key = "4118956";
    public GameObject Key;
    
    void Start()
    {
        solved = false;
        numbers = new char[7];
    }
    
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
                Key.SetActive(true);
                Key.GetComponent<Rigidbody>().constraints = new RigidbodyConstraints();
                gameObject.SetActive(false);
            }
        }
    }
}


// EOF
