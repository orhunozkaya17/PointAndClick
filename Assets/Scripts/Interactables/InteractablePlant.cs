using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePlant : MonoBehaviour, IInteractable
{
    public static Action OnClickPlant;
    public void OnClickAction()
    {
        OnClickPlant?.Invoke();
    }
}
