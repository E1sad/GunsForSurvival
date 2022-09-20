using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Views;
using SOG.GamePlayUi.Events;
using DynamicBox.EventManagement;
using UnityEngine.SceneManagement;
using SOG.GamePlay.EndOfDayManager;

namespace SOG.GamePlayUi.Controllers
{
  public class EndOfDayController : MonoBehaviour
  {
    [Header("view reference")]
    [SerializeField] private EndOfDayView view;

    public void OnNextDayButtonPressed()
    {
      view.SetActiveEndOfDayView(false);
      EventManager.Instance.Raise(new OnNextDayButtonPressendEvent());
    }

    public void OnMenuButtonPressed()
    {
      view.SetActiveEndOfDayView(false);
      EventManager.Instance.Raise(new OnMenuButtonPressedEvent());
      Debug.Log("Menu!!!");
      SceneManager.LoadScene(0);
    }

    public void OnSettingsButtonPressed()
    {
      view.SetActiveEndOfDayView(false);
      EventManager.Instance.Raise(new OnSettingsButtonPressedEvent());
      Debug.Log("Settings!!!");
    }

    public void OnFactoryUpgradesButtonPressed()
    {
      view.SetActiveEndOfDayView(false);
      EventManager.Instance.Raise(new OnFactoryUpgradesButtonPressedEvent());
      Debug.Log("FactoryUpgrades!!!");
    }

    public void OnPersonalUpgradesButtonPressed()
    {
      view.SetActiveEndOfDayView(false);
      EventManager.Instance.Raise(new OnPersonalUpgradesButtonPressedEvent());
      Debug.Log("PersonalUpgrades!!!");
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnShopsBackbuttonPressedEvent>(OnShopsBackbuttonPressedEventHandler);
      EventManager.Instance.AddListener<EndOfDayMessageEvent>(EndOfDayMessageEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnShopsBackbuttonPressedEvent>(OnShopsBackbuttonPressedEventHandler);
      EventManager.Instance.RemoveListener<EndOfDayMessageEvent>(EndOfDayMessageEventHandler);
    }
    #endregion



    #region Event Handlers

    private void OnShopsBackbuttonPressedEventHandler(OnShopsBackbuttonPressedEvent eventDetails)
    {
      view.SetActiveEndOfDayView(true);
    }

    private void EndOfDayMessageEventHandler(EndOfDayMessageEvent eventDetails)
    {
      view.SetActiveEndOfDayView(true);
    }
    #endregion

  }
}
