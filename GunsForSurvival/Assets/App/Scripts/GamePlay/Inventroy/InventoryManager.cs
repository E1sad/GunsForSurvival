using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using SOG.GamePlay.ResourceLine;
using SOG.GamePlay.Employee;
using SOG.GamePlay.Inventory;
using SOG.GamePlay.Employee.Ui.Events;
using SOG.GamePlayUi.Events;
using SOG.GamePlay.FetchGun;

namespace SOG.GamePlay.Inventory
{
  public class InventoryManager : MonoBehaviour
  {
    [SerializeField] AudioClip onTakeClip, onGiveClip;

    [SerializeField] private int limit;

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
        EventManager.Instance.Raise(new InventoryItemContainerEvent(inventory.GetItemList()[j].GetItemType(), inventory.GetItemList()[j].GetAmount()));
      }
      EventManager.Instance.Raise(new CheckBenchResources());

    }


    private bool BagLimit()
    {
      int currentLimmit = 0;
      for (int i = 0; i < inventory.GetItemList().Count; i++)
      {
        currentLimmit += inventory.GetItemList()[i].GetAmount();
      }

      if (currentLimmit < limit)
      {
        return true;
      }
      else
      {
        return false;
      }
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnTakeEvent>(OnTakeEventHandler);
      EventManager.Instance.AddListener<OnGiveEvent>(OnGiveEventHandler);
      EventManager.Instance.AddListener<OnTriggerEnterEvent>(OnTriggerEnterEventHandler);
      EventManager.Instance.AddListener<OnGamePlayBagButtonPressed>(OnGamePlayBagButtonPressedHandler);
      EventManager.Instance.AddListener<InventoryItemDeleteEvent>(InventoryItemDeleteEventHandler);
      EventManager.Instance.AddListener<CheckResourcesEvent>(CheckResourcesEventHandler);
      EventManager.Instance.AddListener<TakeGunEvent>(TakeGunEventHandler);
      EventManager.Instance.AddListener<CheckLimitEvent>(CheckLimitEventHandler);
      
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnTakeEvent>(OnTakeEventHandler);
      EventManager.Instance.RemoveListener<OnGiveEvent>(OnGiveEventHandler);
      EventManager.Instance.RemoveListener<OnTriggerEnterEvent>(OnTriggerEnterEventHandler);
      EventManager.Instance.RemoveListener<OnGamePlayBagButtonPressed>(OnGamePlayBagButtonPressedHandler);
      EventManager.Instance.RemoveListener<InventoryItemDeleteEvent>(InventoryItemDeleteEventHandler);
      EventManager.Instance.RemoveListener<CheckResourcesEvent>(CheckResourcesEventHandler);
      EventManager.Instance.RemoveListener<TakeGunEvent>(TakeGunEventHandler);
      EventManager.Instance.RemoveListener<CheckLimitEvent>(CheckLimitEventHandler);
    }

    #endregion

    #region Events Handlers
    private void OnTakeEventHandler(OnTakeEvent eventDetails)
    {
      if (BagLimit())
      {
        SoundManager.Instance.PlaySound(onTakeClip);
        inventory.AddItem(eventDetails.item, eventDetails.amount);
      }
      else if (!BagLimit())
      {
        EventManager.Instance.Raise(new BagIsFullEvent());
      }
    }

    private void OnGiveEventHandler(OnGiveEvent eventDetails)
    {
      SoundManager.Instance.PlaySound(onGiveClip);
      inventory.RemoveItem(eventDetails.item, eventDetails.amount);
      EventManager.Instance.Raise(new InventoryResetEvent());
      CheckResoruce();
    }

    private void OnTriggerEnterEventHandler(OnTriggerEnterEvent eventDetails)
    {
      EventManager.Instance.Raise(new InventoryResetEvent());
      CheckResoruce();
    }

    private void OnGamePlayBagButtonPressedHandler(OnGamePlayBagButtonPressed eventDetails)
    {
      EventManager.Instance.Raise(new InventoryResetEvent());
      CheckResoruce();
    }

    private void InventoryItemDeleteEventHandler(InventoryItemDeleteEvent eventDetails)
    {
      inventory.RemoveItem(eventDetails.item, eventDetails.amount);
      EventManager.Instance.Raise(new InventoryResetEvent());
      CheckResoruce();
    }

    private void CheckResourcesEventHandler(CheckResourcesEvent eventDetails)
    {
      EventManager.Instance.Raise(new InventoryResetEvent());
      CheckResoruce();
    }

    private void TakeGunEventHandler(TakeGunEvent eventDetails)
    {
      for (int j = 0; j < inventory.GetItemList().Count; j++)
      {
        if (inventory.GetItemList()[j].GetItemType() == ItemType.GUN)
        {
          EventManager.Instance.Raise(new GunCheckInventoryEvent(true));
          inventory.RemoveItem(ItemType.GUN, 1);
          EventManager.Instance.Raise(new InventoryResetEvent());
          CheckResoruce();
        }
        else
        {
          EventManager.Instance.Raise(new GunCheckInventoryEvent(false));
        }
      }
    }

    private void CheckLimitEventHandler(CheckLimitEvent eventDetails)
    {
      if (BagLimit())
      {
        EventManager.Instance.Raise(new IsInLimitEvent(true));
      }
      else if(!BagLimit())
      {
        EventManager.Instance.Raise(new BagIsFullEvent());
        EventManager.Instance.Raise(new IsInLimitEvent(false));
      }
    }
    #endregion
  }
}