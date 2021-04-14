using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLimiter : MonoBehaviour
{
    private Vector3 _startPos;
    private float buttonPushedHeight = 0.2f;
    private float lowestAcceptableHeight = 0.05f;
    private float coolDownPeriod = 1f;
    private bool buttonIsInteractable = true;
    private ButtonColorAudioController buttonMainController;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        buttonMainController = GetComponent<ButtonColorAudioController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.localPosition.y < buttonPushedHeight && buttonIsInteractable)
        {
            buttonIsInteractable = false;
            buttonMainController.ButtonWasPressed();
            StartCoroutine(Cooldown());
        }

        if (transform.localPosition.y < lowestAcceptableHeight || transform.localPosition.y > 0.8f || transform.localPosition.x < -0.001f || transform.localPosition.x > 0.001f || transform.localPosition.z < -0.001f || transform.localPosition.z > 0.001f)
        {
            transform.localPosition = new Vector3(_startPos.x, lowestAcceptableHeight, _startPos.z);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(coolDownPeriod);
        buttonIsInteractable = true;
    }
}
