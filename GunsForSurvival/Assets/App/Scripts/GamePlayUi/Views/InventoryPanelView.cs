using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Controllers;
using UnityEngine.UI;
using SOG.GamePlay;
using TMPro;

namespace SOG.GamePlayUi.Views
{
  public class InventoryPanelView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private InventoryPanelController controller;

    [Header("View properties")]
    [SerializeField] private Button backButtonLeft;
    [SerializeField] private Button backButtonRight;
    [SerializeField] private Button[] ItemButtons;
    [SerializeField] private Image[] ItemIcon;
    [SerializeField] private TMP_Text[] ItemAmountText;

    [SerializeField] private Sprite Wood;
    [SerializeField] private Sprite Iron;
    [SerializeField] private Sprite Aluminum;
    [SerializeField] private Sprite Gun;

    private int indexOfInventory;

    private ItemType itemIndex1;
    private ItemType itemIndex2;
    private ItemType itemIndex3;
    private ItemType itemIndex4;

    public void BackButtonPressed()
    {
      ResetInventory();
      controller.BackButtonPressed();
    }

    public void Button1Pressed()
    {
      if (itemIndex1 != ItemType.CHOCOLATE && indexOfInventory>0)
      {
        DeleteOnButtonPressed(itemIndex1, 1);
      }
    }
    public void Button2Pressed()
    {
      if (itemIndex2 != ItemType.CHOCOLATE && indexOfInventory > 1)
      {
        DeleteOnButtonPressed(itemIndex2, 1);
      }
    }
    public void Button3Pressed()
    {
      if (itemIndex3 != ItemType.CHOCOLATE && indexOfInventory > 2)
      {
        DeleteOnButtonPressed(itemIndex3, 1);
      }
    }
    public void Button4Pressed()
    {
      if (itemIndex4 != ItemType.CHOCOLATE && indexOfInventory > 3)
      {
        DeleteOnButtonPressed(itemIndex4, 1);
      }
    }

    public void DeleteOnButtonPressed(ItemType item, int amount)
    {
      controller.DeleteOnButtonPressed(item, amount);
    }

    public void SetActivePanel(bool active)
    {
      gameObject.SetActive(active);
    }

    public void InventoryItemsCheck(ItemType item, int amount)
    {
      FindIndexItem(item,indexOfInventory);
      ItemIcon[indexOfInventory].sprite = FindSprite(item);
      ItemAmountText[indexOfInventory].text = ""+ amount;
      ItemAmountText[indexOfInventory].gameObject.SetActive(true);
      ItemIcon[indexOfInventory].gameObject.SetActive(true);
      indexOfInventory++;
    }

    public void FindIndexItem(ItemType item,int amount)
    {
      switch (amount)
      {
        case 0:
          itemIndex1 = item;
          break;
        case 1:
          itemIndex2 = item;
          break;
        case 2:
          itemIndex3 = item;
          break;
        case 3:
          itemIndex4 = item;
          break;
      }
    }

    public void ResetInventory()
    {
     itemIndex1 = ItemType.CHOCOLATE;
     itemIndex2 = ItemType.CHOCOLATE;
     itemIndex3 = ItemType.CHOCOLATE;
     itemIndex4 = ItemType.CHOCOLATE;
      for (int i = 0; i < ItemIcon.Length; i++)
      {
        ItemIcon[i].gameObject.SetActive(false);
        ItemAmountText[i].gameObject.SetActive(false);
        ItemAmountText[i].text = "0";
        indexOfInventory = 0;
      }
    }

    public Sprite FindSprite(ItemType item)
    {
      switch (item)
      {
        case ItemType.WOOD:
          return Wood;
        case ItemType.IRON:
          return Iron;
        case ItemType.ALUMINUM:
          return Aluminum;
        case ItemType.GUN:
          return Gun;
        default:
          return null;
      }
    }
  }
}