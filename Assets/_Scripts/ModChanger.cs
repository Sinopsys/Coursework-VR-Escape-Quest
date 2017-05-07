using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModChanger : MonoBehaviour
{

    public GameObject modeChooser;
    public static bool vrModeEnabled = false;
    private bool checked_ = false, assigned = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (!checked_)
        //{
        //    if (GameObject.Find("GvrViewerMain") != null)
        //    {
        //        GameObject.Find("GvrViewerMain").GetComponent<GvrViewer>().VRModeEnabled = vrModeEnabled;
        //        checked_ = true;
        //    }
        //}
    }

    public void Click()
    {
        vrModeEnabled = gameObject.transform.GetChild(0).GetComponent<Text>().text.Contains("VR");
        checked_ = true;
        SceneManager.LoadScene("MainMenu1_Scene");
        modeChooser.SetActive(false);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
