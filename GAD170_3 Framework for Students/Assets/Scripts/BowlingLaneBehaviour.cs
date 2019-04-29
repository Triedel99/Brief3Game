using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Simple bowling lane logic, is triggered externally by buttons that are routed
/// to the InitialiseRound, TalleyScore and ResetRack.
/// 
/// Future work;
///   Use the timer in update to limit how long a player has to bowl,
///   Detect that the player/ball is 'bowled' from behind the line
/// </summary>
public class BowlingLaneBehaviour : MonoBehaviour
{
    public GameObject pinPrefab;
    public GameObject bowlingBall;
    public Transform[] pinSpawnLocations;
    public Transform defaultBallLocation;

    public List<GameObject> PinCount;


    [ContextMenu("InitialiseRound")]
    public void InitialiseRound()
    {
        ResetRack();
        //Spawn pins in pin location
        foreach (var pinLoc in pinSpawnLocations)
        {
            GameObject newPin = Instantiate(pinPrefab, pinLoc.position, Quaternion.identity);
            PinCount.Add(newPin);
        }

    }

    public void BallReachedEnd()
    {
        //ball collides with end of bowling lane
        bowlingBall.transform.position = defaultBallLocation.position;

    }

    [ContextMenu("TalleyScore")]
    public void TalleyScore()
    {
        //every not in spawned rotation counts as a pin down
        foreach (GameObject T in PinCount)
        {
            if (T.transform.rotation.eulerAngles != Vector3.zero)
            {
                BowlingTask.UpdatePins?.Invoke(1);
            }
        }

    }

    [ContextMenu("ResetRack")]
    public void ResetRack()
    {
        //every pin is destory and removed from pin list
        for (int T = 0; T < PinCount.Count; T++)
        {
            Destroy(PinCount[T]);
            PinCount.Remove(PinCount[T]);
            T--;
        }
        BallReachedEnd();
    }

    protected void Update()
    {
        
    }
}
