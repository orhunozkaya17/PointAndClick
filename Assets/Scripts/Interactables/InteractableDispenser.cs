using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDispenser : MonoBehaviour, IInteractable
{
    public static Action OnClickDispenser;
    public void OnClickAction()
    {
        //Debug.Log("Clicked Dispenser");
        SoundManager.Instance.PlayClickSfx();
        OnClickDispenser?.Invoke();
    }
}
