using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unscrew : MonoBehaviour
{
    bool unscrewed = false, hasScrewDriver = false;
    public Transform handMountingPosition;

    void Update()
    {
        if (handMountingPosition.childCount > 0)
            hasScrewDriver = handMountingPosition.GetChild(0).name.Contains("ScrewDriver");
    }

    public void PointerClick()
    {
        if (!unscrewed && hasScrewDriver)
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            GameObject.Find("InnerBell").GetComponent<Rigidbody>().constraints = new RigidbodyConstraints();
            unscrewed = true;
        }
    }
}
