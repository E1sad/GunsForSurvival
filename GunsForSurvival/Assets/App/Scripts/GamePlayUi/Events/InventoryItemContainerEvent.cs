using DynamicBox.EventManagement;
using SOG.GamePlay;

namespace SOG.GamePlayUi.Events
{
  public class InventoryItemContainerEvent : GameEvent
  {
    public ItemType item;

    public int amount;

    public InventoryItemContainerEvent(ItemType _item, int _amount)
    {
      item = _item;

      amount = _amount;
    }
  }
}

