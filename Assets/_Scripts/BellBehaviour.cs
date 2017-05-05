using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellBehaviour : MonoBehaviour
{

    public Material bellHoverMaterial;
    public Material defaultBellMaterial;
    private AudioSource audioSrc;


    // Use this for initialization
    void Start()
    {
        audioSrc = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PatternLightUp(float duration)
    {
        StartCoroutine(LightFor(duration));
    }

    private void SimpleLightUp()
    {
        gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<MeshRenderer>().material = bellHoverMaterial;
    }

    private void SimplePlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void MaterialReset()
    {
        gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<MeshRenderer>().material = defaultBellMaterial;
    }

    public void PatternLightUp()
    {
        SimpleLightUp();
        SimplePlaySound();
        Debug.Log("PatternLightUP");
    }


    IEnumerator LightFor(float duration)
    {
        PatternLightUp();
        yield return new WaitForSeconds(duration - .1f);
        MaterialReset();
    }

    public void PointerEnter()
    {
        SimpleLightUp();
    }

    public void PointerExit()
    {
        MaterialReset();
    }

    public void PointerClick()
    {
        int bellSelected = int.Parse(gameObject.transform.name[gameObject.transform.name.Length - 1].ToString()) - 1;
        gameObject.transform.parent.gameObject.GetComponent<BellPuzzleLogic>().PlayerSelection(bellSelected);
        audioSrc.Play();
    }
}


// EOF
