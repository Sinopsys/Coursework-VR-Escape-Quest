using UnityEngine;

public class BellPuzzleLauncher : MonoBehaviour
{
    public Transform handMountingPosition;
    private bool hasBell = false;
    private float angle;
    public Transform vrCam;
    public GameObject bellPuzzle;
    public Transform firstToComplete, secondToComplete;
    private bool firstPut = false, secondPut = false;

    // Use this for initialization
    void Start()
    {
        firstToComplete = firstToComplete.GetChild(0);
        secondToComplete = secondToComplete.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (handMountingPosition.childCount > 0)
            hasBell = handMountingPosition.GetChild(0).name.Contains("Bell");
        angle = vrCam.eulerAngles.x;
        //Debug.Log(angle + " - " + (angle >= 338 && angle <= 355) + " hasBell: " + hasBell + " name: " + handMountingPosition.GetChild(0).name);
    }

    public void OnTriggerStay(Collider other)
    {
        //Debug.Log("Should place a bell");
        if ((other.name.CompareTo("Character") == 0) && hasBell && (angle >= 310F && angle <= 355F))
        {
            //Debug.Log(remainCount);

            if (!firstPut && !secondPut)
            {
                firstToComplete.GetChild(1).gameObject.SetActive(true);
                firstToComplete.GetChild(3).gameObject.SetActive(true);
                firstToComplete.GetChild(6).gameObject.SetActive(true);
                firstToComplete.GetChild(7).gameObject.SetActive(true);
                firstToComplete.parent.GetComponent<BoxCollider>().enabled = true;
                Destroy(handMountingPosition.GetChild(0).gameObject);
                hasBell = false;
                firstPut = true;
                return;
            }

            if (!secondPut && firstPut)
            {
                secondToComplete.GetChild(1).gameObject.SetActive(true);
                secondToComplete.GetChild(3).gameObject.SetActive(true);
                secondToComplete.GetChild(6).gameObject.SetActive(true);
                secondToComplete.GetChild(7).gameObject.SetActive(true);
                secondToComplete.parent.GetComponent<BoxCollider>().enabled = true;
                Destroy(handMountingPosition.GetChild(0).gameObject);
                hasBell = false;
                secondPut = true;
                BellPuzzleLogic.shouldStart = true;
                return;
            }
        }
    }
}


// EOF
