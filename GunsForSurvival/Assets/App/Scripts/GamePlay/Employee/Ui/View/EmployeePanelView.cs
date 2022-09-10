using SOG.GamePlay.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SOG.GamePlay.Employee.Ui
{
  public class EmployeePanelView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private EmployeePanelController controller;

    [Header ("View properties")]
    [SerializeField] private Button woodButton;
    [SerializeField] private Button ironButton;
    [SerializeField] private Button aluminumButton;
    [SerializeField] private Button choclateButton;

    public void OnWoodButtonPressed()
    {
      controller.OnWoodButtonPressed();
    }

    public void OnIronButtonPressed()
    {
      controller.OnIronButtonPressed();
    }

    public void OnAluminumButtonPressed()
    {
      controller.OnAluminumButtonPressed();
    }

    public void OnChoclateButtonPressed()
    {
      controller.OnChoclateButtonPressed(); 
    }

    public void SetActivePanel(bool active)
    {
      gameObject.SetActive(active);
    }
    
    public void SetInteractable(ItemType item, bool active)
    {
      switch (item)
      {
        case ItemType.WOOD:
          woodButton.interactable = active;
          break;

        case ItemType.IRON:
          ironButton.interactable = active;
          break;

        case ItemType.ALUMINUM:
          aluminumButton.interactable = active;
          break;

        case ItemType.CHOCOLATE:
          choclateButton.interactable = active;
          break;
      }
    }

    public void ResetInteractable(bool active)
    {
      woodButton.interactable = active;
      ironButton.interactable = active;
      aluminumButton.interactable = active;
      choclateButton.interactable = active;
    }

    public void ResourcesFromInventory(List<Item> inventoryList)
    {

    }

  }
}

