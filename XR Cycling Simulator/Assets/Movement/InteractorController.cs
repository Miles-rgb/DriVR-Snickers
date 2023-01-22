using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class InteractorController : MonoBehaviour
{
    public XRController leftInteractorRay;
    public XRController rightInteractorRay;
    public InputHelpers.Button interactorActivationButton;
    public float activationThreshold;

    public bool enableInteractor { get; set; } = true;
    // Update is called once per frame
    void Update()
    {
        if (leftInteractorRay)
        {
            leftInteractorRay.gameObject.SetActive(enableInteractor && CheckIfActivated(leftInteractorRay));
        }
        if (rightInteractorRay)
        {
            rightInteractorRay.gameObject.SetActive(enableInteractor && CheckIfActivated(rightInteractorRay));
        }
    }
    private bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, interactorActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
