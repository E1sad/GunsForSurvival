using DynamicBox.EventManagement;
using SOG.GamePlay.Employee.Ui.Events;
using SOG.GamePlay.EndOfDayManager;
using SOG.GamePlay.Inventory;
using SOG.GamePlay.ResourceLine;
using SOG.GamePlayUi.Events;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.Employee
{
  public class EmployeeController : MonoBehaviour
  {

    private List<Item> benchItemList;

    [SerializeField] private GameObject[] WoodResources;
    [SerializeField] private GameObject[] IronResources;
    [SerializeField] private GameObject[] AluminumResources;
    [SerializeField] private GameObject[] GunResources;

    private bool IsContain;

    private bool isProducable;

    private int GunAmount;

    [SerializeField] private float produceSpeed;


    #region Unity's Methods
    private void Start()
    {
      benchItemList = new List<Item>();
      isProducable = true;
      IsContain = false;
      GunAmount = 0;
      produceSpeed = 15f;
      this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        this.enabled = true;
        EventManager.Instance.Raise(new OnTriggerEnterEvent());
        checkBecnhResources();
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
    }
    #endregion

    #region Project's Methods

    private void AddItem(ItemType item, int amount)
    {
      for (int i = 0; i < benchItemList.Count; i++)
      {
        if (benchItemList[i].GetItemType() == item)
        {
          benchItemList[i].SetAmount((benchItemList[i].GetAmount() + amount));

          BenchResourcesIncrease(item, benchItemList[i].GetAmount());

          //Debug.Log(benchItemList[i].GetItemType() + " remained in bench " + benchItemList[i].GetAmount());

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

        BenchResourcesIncrease(item, amount);

        //Debug.Log("Aded " + item + " to bench");
      }
    }

    private void RemoveItem(ItemType item, int amount)
    {
      for (int i = 0; i < benchItemList.Count; i++)
      {
        if (benchItemList[i].GetItemType() == item)
        {
          if (benchItemList[i].GetAmount() > 1)
          {

            benchItemList[i].SetAmount((benchItemList[i].GetAmount() - amount));

            BenchResourceDecrease(item, benchItemList[i].GetAmount());

            //Debug.Log(benchItemList[i].GetItemType() + " " + benchItemList[i].GetAmount());

            break;
          }
          else if (benchItemList[i].GetAmount() == 1)
          {
            //Debug.Log("Removed " + benchItemList[i].GetItemType());

            BenchResourceDecrease(item, 0);

            IsContain = false;

            benchItemList.Remove(benchItemList[i]);
          }
        }
      }
    }

    private void BenchResourcesIncrease(ItemType item, int amount)
    {
      for (int i = 0; i < amount; i++)
      {
        FindItem(item)[i].SetActive(true);
      }
    }

    private void BenchResourceDecrease(ItemType item, int amount)
    {
      for (int j = amount; j < 3; j++)
      {
        FindItem(item)[j].SetActive(false);
      }
    }

    private GameObject[] FindItem(ItemType item)
    {
      switch (item)
      {
        case ItemType.WOOD:
          return WoodResources;
        case ItemType.IRON:
          return IronResources;
        case ItemType.ALUMINUM:
          return AluminumResources;
        case ItemType.GUN:
          return GunResources;
        default:
          return null;
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
        //Debug.Log("Remain: " + benchItemList[i].GetAmount());
      }
    }

    private void TakeResourcesForProduceGun()
    {
      RemoveItem(ItemType.WOOD, 1);
      RemoveItem(ItemType.IRON, 1);
      RemoveItem(ItemType.ALUMINUM, 1);
      AddItem(ItemType.GUN, 1);
      isProducable = true;
      GunAmount++;
    }

    private bool CheckGunResources()
    {
      int correct = 0;
      for (int i = 0; i < benchItemList.Count; i++)
      {
        if (benchItemList[i].GetItemType() == ItemType.WOOD)
        {
          correct++;
        }
        if (benchItemList[i].GetItemType() == ItemType.IRON)
        {
          correct++;
        }
        if (benchItemList[i].GetItemType() == ItemType.ALUMINUM)
        {
          correct++;
        }
      }
      if (correct == 3)
      {
        return true;
      }
      return false;
    }

    public void ProduceGun()
    {
      if (CheckGunResources() && isProducable && GunAmount < 3)
      {
        Invoke("TakeResourcesForProduceGun", produceSpeed);
        isProducable = false;
      }
    }

    public void EndofDayReset()
    {
      //Debug.Log("EndofDayReset()");
      for (int i = 0; i < benchItemList.Count; i++)
      {
        //Debug.Log(benchItemList[i].GetItemType() + " :"+ benchItemList.Count + " :" + i);
        BenchResourceDecrease(benchItemList[i].GetItemType(), 0);
      }
      for (int i = 0; i < benchItemList.Count; i++)
      {
        //Debug.Log(benchItemList[i].GetItemType() + " :" + benchItemList.Count + " :" + i);
        benchItemList.Remove(benchItemList[i]);
        i = -1;
      }
      //Debug.Log("---------------");
    }

    public void ProduceSpeedUpgrade()
    {
      produceSpeed -= 2;
    }
    #endregion

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnGiveEvent>(OnGiveEventHandler);
      EventManager.Instance.AddListener<GunAmountRequestEvent>(GunAmountRequestEventHandler);
      
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnGiveEvent>(OnGiveEventHandler);
      EventManager.Instance.RemoveListener<GunAmountRequestEvent>(GunAmountRequestEventHandler);

    }
    #endregion

    #region Event Handlers
    private void OnGiveEventHandler(OnGiveEvent eventDetails)
    {
      AddItem(eventDetails.item, eventDetails.amount);
      checkBecnhResources();
    }

    private void GunAmountRequestEventHandler(GunAmountRequestEvent eventDetails)
    {
      if (GunAmount > 0)
      {
          RemoveItem(ItemType.GUN, 1);
          GunAmount--;
          checkBecnhResources();
        EventManager.Instance.Raise(new CheckResourcesEvent());
        EventManager.Instance.Raise(new OnTakeEvent(ItemType.GUN, 1));
      }
    }

      #endregion

    }
}