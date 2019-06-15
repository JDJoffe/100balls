using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Var
    public GameObject[] prefabs = null;
    public float spawnRadius = 5f;
    public float spawnRate = 1f;
    public float spawnFactor = 0f;
    #endregion
    // Update is called once per frame
    void Update()
    {
        //timer handler
        HandleSpawn();
    }

    void HandleSpawn()
    {
        spawnFactor += Time.deltaTime;
        if (spawnFactor > spawnRate) //when timer reaches 1 second
        {
            int randomIndex = Random.Range(0, prefabs.Length); // get random index
            Spawn(prefabs[randomIndex]); // call spawn and spawn a random prefab
            spawnFactor = 0; //reset timer

        }
    }

    void Spawn(GameObject _object)
    {
        GameObject newObject = Instantiate(_object); //clone
        Vector3 randomPoint = Random.insideUnitCircle * spawnRadius; //generate random spawnpoint
        newObject.transform.position = transform.position + randomPoint; // set new position to be random
    }
}
