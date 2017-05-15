using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrappedInfo : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject.Find("GvrViewerMain").GetComponent<GvrViewer>().VRModeEnabled = ModChanger.vrModeEnabled;
        StartCoroutine(Show());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Show()
    {
        float alpha = gameObject.transform.GetComponent<TextMesh>().color.a;

        while (alpha < 1F)
        {
            alpha += 0.1F;
            gameObject.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }

        yield return new WaitForSeconds(10F);

        while (alpha > 0F)
        {
            //Debug.Log(alpha);
            alpha -= 0.1F;
            gameObject.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }
    }

}
