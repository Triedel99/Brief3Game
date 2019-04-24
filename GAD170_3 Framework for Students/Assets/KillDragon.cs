using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillDragon : MonoBehaviour
{
    public bool spawnGoldWolf = false;
    public GameObject Dragon;

    public TextMeshProUGUI pickUpText;

    public GameObject wolfPrefab;

    public List<GameObject> myWolfCount;

    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnGoldWolf == true)
        {
            Debug.Log("yesssssss");
            GameObject WolfClone = Instantiate(wolfPrefab, SpawnPoint.position, Quaternion.identity);
            myWolfCount.Add(WolfClone);
            spawnGoldWolf = false;
            pickUpText.text = "";
            Destroy(Dragon);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("no");
        if (other.gameObject.tag == "NerfDart")
        {
            Debug.Log("yes");
            spawnGoldWolf = true;
        }
    }
}
