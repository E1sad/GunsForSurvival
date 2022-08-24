using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Controllers;
using DynamicBox.EventManagement;
using SOG.GamePlayUi.Events;

namespace SOG.GamePlayUi.Views
{
  public class FactoryShopView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private FactoryShopController controller;

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


  }
}
