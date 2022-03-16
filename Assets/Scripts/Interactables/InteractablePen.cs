using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePen : MonoBehaviour, IInteractable
{
    public static Action OnClickPen;
    public void OnClickAction()
    {
        OnClickPen?.Invoke();
    }
}
