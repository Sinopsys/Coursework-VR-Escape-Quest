using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoneChecker : MonoBehaviour
{
    private bool shown = false;
    public GameObject stone, completed, completedWithPashalka, character, restart;

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().Play();
        if (Global.cameWithStone)
            ExecuteEvents.Execute(stone, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        else
            stone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (!shown)
        {
            character.GetComponent<WalkByLook>().enabled = false;
            if (other.gameObject.name.CompareTo("Character") == 0 && Global.cameWithStone)
                StartCoroutine(ShowCompletedPashalka());
            else
                StartCoroutine(ShowCompleted());
            shown = true;
            restart.SetActive(true);
        }
    }

    private IEnumerator ShowCompleted()
    {
        completed.SetActive(true);
        float alpha = completed.transform.GetComponent<TextMesh>().color.a;

        while (alpha < 1F)
        {
            alpha += 0.1F;
            completed.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }

        yield return new WaitForSeconds(3F);

        while (alpha > 0F)
        {
            alpha -= 0.1F;
            completed.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }
        character.GetComponent<WalkByLook>().enabled = true;

    }

    private IEnumerator ShowCompletedPashalka()
    {
        completedWithPashalka.SetActive(true);

        float alpha = completedWithPashalka.transform.GetComponent<TextMesh>().color.a;

        while (alpha < 1F)
        {
            alpha += 0.1F;
            completedWithPashalka.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }

        yield return new WaitForSeconds(7F);

        while (alpha > 0F)
        {
            alpha -= 0.1F;
            completedWithPashalka.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }
        character.GetComponent<WalkByLook>().enabled = true;

    }
}
