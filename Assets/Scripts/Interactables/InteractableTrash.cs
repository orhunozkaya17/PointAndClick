using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTrash : MonoBehaviour, IInteractable
{
    public static Action OnClickTrash;
    public void OnClickAction()
    {
        OnClickTrash?.Invoke();
    }
}
