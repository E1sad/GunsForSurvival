using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Views;
using SOG.GamePlayUi.Events;
using DynamicBox.EventManagement;
using UnityEngine.SceneManagement;

namespace SOG.GamePlayUi.Controllers
{
  public class EndOfDayController : MonoBehaviour
  {
    [Header("view reference")]
    [SerializeField] private EndOfDayView view;

    public void OnNextDayButtonPressed()
    {
      EventManager.Instance.Raise(new OnNextDayButtonPressendEvent());
      Debug.Log("Next Day!!!");
    }

    public void OnMenuButtonPressed()
    {
      EventManager.Instance.Raise(new OnMenuButtonPressedEvent());
      Debug.Log("Menu!!!");
      SceneManager.LoadScene(0);
    }

    public void OnSettingsButtonPressed()
    {
      EventManager.Instance.Raise(new OnSettingsButtonPressedEvent());
      Debug.Log("Settings!!!");
    }

    public void OnFactoryUpgradesButtonPressed()
    {
      EventManager.Instance.Raise(new OnFactoryUpgradesButtonPressedEvent());
      Debug.Log("FactoryUpgrades!!!");
    }

    public void OnPersonalUpgradesButtonPressed()
    {
      EventManager.Instance.Raise(new OnPersonalUpgradesButtonPressedEvent());
      Debug.Log("PersonalUpgrades!!!");
    }


    #region Unity Events
    private void OnEnable()
    {
      
    }

    private void OnDisable()
    {
      
    }
    #endregion



    #region Event Handlers


    #endregion

  }
}
