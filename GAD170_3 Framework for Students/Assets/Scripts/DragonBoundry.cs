using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DragonBoundry : MonoBehaviour
{
    public PlayerItemInteraction player;

    public TextMeshProUGUI pickUpText;

    public GameObject coinPrefab, wolfPrefab;

    public List<GameObject> myCoinCount;

    public bool canSpawnCoin = false, spawnGoldWolf = false, canHoldUp = false, holdUpDone = false;
    public int CoinNumber;

    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItemInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canHoldUp == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //creating a number of coins to spawn
                CoinNumber = Random.Range(10, 20);
                //spawn a coin for every Coinnumber
                for (int i = 0; i < CoinNumber; i++)
                {
                    holdUpDone = true;
                    GameObject CoinClone = Instantiate(coinPrefab, SpawnPoint.position, Quaternion.identity);
                    myCoinCount.Add(CoinClone);
                    //after 1 second
                    Invoke("CoinMaximum", 1);
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //to determine if the dragon has alrigth been held up
        if (holdUpDone == false)
        { 
            //if player doesn't have the nerf gun
            pickUpText.text = "Can hold up if you have the Nerf Gun";
            if (player.syncHeldItemHere.transform.GetChild(0).gameObject.tag == "Gun" && player.gameObject.tag == "Player")
            {
                //
                pickUpText.text = "Press 'Q' to Hold them up";
                canHoldUp = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //make text nothing
        pickUpText.text = "";
        //not in range for the ability to hold up
        canHoldUp = false;
    }

    private void CoinMaximum()
    {
        //destory coin if over 50 coins starting a index 0
        if (myCoinCount.Count > 50)
        {
            Destroy(myCoinCount[0]);
            myCoinCount.RemoveAt(0);
        }
    }
}
