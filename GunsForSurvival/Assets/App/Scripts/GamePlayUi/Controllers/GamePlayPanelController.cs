using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Views;
using SOG.GamePlayUi.Events;
using UnityEngine.UI;
using DynamicBox.EventManagement;
using SOG.GamePlay.Employee.Ui.Events;
using SOG.GamePlay.ResourceLine;

namespace SOG.GamePlayUi.Controllers
{
  public class GamePlayPanelController : MonoBehaviour
  {
    [Header("View reference")]
    [SerializeField] private GamePlayPanelView view;

    public void BagButtonPressed()
    {
      EventManager.Instance.Raise(new OnGamePlayBagButtonPressed());
      view.SetActivePanel(false);
    }

    public void EmployeeButtonPressed()
    {
      EventManager.Instance.Raise(new OnGamePlayEmployeeButtonPressed());
    }

    public void ResourcesButtonPressed()
    {
      EventManager.Instance.Raise(new OnGamePlayResourcesButtonPressed());
    }

    public void FetchGunButtonPressed()
    {
      EventManager.Instance.Raise(new OnGamePlayFetchGunButtonPressed());
    }

    public void DeactiveButtons()
    {
      view.ButtonSetActive("Employee", false);
      view.ButtonSetActive("Bag", false);
      view.ButtonSetActive("Resource", false);
      view.ButtonSetActive("FetchGun", false);
    }

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnInventoryBackButtonPressed>(OnInventoryBackButtonPressedHandler);
      EventManager.Instance.AddListener<OnTriggerEnterEvent>(OnTriggerEnterEventHandler);
      EventManager.Instance.AddListener<OnEmployeeBagExitEvent>(OnEmployeeBagExitEventHandler);
      EventManager.Instance.AddListener<OnResourceLineTriggerEnter>(OnResourceLineTriggerEnterHandler);
      EventManager.Instance.AddListener<OnResourceLineTriggerExit>(OnResourceLineTriggerExitHandler);


    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnInventoryBackButtonPressed>(OnInventoryBackButtonPressedHandler);
      EventManager.Instance.RemoveListener<OnTriggerEnterEvent>(OnTriggerEnterEventHandler);
      EventManager.Instance.RemoveListener<OnEmployeeBagExitEvent>(OnEmployeeBagExitEventHandler);
      EventManager.Instance.RemoveListener<OnResourceLineTriggerEnter>(OnResourceLineTriggerEnterHandler);
      EventManager.Instance.RemoveListener<OnResourceLineTriggerExit>(OnResourceLineTriggerExitHandler);
    }
    #endregion

    #region Event Handlers
    private void OnInventoryBackButtonPressedHandler(OnInventoryBackButtonPressed eventDetails)
    {
      view.SetActivePanel(true);
    }

    private void OnTriggerEnterEventHandler(OnTriggerEnterEvent eventDetails)
    {
      DeactiveButtons();
      view.ButtonSetActive("Employee", true);
    }

    private void OnEmployeeBagExitEventHandler(OnEmployeeBagExitEvent eventDetails)
    {
      DeactiveButtons();
      view.ButtonSetActive("Bag", true);
    }

    private void OnResourceLineTriggerEnterHandler(OnResourceLineTriggerEnter eventDetails)
    {
      DeactiveButtons();
      view.ButtonSetActive("Resource", true);
    }

    private void OnResourceLineTriggerExitHandler(OnResourceLineTriggerExit evenDetails)
    {
      DeactiveButtons();
      view.ButtonSetActive("Bag", true);
    }
    #endregion
  }
}

