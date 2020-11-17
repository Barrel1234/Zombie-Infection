using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject landingAreaPrefab;   
    public Transform playerSpawnPoints;
    
    private bool reSpawn = false;

    private Transform[] spawnPoints;
    private bool lastRespawnToggle = false;
    
    // The parent of the  spawn points 
	// Use this for initialization
	void Start () {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
        
             
        print(spawnPoints.Length);
	}
	
	// Update is called once per frame
	void Update () {
		  if(lastRespawnToggle != reSpawn)
        {
            Respawn();
            reSpawn = false; 
        } else
        {
            lastRespawnToggle = reSpawn;
        }
	}
    private void Respawn()
    {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position;
    }
    void OnFindClearArea()
    {
        Invoke("DropFlare", 5f); 

    }
    void DropFlare()
    {
        Instantiate(landingAreaPrefab, transform.position, transform.rotation);
    }
}
