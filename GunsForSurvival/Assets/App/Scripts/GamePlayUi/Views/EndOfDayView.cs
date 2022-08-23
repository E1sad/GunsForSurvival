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
    [SerializeField] private GameObject successfulImage;
    [SerializeField] private GameObject failedImage;

    public void OnNextDayButtonPressed()
    {
      controller.OnNextDayButtonPressed();
    }

    public void OnMenuButtonPressed()
    {
      controller.OnMenuButtonPressed();
    }

    public void OnSettingsButtonPressed()
    {
      controller.OnSettingsButtonPressed();
    }

    public void OnFactoryUpgradesButtonPressed()
    {
      controller.OnFactoryUpgradesButtonPressed();
    }

    public void OnPersonalUpgradesButtonPressed()
    {
      controller.OnPersonalUpgradesButtonPressed();
    }

    public void SetActiveSuccessfulImage()
    {
      successfulImage.SetActive(true);
    }

    public void SetDeactiveSuccessfulImage()
    {
      successfulImage.SetActive(false);
    }

    public void SetActiveFailedImage()
    {
      failedImage.SetActive(true);
    }

    public void SetDeactiveFailedImage()
    {
      failedImage.SetActive(false);
    }

    public void SetDayCount(int day)
    {
      dayCount.text = "Day " + day;
    }

    public void SetAllMoney(int _allMoney)
    {
      allMoney.text = "Total money: " + _allMoney;
    }

    public void SetDailyGain(int gain)
    {
      dailyGain.text = "Daily gain: " + gain;
    }

    public void SetDailyDemand(int demand, int obtained)
    {
      dailyDemand.text = "Daily demand: " + obtained + "/" + demand;
    }


  }
}
