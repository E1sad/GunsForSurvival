using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using SOG.UI.Views;
using SOG.UI.Events.SettingsMenu;
using SOG.Localization.Event;
namespace SOG.UI.Controllers
{
  public class SettingsMenuController : MonoBehaviour
  {
    [Header("View reference")]
    [SerializeField] private SettingsMenuView view;

    public void OnBackButtonPressed()
    {
      EventManager.Instance.Raise(new OnBackButtonPressed());
      view.SetDeactiveSettingsPanel();
    }

    public void OnLanguageDropDownPressed(int languageIndex)
    {
      EventManager.Instance.Raise(new OnLanguageDropDownPressedEvent(languageIndex));
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnSettingsButtonPressedEvent>(OnSettingsButtonPressedEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnSettingsButtonPressedEvent>(OnSettingsButtonPressedEventHandler);
    }

    #endregion

    #region Event Handlers
    private void OnSettingsButtonPressedEventHandler(OnSettingsButtonPressedEvent eventDetails)
    {
      view.SetActiveSettingsPanel();
    }

    #endregion

  }
}
