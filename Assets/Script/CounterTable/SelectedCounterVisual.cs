using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject selectedCounterVisual;
    private void Start()
    {
        if (Player.Instance == null)
        {
            Debug.LogError("Player.Instance is null!");
            return;
        }
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        // Debug.Log("Selected counter changed: " + (e.selectedCounter != null ? e.selectedCounter.name : "null"));

        if (e.selectedCounter == clearCounter)
        {
            ShowSelectedCounterVisual();
        }
        else
        {
            HideSelectedCounterVisual();
        }
    }


    private void ShowSelectedCounterVisual()
    {
        selectedCounterVisual.SetActive(true);
    }
    private void HideSelectedCounterVisual()
    {
        selectedCounterVisual.SetActive(false);
        //Debug.Log("Hide Selected Counter Visual");
    }
}
