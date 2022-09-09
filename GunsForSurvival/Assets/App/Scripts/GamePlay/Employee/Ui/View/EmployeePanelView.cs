using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SOG.GamePlay.Employee.Ui
{
  public class EmployeePanelView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private EmployeePanelController controller;

    [Header ("View properties")]
    [SerializeField] private Button woodButton;
    [SerializeField] private Button ironButton;
    [SerializeField] private Button aluminumButton;
    [SerializeField] private Button choclateButton;

    public void OnWoodButtonPressed()
    {
      controller.OnWoodButtonPressed();
    }

    public void OnIronButtonPressed()
    {
      controller.OnIronButtonPressed();
    }

    public void OnAluminumButtonPressed()
    {
      controller.OnAluminumButtonPressed();
    }

    public void OnChoclateButtonPressed()
    {
      controller.OnChoclateButtonPressed(); 
    }

    public void SetActivePanel(bool active)
    {
      gameObject.SetActive(active);
    }

  }
}

