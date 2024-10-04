using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliveredText;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        Show(false);
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Show(true);

            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
        }
        else
        {
            Show(false);
        }
    }

    private void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
}
