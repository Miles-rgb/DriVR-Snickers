using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Threading;

public class Trafficmanager : MonoBehaviour
{
    public List<GameObject> South;
    public List<GameObject> West;
    public List<GameObject> East;
    public GameObject CarWest;
    public GameObject CarEast;
    public GameObject CarSouth;
    public Transform WestSpawn;
    public Transform EastSpawn;
    public Transform SouthSpawn;
    public PathCreator PWestToRight;
    public PathCreator PWestToStraight;
    public PathCreator PSouthToRight;
    public PathCreator PSouthToLeft;
    public PathCreator PEastToStraight;
    public PathCreator PEastToLeft;

    private float delay = 3f;
    private float timer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnCars();
        }
        delay = UnityEngine.Random.Range(5, 15);
        timer += Time.deltaTime;
        if (timer > delay)
        {            
            SpawnCars();
            timer = 0;
        }
    }

    private void SpawnCars()
    {
        GameObject newCarWest = Instantiate(CarWest, WestSpawn.position, Quaternion.identity);
        GameObject newCarEast = Instantiate(CarEast, EastSpawn.position, Quaternion.identity);
        GameObject newCarSoouth = Instantiate(CarSouth, SouthSpawn.position, Quaternion.identity);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarWest")
        {
            West.Add(other.gameObject);
        }
        if (other.gameObject.tag == "CarSouth")
        {
            South.Add(other.gameObject);
        }
        if (other.gameObject.tag == "CarEast")
        {
            East.Add(other.gameObject);
        }
    }
        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "CarWest")
            {
                West.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "CarSouth")
            {
                South.Remove(other.gameObject);
            }
            if (other.gameObject.tag == "CarEast")
            {
                East.Remove(other.gameObject);
            }
        }
}
