using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using SOG.Localization.Event;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace SOG.Localization.Controller
{
  public class LocalizationController : MonoBehaviour
  {


    #region Unity Event
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnLanguageDropDownPressedEvent>(OnLanguageDropDownPressedEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnLanguageDropDownPressedEvent>(OnLanguageDropDownPressedEventHandler);
    }
    #endregion


    #region Event Handler
    private void OnLanguageDropDownPressedEventHandler(OnLanguageDropDownPressedEvent eventDetails)
    {
      List<Locale> availableLocales = LocalizationSettings.AvailableLocales.Locales;

      Locale currentSelectedLocale = availableLocales[eventDetails.languageIndex];

      LocalizationSettings.Instance.SetSelectedLocale(currentSelectedLocale);
    }

    #endregion

  }
}
