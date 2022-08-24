using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using SOG.MenuUI.Views;
using SOG.MenuUI.Events;

namespace SOG.MenuUI.Controllers
{
  public class MainMenuController : MonoBehaviour
  {
    [Header("View reference")]
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
}