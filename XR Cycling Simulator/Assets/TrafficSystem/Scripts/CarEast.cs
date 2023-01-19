using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CarEast : MonoBehaviour
{
    public int WhichWay;
    public Trafficmanager Path;
    public float distanceTravelled;
    private bool moving;
    public DetectorEast isThereCar;
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
        if (Path.East.Contains(this.gameObject) && Path.West.Count != 0 || isThereCar.isThereCar.Count != 0)
        {
            moving = false;
        }
    }
    public void Move()
    {
        if (WhichWay == 1)
        {
            distanceTravelled += 2 * Time.deltaTime;
            transform.position = Path.PEastToStraight.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = Path.PEastToStraight.path.GetRotationAtDistance(distanceTravelled);
            EndOfPath(Path.PEastToStraight.path.length);
        }

        if (WhichWay == 2)
        {
            distanceTravelled += 2 * Time.deltaTime;
            transform.position = Path.PEastToLeft.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = Path.PEastToLeft.path.GetRotationAtDistance(distanceTravelled);
            EndOfPath(Path.PEastToLeft.path.length);
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
