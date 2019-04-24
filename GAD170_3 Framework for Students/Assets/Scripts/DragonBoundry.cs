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

    public List<GameObject> myCoinCount, myWolfCount;

    public bool canSpawnCoin = false, spawnGoldWolf = false;
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
        if (canSpawnCoin == true)
        {
            for (int i = 0; i < CoinNumber; i++)
            {
                GameObject CoinClone = Instantiate(coinPrefab, SpawnPoint.position, Quaternion.identity);
                myCoinCount.Add(CoinClone);
            }
            canSpawnCoin = false;
        }


    }

    public void OnTriggerStay(Collider other)
    {
        pickUpText.text = "Can hold up if you have the Nerf Gun";
        if (player.syncHeldItemHere.transform.GetChild(0).gameObject.tag == "Gun" && player.gameObject.tag == "Player")
        {
            pickUpText.text = "Press 'Q' to Hold them up";
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //Debug.Log("1");
                CoinNumber = Random.Range(10, 20);
                canSpawnCoin = true;

            }

        }

    }


    private void OnTriggerExit(Collider other)
    {
        pickUpText.text = "";
    }
}
