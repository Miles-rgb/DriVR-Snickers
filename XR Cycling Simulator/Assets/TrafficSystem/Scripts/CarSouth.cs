using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CarSouth : MonoBehaviour
{
    public int WhichWay;
    public Trafficmanager Path;
    public float distanceTravelled;
    public bool moving;
    public DetectorSouth isThereCar;
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
        if(isThereCar.isThereCar.Count != 0)
        {
            moving = false;
        }
    }
    public void Move()
    {
        if (WhichWay == 1)
        {
            distanceTravelled += 2 * Time.deltaTime;
            transform.position = Path.PSouthToLeft.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = Path.PSouthToLeft.path.GetRotationAtDistance(distanceTravelled);
            EndOfPath(Path.PSouthToLeft.path.length);
        }

        if (WhichWay == 2)
        {
            distanceTravelled += 2 * Time.deltaTime;
            transform.position = Path.PSouthToRight.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = Path.PSouthToRight.path.GetRotationAtDistance(distanceTravelled);
            EndOfPath(Path.PSouthToRight.path.length);
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
