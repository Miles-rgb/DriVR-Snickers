using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2Player : MonoBehaviour
{
    public Transform playercent; // use the VR camera here
    public CharacterController charc;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        charc.center = new Vector3(playercent.localPosition.x, 1.03f, playercent.localPosition.z);
    }
}
