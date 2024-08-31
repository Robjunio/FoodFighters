using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField] LifeController PlayerLifeController;
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text lifeValue;


    private void Start()
    {
        if (PlayerLifeController != null)
        {
            slider.maxValue = PlayerLifeController.enemyMaxLife;
            slider.value = PlayerLifeController.enemyMaxLife;
            lifeValue.text = slider.value.ToString() + "/" + slider.maxValue.ToString();
        }
    }

    private void Update()
    {
        if (PlayerLifeController != null)
        {
            slider.value = PlayerLifeController.currentLife;
            lifeValue.text = slider.value.ToString() + "/" + slider.maxValue.ToString();
        }
    }
}
