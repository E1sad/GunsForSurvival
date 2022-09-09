using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlay.Employee;
using DynamicBox.EventManagement;
using SOG.GamePlay.Employee.Ui.Events;

namespace SOG.GamePlay.Employee.Ui
{
  public class EmployeePanelController : MonoBehaviour
  {
    [Header("view reference")]
    [SerializeField] private EmployeePanelView view;

    public void OnWoodButtonPressed()
    {
      EventManager.Instance.Raise(new OnGiveEvent(ItemType.WOOD, 1));
    }

    public void OnIronButtonPressed()
    {
      EventManager.Instance.Raise(new OnGiveEvent(ItemType.IRON, 1));
    }

    public void OnAluminumButtonPressed()
    {
      EventManager.Instance.Raise(new OnGiveEvent(ItemType.ALUMINUM, 1));
    }

    public void OnChoclateButtonPressed()
    {
      EventManager.Instance.Raise(new OnGiveEvent(ItemType.CHOCOLATE, 1));
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnEmployeeBagButtonPressedEvent>(OnEmployeeBagButtonPressedEventHandler);
      EventManager.Instance.AddListener<OnEmployeeBagExitEvent>(OnEmployeeBagExitEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnEmployeeBagButtonPressedEvent>(OnEmployeeBagButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<OnEmployeeBagExitEvent>(OnEmployeeBagExitEventHandler);
    }
    #endregion

    #region Event Handlers
    private void OnEmployeeBagButtonPressedEventHandler(OnEmployeeBagButtonPressedEvent eventDetails)
    {
      view.SetActivePanel(true);
    }

    private void OnEmployeeBagExitEventHandler(OnEmployeeBagExitEvent eventDetails)
    {
      view.SetActivePanel(false);
    }
    #endregion

  }
}