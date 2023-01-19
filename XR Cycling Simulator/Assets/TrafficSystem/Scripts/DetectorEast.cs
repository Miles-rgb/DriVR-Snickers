using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEast : MonoBehaviour
{
    public List<GameObject> isThereCar;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            isThereCar.Add(other.gameObject);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            isThereCar.Remove(other.gameObject);
        }
    }
}
