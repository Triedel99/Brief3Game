using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{

    //public PlayerItemInteraction Player;
    protected new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        //align to direction of travel if we are moving fast enough, small tolerance prevents jitter due to forcing a rotation on
        // an object with colliders that will then have new overlaps and be physic'ed apart
        //if (rigidbody.velocity.sqrMagnitude > 0.5f)
        //    transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized, Vector3.up);
    }
}
