using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRSlider : MonoBehaviour
{
    public float fillTime = 2f;
    public int Scene = 1;
    private Slider mySlider;
    private float timer;
    private bool gazedAt;
    private Coroutine fillBarRoutine;

    void Start()
    {
        mySlider = GetComponent<Slider>();
        //if (mySlider == null)
        //    Debug.Log("Please Add a slider component to this GameObject");
    }

    public void PointerEnter()
    {
        gazedAt = true;
        fillBarRoutine = StartCoroutine(FillBar());
    }


    public void PointerExit()
    {
        gazedAt = false;
        if (fillBarRoutine != null)
            StopCoroutine(fillBarRoutine);
        timer = 0f;
        mySlider.value = 0f;
    }
    private IEnumerator FillBar()
    {
        timer = 0f;
        while (timer < fillTime)
        {
            timer += Time.deltaTime;
            mySlider.value = timer / fillTime;
            yield return null;

            if (gazedAt)
                continue;
            timer = 0f;
            mySlider.value = 0f;
            yield break;
        }
        OnBarFilled();
    }

    private void OnBarFilled()
    {
        GameObject obj = (GameObject)GazeInputModule.pointingAt[0];
        if (obj != null)
            ExecuteEvents.Execute(obj, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
    }

}


// EOF
