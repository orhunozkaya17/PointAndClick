using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{
    public static Action OnClickDoor;
    public void OnClickAction()
    {
        OnClickDoor?.Invoke();
    }
}
