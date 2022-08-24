using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Views;
using DynamicBox.EventManagement;
using SOG.GamePlayUi.Events;

namespace SOG.GamePlayUi.Controllers
{
  public class FactoryShopController : MonoBehaviour
  {
    [Header("View reference")]
    [SerializeField] private FactoryShopView view;



    public void OnBackButtonPressed()
    {
      view.SetActiveFacoryShopView(false);
      EventManager.Instance.Raise(new OnShopsBackbuttonPressedEvent());
    }

    public void OnNewEmployeeButtonPressed()
    {
      EventManager.Instance.Raise(new OnNewEmployeeButtonPressed());
    }

    public void OnEmployeeCourseButtonPressed()
    {
      EventManager.Instance.Raise(new OnEmployeeCourseButtonPressedEvent());
    }

    public void OnBagButtonPressed()
    {
      EventManager.Instance.Raise(new OnBagButtonPressed());
    }

    public void OnFactorySizeButtonPressed()
    {
      EventManager.Instance.Raise(new OnFactorySizeButtonPressedEvent());
    }

    #region Unity Events

    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnFactoryUpgradesButtonPressedEvent>(OnFactoryUpgradesButtonPressedEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnFactoryUpgradesButtonPressedEvent>(OnFactoryUpgradesButtonPressedEventHandler);
    }
    #endregion

    #region Event Handlers
    private void OnFactoryUpgradesButtonPressedEventHandler(OnFactoryUpgradesButtonPressedEvent eventDetails)
    {
      view.SetActiveFacoryShopView(true);
    }

    #endregion

  }
}
