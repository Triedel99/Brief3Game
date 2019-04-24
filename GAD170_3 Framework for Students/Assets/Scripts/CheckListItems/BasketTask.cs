using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tracks number of shots up to a target amount. Is told directly by Hoop via Unity Event. 
/// </summary>
public class BasketTask : CheckListItem
{
    public bool hasDroppedBall = false;

    public int numberOfRequiredHoops;
    public int numberOfHoopsScored;

    public override bool IsComplete { get { return hasDroppedBall; } }

    public override float GetProgress()
    {
        return hasDroppedBall? 1 : 0;
    }

    public override string GetStatusReadout()
    {
        return hasDroppedBall.ToString();
    }

    public override string GetTaskReadout()
    {
        return "Got Away from ya huh? ";
    }

    public void GameEvents_OnObjectReset(GameEvents.ObjectResetData data)
    {

        if (!hasDroppedBall && data.offendingCollider.attachedRigidbody != null && data.offendingCollider.attachedRigidbody.CompareTag("Ball"))
        {
            var ourData = new GameEvents.CheckListItemChangedData();
            ourData.item = this;
            ourData.previousItemProgress = GetProgress();

            hasDroppedBall = true;

            GameEvents.InvokeCheckListItemChanged(ourData);
        }
    }

    private void OnEnable()
    {
        GameEvents.OnObjectReset += GameEvents_OnObjectReset;
    }
    private void OnDisable()
    {
        GameEvents.OnObjectReset -= GameEvents_OnObjectReset;
    }
}
