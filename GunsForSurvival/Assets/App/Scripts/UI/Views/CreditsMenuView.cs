using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.UI.Controllers;
using UnityEngine.UI;

namespace SOG.UI.Views
{
  public class CreditsMenuView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private CreditsMenuController controller;

    [Header("View properties")]
    [SerializeField] private Button backButton;

    public void OnBackButtonPressed()
    {
      controller.OnBackButtonPressed();
    }

    public void SetActiveCreditsPanel()
    {
      gameObject.SetActive(true);
    }

    public void SetDeactiveCreditsPanel()
    {
      gameObject.SetActive(false);
    }
  }
}
