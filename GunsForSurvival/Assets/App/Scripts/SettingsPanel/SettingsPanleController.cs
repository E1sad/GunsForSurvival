using DynamicBox.EventManagement;
using SOG.GamePlayUi.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SOG.SettingsPanel
{
  public class SettingsPanleController : MonoBehaviour
  {
    [Header("View reference")]
    [SerializeField] private SettingsPanelView view;


    public void OnResumeButtonPressed()
    {
      //EventManager.Instance.Raise(new OnResumeButtonPressedEvent());
      view.SetActivePanle(false);
    }

    public void OnMenuButtonPressed()
    {
      SceneManager.LoadScene(0);
    }


    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnSettingsButtonPressed>(OnSettingsButtonPressedHandler);
      EventManager.Instance.AddListener<OnSettingsButtonPressedEvent>(OnSettingsButtonPressedEventHandler);
    }
    
    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnSettingsButtonPressed>(OnSettingsButtonPressedHandler);
      EventManager.Instance.RemoveListener<OnSettingsButtonPressedEvent>(OnSettingsButtonPressedEventHandler);
    }

    private void OnSettingsButtonPressedHandler(OnSettingsButtonPressed eventDtails)
    {
      view.SetActivePanle(true);
    }

    private void OnSettingsButtonPressedEventHandler(OnSettingsButtonPressedEvent eventDetails)
    {
      view.SetActivePanle(true);
    }
  }
}

