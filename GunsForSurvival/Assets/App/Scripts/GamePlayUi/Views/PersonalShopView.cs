using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Controllers;
using TMPro;

namespace SOG.GamePlayUi.Views
{
  public class PersonalShopView : MonoBehaviour
  {
    [Header ("Controller refernce")]
    [SerializeField] private PersonalShopController controller;

    [Header("View properties")]
    [SerializeField] private TMP_Text informationText;
    [SerializeField] private TMP_Text money;

    public void OnBackButtonPressed()
    {
      controller.OnBackButtonPressed();
    }

    public void OnSpeedGymButtonPressed()
    {
      controller.OnSpeedGymButtonPressed();
    }

    public void OnEngineringButtonPressed()
    {
      controller.OnEngineringButtonPressed();
    }

    public void OnSatisfactoryButtonPressed()
    {
      controller.OnSatisfactoryButtonPressed();
    }

    public void OnManagementButtonPressed()
    {
      controller.OnManagementButtonPressed();
    }

    public void SetActivePersonalShopView(bool Is)
    {
      gameObject.SetActive(Is);
    }

    public void SetInformationText(string information)
    {
      informationText.text = "" + information;
    }

    public void SetMoneyText(int _money)
    {
      money.text = "" + _money;
    }

  }
}
