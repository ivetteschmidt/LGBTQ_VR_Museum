using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is the script which will either enable gaze movement or controllers.
public class PlayerInit : MonoBehaviour
{
    [SerializeField] private OVRPlayerController playrecontroller;
    [SerializeField] private GameObject locomotion;
    [SerializeField] private CharacterController charController;
    public bool Freemovement;


    // Start is called before the first frame update
    void Awake()
    {
        if (Freemovement == true)
        {
            playrecontroller.enabled = true;
            charController.enabled = true;
            locomotion.SetActive(false);
        }
        else if (Freemovement == false) // teleportation enabled
        {
            charController.enabled = false;
            playrecontroller.enabled = false;
            locomotion.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
