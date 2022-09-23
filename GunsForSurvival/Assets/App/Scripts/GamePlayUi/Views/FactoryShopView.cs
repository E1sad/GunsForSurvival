using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Controllers;
using DynamicBox.EventManagement;
using SOG.GamePlayUi.Events;
using TMPro;

namespace SOG.GamePlayUi.Views
{
  public class FactoryShopView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private FactoryShopController controller;

    [Header("View properties")]
    [SerializeField] private TMP_Text informationText;
    [SerializeField] private TMP_Text money;

    public void OnPressedBackbutton()
    {
      controller.OnBackButtonPressed();
    }

    public void OnNewEmployeeButtonPressed()
    {
      controller.OnNewEmployeeButtonPressed();
    }

    public void OnEmployeeCourseButtonPressed()
    {
      controller.OnEmployeeCourseButtonPressed();
    }

    public void OnBagButtonPressed()
    {
      controller.OnBagButtonPressed();
    }

    public void OnFactorySizeButtonPressed()
    {
      controller.OnFactorySizeButtonPressed();
    }

    public void SetActiveFacoryShopView(bool Is)
    {
      gameObject.SetActive(Is);
    }
    public void SetInformationText(string information)
    {
      informationText.text = "" + information;
      Invoke("ResetInfromationText", 2f);
    }

    private void ResetInfromationText()
    {
      informationText.text = "";
    }

    public void SetMoneyText(int _money)
    {
      money.text = "" + _money;
    }

  }
}
