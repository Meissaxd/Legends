using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField] private Image healthGlobe, manaGlobe;
   [SerializeField] private Slider xpSlider;
   [SerializeField] private PlayerHealth playerHealth;

   private void Update()
   {
      healthGlobe.fillAmount = playerHealth.GetHealthRatio();
   }
}
