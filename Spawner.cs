using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject botPrefab;

    private GameObject[] listOfBeacons;
    private int frequencySpawner;
    private int randomBeaconPick;
    private int counter;
    private bool b_hasSpawned;

    private int difficulty;

    void Start()
    {
        listOfBeacons = GameObject.FindGameObjectsWithTag("Beacon");
        b_hasSpawned = true;
        frequencySpawner = Random.Range(500, 1000);
        counter = 0;
    }


	// Update is called once per frame
	void Update () {



        //check if we've spawned one recently
        if(b_hasSpawned == false)
        {
            b_hasSpawned = true;

            if (difficulty < 10)
            {
                frequencySpawner = Random.Range(400, 600);
            }
            else if (difficulty > 10 && difficulty < 25)
            {
                frequencySpawner = Random.Range(200, 450);
            }
            else
            {
                frequencySpawner = Random.Range(150, 500);
            }
            
            randomBeaconPick = Random.Range(0, listOfBeacons.Length - 1);
            Debug.Log(randomBeaconPick);
            counter = 0;
            SpawnBot();
            difficulty++;
        }

        if (counter < frequencySpawner)
        {
            counter++;
        }
        //done waiting, time to spawn
        else
        {
            b_hasSpawned = false;

        }

	}
    void SpawnBot()
    {
        GameObject temp;
        //Debug.Log("Pos: " + listOfBeacons[randomBeaconPick].transform.position);
        temp = Instantiate(botPrefab, listOfBeacons[randomBeaconPick].transform) as GameObject;
        Transform temptran = listOfBeacons[randomBeaconPick].transform;

        temp.transform.position = temptran.position;
        temp.name = "Botcontainer";

    }
}
