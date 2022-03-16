using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [Header("Timeline References")]
    [SerializeField] private PlayableDirector pickUpPenCinematic;
    [SerializeField] private PlayableDirector drawOnBoardCinematic;
    [SerializeField] private PlayableDirector pickUpCupCinematic;
    [SerializeField] private PlayableDirector fillCupCinematic;
    [SerializeField] private PlayableDirector waterPlantCinematic;
    [SerializeField] private PlayableDirector trashCinematic;
    [SerializeField] private PlayableDirector openDoorCinematic;

    private void Start()
    {
        SubscribeToStoryEvents();
    }
    
    /// <summary>
    /// Subscribe to events related to the story
    /// </summary>
    void SubscribeToStoryEvents()
    {
        InteractablePen.OnClickPen += PlayPickUpPenCinematic;
        InteractableBoard.OnClickBoard += PlayDrawOnBoardCinematic;
        InteractableCup.OnClickCup += PlayPickUpCupCinematic;
        InteractableDispenser.OnClickDispenser += PlayFillCupCinematic;
        InteractablePlant.OnClickPlant += PlayWaterPlantCinematic;
        InteractableTrash.OnClickTrash += PlayTrashCinematic;
        InteractableDoor.OnClickDoor += PlayOpenDoorCinematic;
    }
    
    /// <summary>
    /// Play the timeline for picking up the pen
    /// Remove the event listener when the timeline is finished
    /// </summary>
    void PlayPickUpPenCinematic()
    {
        pickUpPenCinematic.Play();
        InteractablePen.OnClickPen -= PlayPickUpPenCinematic;
    }
    
    /// <summary>
    /// Same description as PenPickUp for all the other timelines
    /// </summary>
    void PlayDrawOnBoardCinematic()
    {
        drawOnBoardCinematic.Play();
        InteractablePen.OnClickPen -= PlayDrawOnBoardCinematic;
    }
    
    void PlayPickUpCupCinematic()
    {
        pickUpCupCinematic.Play();
        InteractableCup.OnClickCup -= PlayPickUpCupCinematic;
    }
    
    void PlayFillCupCinematic()
    {
        fillCupCinematic.Play();
        InteractableCup.OnClickCup -= PlayFillCupCinematic;
    }
    
    void PlayWaterPlantCinematic()
    {
        waterPlantCinematic.Play();
        InteractablePlant.OnClickPlant -= PlayWaterPlantCinematic;
    }
    
    void PlayTrashCinematic()
    {
        trashCinematic.Play();
        InteractableTrash.OnClickTrash -= PlayTrashCinematic;
    }
    
    void PlayOpenDoorCinematic()
    {
        openDoorCinematic.Play();
        InteractableDoor.OnClickDoor -= PlayOpenDoorCinematic;
    }
}
