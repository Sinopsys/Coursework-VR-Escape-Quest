using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Michael : MonoBehaviour
{
    public float moveSpeed;

    // Use this for initialization
    void Start()
    {
        moveSpeed = 1F;
    }

    // Update is called once per frame
    void Update()
    {
        // print(Input.GetAxis("Horizontal"));

        //transform.Translate(0.1F * Time.deltaTime, 1F, 1F);

        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime,
            0,
            moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
