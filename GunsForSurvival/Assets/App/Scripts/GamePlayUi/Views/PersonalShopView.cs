using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Controllers;

namespace SOG.GamePlayUi.Views
{
  public class PersonalShopView : MonoBehaviour
  {
    [Header ("Controller refernce")]
    [SerializeField] private PersonalShopController controller;

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

  }
}
