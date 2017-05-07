using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static bool withStone = false, cameWithStone = false;
    public Transform handMountingPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        withStone = false;

        if (handMountingPosition == null)
            handMountingPosition = GameObject.Find("HandMountingPosition").transform;

        if (handMountingPosition.childCount > 0)
            withStone = handMountingPosition.GetChild(0).name == "Stone";
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
