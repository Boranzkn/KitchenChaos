using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void Start()
    {
        if (PlayerController.LocalInstance != null)
        {
            PlayerController.LocalInstance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
        }
        else
        {
            PlayerController.OnAnyPlayerSpawned += PlayerController_OnAnyPlayerSpawned;
        }
    }

    private void PlayerController_OnAnyPlayerSpawned(object sender, System.EventArgs e)
    {
        if (PlayerController.LocalInstance != null)
        {
            PlayerController.LocalInstance.OnSelectedCounterChanged -= Player_OnSelectedCounterChanged;
            PlayerController.LocalInstance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
        }
    }

    private void Player_OnSelectedCounterChanged(object sender, PlayerController.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
        {
            Show(true);
        }
        else
        {
            Show(false);
        }
    }

    private void Show(bool isShow)
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(isShow);
        }
    }
}
