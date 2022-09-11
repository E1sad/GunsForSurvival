using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlay.Employee.Ui.Events;
using SOG.GamePlay.Inventory;

namespace SOG.GamePlay.Employee
{
  public class EmployeeController : MonoBehaviour
  {

    private List<Item> benchItemList;

    private List<Item> inventoryList;

    private bool IsContain;

    private void Start()
    {
      benchItemList = new List<Item>();
      IsContain = false;
      this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        this.enabled = true;
        EventManager.Instance.Raise(new OnTriggerEnterEvent());
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        EventManager.Instance.Raise(new OnEmployeeBagExitEvent());
        EventManager.Instance.Raise(new TriggerExitResetResourcesEvent());
        this.enabled = false;
      }
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        EventManager.Instance.Raise(new OnEmployeeBagButtonPressedEvent());
      }
      checkBecnhResources();
    }

    private void AddItem(ItemType item, int amount)
    {
      for (int i = 0; i < benchItemList.Count; i++)
      {
        if (benchItemList[i].GetItemType() == item)
        {
            benchItemList[i].SetAmount((benchItemList[i].GetAmount() + amount));

            Debug.Log(benchItemList[i].GetItemType() + " remained in bench " + benchItemList[i].GetAmount());

            IsContain = true;

            break;
        }
        else
        {
          IsContain = false;
        }
      }


      if (!IsContain)
      {
        Item benchitem = new Item(item, amount);

        benchItemList.Add(benchitem);

        Debug.Log("Aded " + item + " to bench");
      }
    }

    private void checkBecnhResources()
    {
     
      for (int i = 0; i < benchItemList.Count; i++)
      {
        if (benchItemList[i].GetAmount() >= 3)
        {
          EventManager.Instance.Raise(new FullResourceEvent(benchItemList[i].GetItemType(), false));
        }
      }
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnGiveEvent>(OnGiveEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnGiveEvent>(OnGiveEventHandler);   
    }
    #endregion

    #region Event Handlers
    private void OnGiveEventHandler(OnGiveEvent eventDetails)
    {
      AddItem(eventDetails.item, eventDetails.amount);
    }
    #endregion

  }
}