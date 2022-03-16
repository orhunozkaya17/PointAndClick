using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCup : MonoBehaviour, IInteractable
{
    public static Action OnClickCup;
    public void OnClickAction()
    {
        //Debug.Log("Clicked on cup");
        SoundManager.Instance.PlayClickSfx();
        OnClickCup?.Invoke();
    }
}
