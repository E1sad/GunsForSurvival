using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SOG.MenuUI.Controllers;

namespace SOG.MenuUI.Views
{
  public class SettingsMenuView : MonoBehaviour
  {
    [Header("Controller refernce")]
    [SerializeField] private SettingsMenuController controller;

    [Header ("View properties")]
    [SerializeField] private Button backButton;

    public void OnBackButtonPressed()
    {
      controller.OnBackButtonPressed();
    }

    public void SetActiveSettingsPanel()
    {
      gameObject.SetActive(true);
    }
    public void SetDeactiveSettingsPanel()
    {
      gameObject.SetActive(false);
    }

    public void OnLanguageDropDownPressed(int languageIndex)
    {
      controller.OnLanguageDropDownPressed(languageIndex);
    }

  }
}
