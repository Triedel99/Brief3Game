using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used while held acts as a physics based projectile instantiator
/// </summary>
public class NerfGunItem : InteractiveItem
{
    public GameObject nerfDartPrefab;
    public Transform nerfDartSpawnLocation;
    public float fireRate = 1;
    public float launchForce = 10;
    protected float fireRateCounter;
    public List<GameObject> myNerfBulletCount;


    protected void Update()
    {

    }

    public override void OnUse()
    {
        base.OnUse();
        FireNow();

        //TODO: we need to determine if we can fire and if so, make the thing
    }

    public void FireNow()
    {
        //creating a new bullet
        GameObject BulletClone = Instantiate(nerfDartPrefab, nerfDartSpawnLocation.position, Quaternion.identity);
        myNerfBulletCount.Add(BulletClone);
        Invoke("CleanUpBullets", 5);
        //giving bullet a launch force
        BulletClone.GetComponent<Rigidbody>().AddForce(transform.forward * launchForce);

    }

    private void CleanUpBullets()
    {
        if (myNerfBulletCount.Count > 5)
        {
            //destroying bullets from list at index 0
            Destroy(myNerfBulletCount[0]);
            myNerfBulletCount.RemoveAt(0);
        }
    }
}
