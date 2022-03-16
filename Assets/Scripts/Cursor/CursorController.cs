using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private InteractablesManager _interactablesManager;
    
    [SerializeField] private Texture2D _interactableCursorTexture;

    [SerializeField] private Transform newSelectionTransform;
    
    //Non-serialized
    private Transform _currentSelectionTransform;
    private Cursor _interactiveCursor;
    private CursorControls _cursorControls;
    private bool _cursorIsInteractive = false;
    
    //Cursor Actions
    public static Action MakeCursorDefault;
    public static Action MakeCursorInteractive;

    [Header("Settings")]
    [Tooltip("The distance the cursor can be from the object before it is considered to be selected")]
    public float DistanceThreshold;

    private void Awake()
    {
        //Controls Initialization
        _cursorControls = new CursorControls();
        //Events Registration
        _cursorControls.Mouse.Click.performed += _ => EndedClick();
        MakeCursorDefault += DefaultCursorTexture;
        MakeCursorInteractive += InteractiveCursorTexture;
    }

    private void OnEnable()
    {
        _cursorControls.Enable();
    }
    
    private void OnDisable()
    {
        _cursorControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        FindInteractableWithinDistanceThreshold();
    }
    
    /// <summary>
    /// Checks the mouse position to see if there is an interactable within the distance threshold
    /// If so,
    /// Changes the cursor to the interactable cursor
    /// </summary>
    private void FindInteractableWithinDistanceThreshold()
    {
        newSelectionTransform = null;
        
        for(int i = 0; i < _interactablesManager.Interactables.Count; i++)
        {
            Vector3 fromMouseToInteractableOffset =
                _interactablesManager.Interactables[i].position
                - new Vector3(
                    _cursorControls.Mouse.Position.ReadValue<Vector2>().x,
                    _cursorControls.Mouse.Position.ReadValue<Vector2>().y,
                    0f);
            float sqrMagnitude = fromMouseToInteractableOffset.sqrMagnitude;
            if (sqrMagnitude < DistanceThreshold * DistanceThreshold)
            {
                newSelectionTransform = _interactablesManager.Interactables[i].transform;
                
                if(!_cursorIsInteractive) InteractiveCursorTexture();
                break;
            }
        }

        if (_currentSelectionTransform != newSelectionTransform)
        {
            _currentSelectionTransform = newSelectionTransform;
            DefaultCursorTexture();
        }
    }
    
    /// <summary>
    /// Changes the cursor to the interactable cursor
    /// </summary>
    private void InteractiveCursorTexture()
    {
        _cursorIsInteractive = true;
        Vector2 hotspot = new Vector2
            (_interactableCursorTexture.width / 2f, 0);
        Cursor.SetCursor(_interactableCursorTexture, hotspot, CursorMode.Auto);
    }
    
    /// <summary>
    /// Changes the cursor to the default cursor
    /// </summary>
    private void DefaultCursorTexture()
    {
        _cursorIsInteractive = false;
        Cursor.SetCursor(default, default, default);
    }
    
    private void EndedClick()
    {
        OnClickInteractable();
    }
    
    /// <summary>
    /// If clicked on an interactable, call the interactable's OnClick method
    /// </summary>
    private void OnClickInteractable()
    {
        if (_currentSelectionTransform != null)
        {
            IInteractable interactable =
                newSelectionTransform.gameObject.GetComponent<IInteractable>();
            if(interactable != null) { interactable.OnClickAction(); }
            newSelectionTransform = null;
        }
    }
}
