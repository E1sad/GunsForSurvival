using DynamicBox.EventManagement;
using SOG.GamePlayUi.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SOG.GamePlay.FetchGun
{
  public class FetchGunController : MonoBehaviour
  {
    [SerializeField] private int DemandAmount;
    [SerializeField] private int cuurentGun;

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
        cuurentGun++;
        Debug.Log(cuurentGun);
      }
    }
    #endregion
  }
}
