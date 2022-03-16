using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesManager : MonoBehaviour
{
    [SerializeField] private List<Transform> interactables;
    
    public List<Transform> Interactables { get => interactables; }
    
    //Non-Serialized
    private Camera _mainCamera;
    
    //Events
    public static Action<Transform> AddToInteractablesEvent;
    public static Action<Transform> RemoveFromInteractablesEvent;

    //Subscribe to events
    private void Awake()
    {
        AddToInteractablesEvent += AddToInteractables;
        RemoveFromInteractablesEvent += RemoveFromInteractables;
    }
    
    /// <summary>
    /// Adds a transform to the interactables list
    /// </summary>
    /// <param name="interactable"></param>
    private void AddToInteractables(Transform interactable)
    {
        interactables.Add(interactable);
    }
    
    /// <summary>
    /// Removes a transform from the interactables list
    /// </summary>
    /// <param name="interactable"></param>
    private void RemoveFromInteractables(Transform interactable)
    {
        interactables.Remove(interactable);
    }

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        AllChildrenWorldToScreenPoint();
    }

    /// <summary>
    /// Moves all children to screen space to be interacted with the mouse
    /// </summary>
    private void AllChildrenWorldToScreenPoint()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            Transform child = this.transform.GetChild(i);
            child.position = _mainCamera.WorldToScreenPoint(child.position);

            child.localScale = Vector3.one * 100f;
        }
    }
}
