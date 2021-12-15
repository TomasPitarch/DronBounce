 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.EventSystems;
 using System.Collections;


public class UIButtonSoundEvent : MonoBehaviour, IPointerEnterHandler,IPointerClickHandler,
                                                 IPointerDownHandler,IPointerExitHandler,
                                                 IPointerUpHandler
{
    [SerializeField] string S_OnPointerClick;
    [SerializeField] string S_OnPointerDown;
    [SerializeField] string S_OnPointerEnter;
    [SerializeField] string S_OnPointerExit;
    [SerializeField] string S_OnPointerUp;

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("OnPointerClick");
        if (S_OnPointerClick != "")
        {
            SoundManager.Play(S_OnPointerClick);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("S_OnPointerDown");
        if (S_OnPointerDown != "")
        {
            SoundManager.Play(S_OnPointerDown);
        }
    }

    public void OnPointerEnter(PointerEventData ped)
    {
        //Debug.Log("onpointereo");
        if(S_OnPointerEnter!= "")
        {
            SoundManager.Play(S_OnPointerEnter);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("S_OnPointerExit");
        if (S_OnPointerExit != "")
        {
            SoundManager.Play(S_OnPointerExit);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("S_OnPointerUp");
        if (S_OnPointerUp != "")
        {
            SoundManager.Play(S_OnPointerUp);
        }
    }

}

