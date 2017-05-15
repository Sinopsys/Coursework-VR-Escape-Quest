using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberChanger : MonoBehaviour
{
    int n;
    public float timeDelay = 1F;
    float currentTime = 0F;
    bool gazedAt = false;


    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeDelay && gazedAt)
        {
            Increment();
            currentTime = 0F;
        }
    }

    public void PointerEnter()
    {
        gazedAt = true;
    }

    public void PointerExit()
    {
        gazedAt = false;
    }

    public void Increment()
    {
        n = System.Convert.ToInt32(gameObject.GetComponent<TextMesh>().text);
        ++n;
        if (n > 9)
            n = 0;
        gameObject.GetComponent<TextMesh>().text = n.ToString();
    }
}


// EOF
