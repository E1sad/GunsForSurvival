using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class MainMenuController : MonoBehaviour
{
  [Header ("View reference")]
  [SerializeField] private MainMenuView view;

  public void OnSettingsButtonPressed()
  {
    EventManager.Instance.Raise(new OnSettingsButtonPressedEvent());
  }

  public void OnCreditsButtonPressed()
  {
    EventManager.Instance.Raise(new OnCreditsButtonPressedEvent());
  }

}
