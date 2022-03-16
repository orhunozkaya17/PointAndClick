using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBoard : MonoBehaviour, IInteractable
{
    public static Action OnClickBoard;
    public void OnClickAction()
    {
        OnClickBoard?.Invoke();
    }
}
