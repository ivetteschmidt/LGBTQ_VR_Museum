﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ButtonLimiter : MonoBehaviour
{
    private Vector3 _startPos;
    private float buttonPushedHeight = 0.2f;
    private float lowestAcceptableHeight = 0.05f;
    private float coolDownPeriod = 1f;
    private bool buttonIsInteractable = true;
    public UnityEvent ButtonPressedEvent; // Added an event to remove hard dependency. 


    void Start()
    {
        if (ButtonPressedEvent == null)
            ButtonPressedEvent = new UnityEvent();
        
        _startPos = transform.localPosition;

        ///ButtonPressedEvent.AddListener(ButtonPressed); // <- How to add another listener without having to drag in in the hierachy 
        ///ButtonPressedEvent.RemoveListener(ButtonPressed)// <- How to clean up event listener
    }

    void LateUpdate()
    {
        if (transform.localPosition.y < buttonPushedHeight && buttonIsInteractable)
        {
            buttonIsInteractable = false;
            ButtonPressedEvent.Invoke();
           
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

    //void ButtonPressed()
    //{

    //}
}
