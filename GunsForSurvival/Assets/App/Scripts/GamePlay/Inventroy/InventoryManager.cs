using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using SOG.GamePlay.ResourceLine;
using SOG.GamePlay.Employee;
using SOG.GamePlay.Employee.Ui.Events;
using SOG.GamePlayUi.Events;

namespace SOG.GamePlay.Inventory
{
  public class InventoryManager : MonoBehaviour
  {
    private bool WoodResource;
    private bool IronResource;
    private bool AluminumResource;
    private bool ChocalateResource;

    private Inventory inventory;

    private void Awake()
    {
      inventory = new Inventory();
    }

    private void CheckResoruce()
    {
      EventManager.Instance.Raise(new FullResourceEvent(ItemType.WOOD, false));
      EventManager.Instance.Raise(new FullResourceEvent(ItemType.IRON, false));
      EventManager.Instance.Raise(new FullResourceEvent(ItemType.ALUMINUM, false));
      EventManager.Instance.Raise(new FullResourceEvent(ItemType.CHOCOLATE, false));
      for (int j = 0; j < inventory.GetItemList().Count; j++)
      {
        EventManager.Instance.Raise(new FullResourceEvent(inventory.GetItemList()[j].GetItemType(), true));
        Debug.Log(inventory.GetItemList().Count);
      }
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnTakeEvent>(OnTakeEventHandler);
      EventManager.Instance.AddListener<OnGiveEvent>(OnGiveEventHandler);
      EventManager.Instance.AddListener<OnTriggerEnterEvent>(OnTriggerEnterEventHandler);
    
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnTakeEvent>(OnTakeEventHandler);
      EventManager.Instance.RemoveListener<OnGiveEvent>(OnGiveEventHandler);
      EventManager.Instance.RemoveListener<OnTriggerEnterEvent>(OnTriggerEnterEventHandler);
    }

    #endregion

    #region Events Handlers
    private void OnTakeEventHandler(OnTakeEvent eventDetails)
    {
      inventory.AddItem(eventDetails.item, eventDetails.amount);
    }

    private void OnGiveEventHandler(OnGiveEvent eventDetails)
    {
      inventory.RemoveItem(eventDetails.item, eventDetails.amount);
      CheckResoruce();
    }

    private void OnTriggerEnterEventHandler(OnTriggerEnterEvent eventDetails)
    {
      CheckResoruce();
    }


    #endregion
  }
}