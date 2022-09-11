using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Controllers;
using UnityEngine.UI;

namespace SOG.GamePlayUi.Views
{
  public class InventoryPanelView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private InventoryPanelController controller;

    [Header("View properties")]
    [SerializeField] private Button backButtonLeft;
    [SerializeField] private Button backButtonRight;

    public void BackButtonPressed()
    {
      controller.BackButtonPressed();
    }

    public void SetActivePanel(bool active)
    {
      gameObject.SetActive(active);
    }
  }
}