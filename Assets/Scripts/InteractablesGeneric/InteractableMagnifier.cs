using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InteractableMagnifier : MonoBehaviour
{
    /// <summary>
    /// Animates the object transform by scaling it up and down, when mouse is over it.
    /// Plays a sound when mouse is over it.
    /// </summary>
    private void OnMouseEnter()
    {
        //Play hover sound
        SoundManager.Instance.PlayMouseOverSfx();
        //Animate with dotween
        this.transform.DOScale(new Vector3(this.transform.localScale.x+0.2f, this.transform.localScale.y+0.2f,this.transform.localScale.z+0.2f), 0.1f).SetLoops(2, LoopType.Yoyo);
    }
}
