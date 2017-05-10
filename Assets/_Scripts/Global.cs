using UnityEngine;

public class Global : MonoBehaviour
{
    public static bool withStone = false, cameWithStone = false;
    public Transform handMountingPosition;

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


// EOF
