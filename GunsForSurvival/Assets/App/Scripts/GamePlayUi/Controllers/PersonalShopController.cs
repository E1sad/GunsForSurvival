using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Views;
using SOG.GamePlayUi.Events;
using DynamicBox.EventManagement;

namespace SOG.GamePlayUi.Controllers
{
  public class PersonalShopController : MonoBehaviour
  {
    [Header ("View reference")]
    [SerializeField] private PersonalShopView view;

    public void OnBackButtonPressed()
    {
      view.SetActivePersonalShopView(false);
      EventManager.Instance.Raise(new OnShopsBackbuttonPressedEvent());
    }

    public void OnSpeedGymButtonPressed()
    {
      EventManager.Instance.Raise(new OnSpeedGymButtonPressedEvent());
    }

    public void OnEngineringButtonPressed()
    {
      EventManager.Instance.Raise(new OnEngineringCourseButtonPressedEvent());
    }

    public void OnSatisfactoryButtonPressed()
    {
      EventManager.Instance.Raise(new OnSatisfactoryCourseButtonPressedEvent());
    }

    public void OnManagementButtonPressed()
    {
      EventManager.Instance.Raise(new OnManagementCourseButtonPressedEvent());
    }

    #region Unity Events
    
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnPersonalUpgradesButtonPressedEvent>(OnPersonalUpgradesButtonPressedEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnPersonalUpgradesButtonPressedEvent>(OnPersonalUpgradesButtonPressedEventHandler);
    }

    #endregion

    #region Event Handlers
    
    private void OnPersonalUpgradesButtonPressedEventHandler(OnPersonalUpgradesButtonPressedEvent eventDetails)
    {
      view.SetActivePersonalShopView(true);
    }

    #endregion

  }
}
