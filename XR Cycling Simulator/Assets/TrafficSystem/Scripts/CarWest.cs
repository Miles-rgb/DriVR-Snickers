using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CarWest : MonoBehaviour
{
    public int WhichWay;
    public Trafficmanager Path;
    public float distanceTravelled;
    public bool moving;
    public DetectorWest isThereCar;
    void Start()
    {
        WhichWay = Random.Range(1, 3);
        Path = GameObject.FindObjectOfType<Trafficmanager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (moving)
        {
            Move();
        }
        moving = true;
        if(Path.West.Contains(this.gameObject) && Path.South.Count!=0 || isThereCar.isThereCar.Count!=0)
        {
            moving = false;
        }        
    }
    public void Move()
    {
        if (WhichWay == 1)
        {
            distanceTravelled += 2 * Time.deltaTime;
            transform.position = Path.PWestToRight.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = Path.PWestToRight.path.GetRotationAtDistance(distanceTravelled);
            EndOfPath(Path.PWestToRight.path.length);
        }

        if (WhichWay == 2)
        {
            distanceTravelled += 2 * Time.deltaTime;
            transform.position = Path.PWestToStraight.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = Path.PWestToStraight.path.GetRotationAtDistance(distanceTravelled);
            EndOfPath(Path.PWestToStraight.path.length);
        }
    }

    private void EndOfPath(float lenght)
    {
        if (distanceTravelled >= lenght)
        {
            Destroy(this.gameObject);
        }
    }
}
