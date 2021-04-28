using UnityEngine;


// This is the script which will either enable gaze movement or controllers.
public class PlayerInit : MonoBehaviour
{
    [SerializeField] private OVRPlayerController ovrPlayerController;
    [SerializeField] private GameObject fpsController;
    [SerializeField] private GameObject locomotion;
    [SerializeField] private CharacterController charController;
    public bool Freemovement;

    bool oculusPresent = false;
    void CheckOculusPresence()
    {
        oculusPresent = OVRManager.isHmdPresent;
    }

    void Start()
    {
        CheckOculusPresence();
        OVRManager.HMDAcquired += CheckOculusPresence;
        OVRManager.HMDLost += CheckOculusPresence;

        if (!oculusPresent)
        {
            fpsController.SetActive(true);
            ovrPlayerController.gameObject.SetActive(false);
            return;
        }

        //if oculus present
        fpsController.SetActive(false);
        ovrPlayerController.gameObject.SetActive(true);

        if (Freemovement == true)
        {
            ovrPlayerController.enabled = true;
            charController.enabled = true;
            locomotion.SetActive(false);
        }
        else if (Freemovement == false) // teleportation enabled
        {
            charController.enabled = false;
            ovrPlayerController.enabled = false;
            locomotion.SetActive(true);
        }

    }
}
