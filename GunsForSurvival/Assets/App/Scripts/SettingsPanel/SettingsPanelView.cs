using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.SettingsPanel
{
  public class SettingsPanelView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private SettingsPanleController controller;

    public void OnResumeButtonPressed()
    {
      controller.OnResumeButtonPressed();
    }

    public void OnMenuButtonPressed()
    {
      controller.OnMenuButtonPressed();
    }

    public void SetActivePanle(bool active)
    {
      gameObject.SetActive(active);
    }
  }
}