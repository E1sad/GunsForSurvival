using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Views;
using SOG.GamePlayUi.Events;
using UnityEngine.UI;
using DynamicBox.EventManagement;
using SOG.GamePlay.Employee.Ui.Events;
using SOG.GamePlay.ResourceLine;
using SOG.GamePlay.Inventory;
using SOG.GamePlay.FetchGun;
using SOG.GamePlay.Employee;
using SOG.GamePlay;
using SOG.GamePlay.DemandController;
using SOG.GamePlay.EndOfDayManager;
using SOG.SettingsPanel;

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
      view.ButtonSetActive("TakeGun", true);
    }

    public void ResourcesButtonPressed()
    {
      EventManager.Instance.Raise(new OnGamePlayResourcesButtonPressed());
    }

    public void FetchGunButtonPressed()
    {
      EventManager.Instance.Raise(new OnGamePlayFetchGunButtonPressed());
    }

    public void TakeGunButtonPressed()
    {
      EventManager.Instance.Raise(new GunAmountRequestEvent());
    }

    public void OnSettingsButtonPressed()
    {
      EventManager.Instance.Raise(new OnSettingsButtonPressed());
      //view.SetActivePanel(false);
    }

    public void DeactiveButtons()
    {
      view.ButtonSetActive("Employee", false);
      view.ButtonSetActive("Bag", false);
      view.ButtonSetActive("Resource", false);
      view.ButtonSetActive("FetchGun", false);
      view.ButtonSetActive("TakeGun", false);
    }

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnInventoryBackButtonPressed>(OnInventoryBackButtonPressedHandler);
      EventManager.Instance.AddListener<OnTriggerEnterEvent>(OnTriggerEnterEventHandler);
      EventManager.Instance.AddListener<OnEmployeeBagExitEvent>(OnEmployeeBagExitEventHandler);
      EventManager.Instance.AddListener<OnResourceLineTriggerEnter>(OnResourceLineTriggerEnterHandler);
      EventManager.Instance.AddListener<OnResourceLineTriggerExit>(OnResourceLineTriggerExitHandler);
      EventManager.Instance.AddListener<OnFetchGunEnterEvent>(OnFetchGunEnterEventHandler);
      EventManager.Instance.AddListener<OnFetchGunExitEvent>(OnFetchGunExitEventHandler);
      EventManager.Instance.AddListener<CurrentStatusOfUIEvent>(CurrentStatusOfUIEventHandler);
      EventManager.Instance.AddListener<EndOfDayMessageEvent>(EndOfDayMessageEventHandler);
      EventManager.Instance.AddListener<OnNextDayButtonPressendEvent>(OnNextDayButtonPressendEventHandler);
      EventManager.Instance.AddListener<OnResumeButtonPressedEvent>(OnResumeButtonPressedEventHandler);
    }
    

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnInventoryBackButtonPressed>(OnInventoryBackButtonPressedHandler);
      EventManager.Instance.RemoveListener<OnTriggerEnterEvent>(OnTriggerEnterEventHandler);
      EventManager.Instance.RemoveListener<OnEmployeeBagExitEvent>(OnEmployeeBagExitEventHandler);
      EventManager.Instance.RemoveListener<OnResourceLineTriggerEnter>(OnResourceLineTriggerEnterHandler);
      EventManager.Instance.RemoveListener<OnResourceLineTriggerExit>(OnResourceLineTriggerExitHandler);
      EventManager.Instance.RemoveListener<OnFetchGunEnterEvent>(OnFetchGunEnterEventHandler);
      EventManager.Instance.RemoveListener<OnFetchGunExitEvent>(OnFetchGunExitEventHandler);
      EventManager.Instance.RemoveListener<CurrentStatusOfUIEvent>(CurrentStatusOfUIEventHandler);
      EventManager.Instance.RemoveListener<EndOfDayMessageEvent>(EndOfDayMessageEventHandler);
      EventManager.Instance.RemoveListener<OnNextDayButtonPressendEvent>(OnNextDayButtonPressendEventHandler);
      EventManager.Instance.RemoveListener<OnResumeButtonPressedEvent>(OnResumeButtonPressedEventHandler);
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

    private void OnFetchGunEnterEventHandler(OnFetchGunEnterEvent eventDetails)
    {
      DeactiveButtons();
      view.ButtonSetActive("FetchGun", true);
    }

    private void OnFetchGunExitEventHandler(OnFetchGunExitEvent eventDetails)
    {
      DeactiveButtons();
      view.ButtonSetActive("Bag", true);
    }

    private void CurrentStatusOfUIEventHandler(CurrentStatusOfUIEvent eventDetails)
    {
      view.SetDemandAndCurrentAmount(eventDetails.CurrentGunAmount, eventDetails.Demand);
    }

    private void EndOfDayMessageEventHandler(EndOfDayMessageEvent eventDetails)
    {
      view.SetActivePanel(false);
    }

    private void OnNextDayButtonPressendEventHandler(OnNextDayButtonPressendEvent eventDetails)
    {
      view.SetActivePanel(true);
    }

    private void OnResumeButtonPressedEventHandler(OnResumeButtonPressedEvent eventDetails)
    {
      view.SetActivePanel(true);
    }
      #endregion
  }
}

