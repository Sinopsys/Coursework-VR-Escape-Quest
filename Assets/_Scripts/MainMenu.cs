using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject character, story;
    // Use this for initialization
    void Start()
    {
        character.GetComponent<WalkByLook>().enabled = false;

        GetComponent<Renderer>().material.color = new Color(0.57647F, 0.76471F, 0.55294F);
        GameObject.Find("GvrViewerMain").GetComponent<GvrViewer>().VRModeEnabled = ModChanger.vrModeEnabled;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToRed()
    {
        GetComponent<Renderer>().material.color = new Color(1F, 0F, 0F);
    }

    public void ChangeToGreen()
    {
        GetComponent<Renderer>().material.color = new Color(0.57647F, 0.76471F, 0.55294F);
    }

    public void Click()
    {
        if (gameObject.name.CompareTo("Play") == 0)
        {
            StartCoroutine(ShowStoryHideThis());
        }
        else
        {
            Debug.Log("Exitting from application...");
            Application.Quit();
        }
    }
    public IEnumerator ShowStoryHideThis()
    {
        float alpha = GetComponent<TextMesh>().color.a;
        while (alpha > 0F)
        {
            //Debug.Log(alpha);
            alpha -= 0.1F;
            GetComponent<TextMesh>().color = new Color(0.57647F, 0.76471F, 0.55294F, alpha);
            yield return new WaitForSeconds(0.01F);
        }
        GameObject.Find("Exit").SetActive(false);
        story.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, 0F);
        story.SetActive(true);
        alpha = story.transform.GetComponent<TextMesh>().color.a;
        while (alpha < 1F)
        {
            alpha += 0.1F;
            story.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }
        GameObject.Find("Exit");
    }
}


// EOF
