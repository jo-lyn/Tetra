using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelected : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Animator anim;
    public void OnSelect(BaseEventData eventData)
    {
        anim.Play("buttonSelected");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        anim.Play("buttonDeselected");
    }
}
