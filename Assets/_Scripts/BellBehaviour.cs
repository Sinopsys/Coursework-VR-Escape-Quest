using System.Collections;
using UnityEngine;

public class BellBehaviour : MonoBehaviour
{

    public Material bellHoverMaterial;
    public Material defaultBellMaterial;
    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = this.GetComponent<AudioSource>();
    }


    public void PatternLightUp(float duration)
    {
        StartCoroutine(LightFor(duration));
    }

    private void SimpleLightUp()
    {
        if (gameObject.name.CompareTo("BELL") == 0)
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = bellHoverMaterial;
        else
            gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<MeshRenderer>().material = bellHoverMaterial;
    }

    private void SimplePlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void MaterialReset()
    {
        if (gameObject.name.CompareTo("BELL") == 0)
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = defaultBellMaterial;
        else
            gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<MeshRenderer>().material = defaultBellMaterial;
    }

    public void PatternLightUp()
    {
        SimpleLightUp();
        SimplePlaySound();
        // Debug.Log("PatternLightUP");
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
        if (gameObject.name.CompareTo("BELL") != 0)
        {
            int bellSelected = int.Parse(gameObject.transform.name[gameObject.transform.name.Length - 1].ToString()) - 1;
            gameObject.transform.parent.gameObject.GetComponent<BellPuzzleLogic>().PlayerSelection(bellSelected);
        }
        audioSrc.Play();
    }
}


// EOF
