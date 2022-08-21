using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Controllers;
using TMPro;
using UnityEngine.UI;

namespace SOG.GamePlayUi.Views
{
  public class EndOfDayView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private EndOfDayController controller;

    [Header("View properties")]
    [SerializeField] private TMP_Text dayCount;
    [SerializeField] private TMP_Text allMoney;
    [SerializeField] private TMP_Text dailyGain;
    [SerializeField] private TMP_Text dailyDemand;
    [SerializeField] private Image successfulImage;
    [SerializeField] private Image failedImage;
  }
}
