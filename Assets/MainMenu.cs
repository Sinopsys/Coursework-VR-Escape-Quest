using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(0.57647F, 0.76471F, 0.55294F);
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

    public void LoadLevel_N1()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Loading Level 1...");
    }

    public void Quit()
    {
        Debug.Log("Exitting from application...");
        Application.Quit();
    }
}
