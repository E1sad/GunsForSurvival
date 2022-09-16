using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Controllers;
using UnityEngine.UI;

namespace SOG.GamePlayUi.Views
{
  public class GamePlayPanelView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private GamePlayPanelController controller;

    [Header("View properties")]
    [SerializeField] private Button bagButton;
    [SerializeField] private Button employeeButton;
    [SerializeField] private Button takeGunButton;
    [SerializeField] private Button resourcesButton;
    [SerializeField] private Button fetchGunButton;

    public void BagButtonPressed()
    {
      controller.BagButtonPressed();
    }

    public void EmployeeButtonPressed()
    {
      controller.EmployeeButtonPressed();
    }

    public void ResourcesButtonPressed()
    {
      controller.ResourcesButtonPressed();
    }

    public void FetchGunButtonPressed()
    {
      controller.FetchGunButtonPressed();
    }

    public void TakeGunButtonPressed()
    {
      controller.TakeGunButtonPressed();
    }

    public void SetActivePanel(bool active)
    {
      gameObject.SetActive(active);
    }

    public void ButtonSetActive(string buttonName, bool active)
    {
      switch (buttonName)
      {
        case "Bag":
          bagButton.gameObject.SetActive(active);
          break;
        case "Employee":
          employeeButton.gameObject.SetActive(active);
          break;
        case "Resource":
          resourcesButton.gameObject.SetActive(active);
          break;
        case "FetchGun":
          fetchGunButton.gameObject.SetActive(active);
          break;
        case "TakeGun":
          takeGunButton.gameObject.SetActive(active);
          break;
      }
    }
  }
}

