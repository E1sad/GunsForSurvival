using DynamicBox.EventManagement;
using SOG.GamePlay.DemandController;
using SOG.GamePlay.EndOfDayManager;
using SOG.GamePlayUi.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SOG.GamePlay.FetchGun
{
  public class FetchGunController : MonoBehaviour
  {
    [SerializeField] private int currentGun;

    #region Unity Methods
    private void Start()
    {
      this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        EventManager.Instance.Raise(new OnFetchGunEnterEvent());
        this.enabled = true;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        EventManager.Instance.Raise(new OnFetchGunExitEvent());
        this.enabled = false;
      }
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        EventManager.Instance.Raise(new TakeGunEvent());
      }
    }

    #endregion

    public void EndOfDay()
    {
      EventManager.Instance.Raise(new CurrentAmountEvent(currentGun));
      currentGun = 0;
      EventManager.Instance.Raise(new CurrentStatusOfUIEvent(currentGun, 0));
      Debug.Log(currentGun);
    }

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnGamePlayFetchGunButtonPressed>(OnGamePlayFetchGunButtonPressedHandler);
      EventManager.Instance.AddListener<GunCheckInventoryEvent>(GunCheckInventoryEventHandler);

    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnGamePlayFetchGunButtonPressed>(OnGamePlayFetchGunButtonPressedHandler);
      EventManager.Instance.RemoveListener<GunCheckInventoryEvent>(GunCheckInventoryEventHandler);

    }
    #endregion


    #region Event Handlers
    private void OnGamePlayFetchGunButtonPressedHandler(OnGamePlayFetchGunButtonPressed eventDetails)
    {
      EventManager.Instance.Raise(new TakeGunEvent());
    }

    private void GunCheckInventoryEventHandler(GunCheckInventoryEvent eventDetails)
    {
      if (eventDetails.active)
      {
        currentGun++;
        EventManager.Instance.Raise(new CurrentAmountEvent(currentGun));
        //Debug.Log(currentGun);
      }
    }
      #endregion
    }
}
