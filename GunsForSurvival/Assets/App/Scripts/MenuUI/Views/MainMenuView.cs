using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
  [Header ("Controller reference")]
  [SerializeField] private MainMenuController controller;

  [Header("View properties")]
  [SerializeField] private Button playButton;
  [SerializeField] private Button settingsButton;
  [SerializeField] private Button creditsButton;
  [SerializeField] private Button quitButton;

  public void OnPlayButtonPressed()
  {
    SceneManager.LoadScene(1);
  }

  public void OnSettingsButtonPressed()
  {
    controller.OnSettingsButtonPressed();
  }

  public void OnCreditButtonPressed()
  {
    controller.OnCreditsButtonPressed();
  }

  public void OnQuitButtonPressed()
  {
    Application.Quit();
  }
}
