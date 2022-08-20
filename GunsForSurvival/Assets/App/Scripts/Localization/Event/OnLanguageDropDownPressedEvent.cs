using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.Localization.Event
{
  public class OnLanguageDropDownPressedEvent : GameEvent
  {
    public int languageIndex;

    public OnLanguageDropDownPressedEvent(int _languageIndex)
    {
      languageIndex = _languageIndex;
    }
  }
}
