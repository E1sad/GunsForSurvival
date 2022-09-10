using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using SOG.GamePlay.ResourceLine;
using SOG.GamePlay.Employee;
using SOG.GamePlay.Employee.Ui.Events;

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

    private void Update()
    {
      CheckResoruce();
    }

    private void CheckResoruce()
    {
      WoodResource = true;
      IronResource = true;
      AluminumResource = true;
      ChocalateResource = true;

      for (int j = 0; j < inventory.GetItemList().Count; j++)
      {
        if (inventory.GetItemList()[j].GetItemType() != ItemType.WOOD && WoodResource)
        {
          EventManager.Instance.Raise(new FullResourceEvent(ItemType.WOOD));
          WoodResource = false;
        }
        if (inventory.GetItemList()[j].GetItemType() != ItemType.IRON && IronResource)
        {
          EventManager.Instance.Raise(new FullResourceEvent(ItemType.IRON));
          IronResource = false;
        }
        if (inventory.GetItemList()[j].GetItemType() != ItemType.ALUMINUM && AluminumResource)
        {
          EventManager.Instance.Raise(new FullResourceEvent(ItemType.ALUMINUM));
          AluminumResource = false;
        }
        if (inventory.GetItemList()[j].GetItemType() != ItemType.CHOCOLATE && ChocalateResource)
        {
          EventManager.Instance.Raise(new FullResourceEvent(ItemType.CHOCOLATE));
          ChocalateResource = false;
        }
      }
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnTakeEvent>(OnTakeEventHandler);
      EventManager.Instance.AddListener<OnGiveEvent>(OnGiveEventHandler);
      EventManager.Instance.AddListener<InventoryListContainerTriggerEvent>(InventoryListContainerTriggerEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnTakeEvent>(OnTakeEventHandler);
      EventManager.Instance.RemoveListener<OnGiveEvent>(OnGiveEventHandler);
      EventManager.Instance.RemoveListener<InventoryListContainerTriggerEvent>(InventoryListContainerTriggerEventHandler);
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
    }

    private void InventoryListContainerTriggerEventHandler(InventoryListContainerTriggerEvent eventDetails)
    {
      EventManager.Instance.Raise(new InventoryListContainerEvent(inventory.GetItemList()));
    }
    #endregion
  }
}