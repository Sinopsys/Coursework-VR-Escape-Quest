using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryLogic : MonoBehaviour
{

    public GameObject character, vrCam, guide, tryIt, glhf, stone, constraint;
    private bool freezeMove = true, thrown = false, shown = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ShowStory());
    }

    // Update is called once per frame
    void Update()
    {
        if (freezeMove)
            if (character.GetComponent<WalkByLook>() != null)
                character.GetComponent<WalkByLook>().enabled = false;

        thrown = stone.GetComponent<Rigidbody>().constraints == new RigidbodyConstraints() &&
            stone.GetComponent<BoxCollider>().enabled;

        if (thrown && !shown)
        {
            StartCoroutine(ShowGLFH()); shown = true;
            constraint.SetActive(false);
        }
    }

    IEnumerator ShowStory()
    {
        gameObject.SetActive(true);
        GameObject.Find("Play").GetComponent<BoxCollider>().enabled = false;
        // 10SECONDS
        yield return new WaitForSeconds(15F);
        Destroy(GameObject.Find("Play"));
        float alpha = GetComponent<TextMesh>().color.a;
        while (alpha > 0F)
        {
            //Debug.Log(alpha);
            alpha -= 0.1F;
            GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }

        alpha = guide.transform.GetComponent<TextMesh>().color.a;

        while (alpha < 1F)
        {
            alpha += 0.1F;
            guide.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }

        yield return new WaitForSeconds(7F);

        while (alpha > 0F)
        {
            //Debug.Log(alpha);
            alpha -= 0.1F;
            guide.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }

        alpha = tryIt.transform.GetComponent<TextMesh>().color.a;

        while (alpha < 1F)
        {
            alpha += 0.1F;
            tryIt.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }

        yield return new WaitForSeconds(3F);

        while (alpha > 0F)
        {
            //Debug.Log(alpha);
            alpha -= 0.1F;
            tryIt.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }

        freezeMove = false;
        character.GetComponent<WalkByLook>().enabled = true;
    }

    IEnumerator ShowGLFH()
    {
        float alpha = glhf.transform.GetComponent<TextMesh>().color.a;

        while (alpha < 1F)
        {
            alpha += 0.1F;
            glhf.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }

        yield return new WaitForSeconds(4F);

        while (alpha > 0F)
        {
            //Debug.Log(alpha);
            alpha -= 0.1F;
            glhf.transform.GetComponent<TextMesh>().color = new Color(255F, 255F, 255F, alpha);
            yield return new WaitForSeconds(0.01F);
        }
    }
}
