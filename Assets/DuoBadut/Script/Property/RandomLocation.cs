using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    public GameObject[] objects;
    public Transform[] locations;

    private void Start()
    {
        // Place each object at a random location
        foreach (GameObject obj in objects)
        {
            Transform randomLocation = GetRandomLocation();
            obj.transform.position = randomLocation.position;
            obj.transform.rotation = Quaternion.identity;
        }
    }

    private Transform GetRandomLocation()
    {
        // Pick a random location from the available locations
        int randomIndex = Random.Range(0, locations.Length);
        Transform randomLocation = locations[randomIndex];

        // Check if the location is already occupied
        foreach (GameObject obj in objects)
        {
            if (obj.transform.position == randomLocation.position)
            {
                // If the location is occupied, pick another one
                randomLocation = GetRandomLocation();
                break;
            }
        }

        return randomLocation;
    }
}
