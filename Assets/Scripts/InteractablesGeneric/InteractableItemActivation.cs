using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItemActivation : MonoBehaviour
{
    /// <summary>
    /// Adds this gameobject to the list of interactable items
    /// Interactable manager will check this list to interact with items
    /// </summary>
    private void OnEnable()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }
    
    /// <summary>
    /// Removes this gameobject from the list of interactable items
    /// </summary>
    private void OnDisable()
    {
        InteractablesManager.RemoveFromInteractablesEvent.Invoke(transform);
    }
}
