using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    [SerializeField] private Image barImage;

    private void Start()
    {
        cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;

        barImage.fillAmount = 0f;

        Show(false);
    }

    private void CuttingCounter_OnProgressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            Show(false);
        }
        else
        {
            Show(true);
        }
    }

    private void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
}