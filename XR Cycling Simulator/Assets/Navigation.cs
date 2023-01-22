using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public Transform waypoint;

    void Update()
    {
        transform.LookAt(waypoint);
    }
}
