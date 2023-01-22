using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnToMenu : MonoBehaviour
{
    public XRNode inputSource;
    private bool inputHome;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.secondaryButton, out inputHome);

        if (inputHome)
        {
            Loader.Load(Loader.Scene.MainMenu);
        }
    }
}
