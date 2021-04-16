using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColorAudioController : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] Material redMaterial;
    [SerializeField] Material greenMaterial;
    [SerializeField] GameObject pushButton;

    private bool buttonIsRed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            pushButton.GetComponent<MeshRenderer>().material = greenMaterial;
            buttonIsRed = false;
        }
    }

    public void ButtonWasPressed()
    {
        if (!buttonIsRed)
        {
            audioSource.Play();
            pushButton.GetComponent<MeshRenderer>().material = redMaterial;
            buttonIsRed = true;
        }
        else
        {
            audioSource.Pause();
            pushButton.GetComponent<MeshRenderer>().material = greenMaterial;
            buttonIsRed = false;
        }
    }
}
