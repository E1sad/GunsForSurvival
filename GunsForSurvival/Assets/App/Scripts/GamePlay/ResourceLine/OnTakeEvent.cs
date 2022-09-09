using DynamicBox.EventManagement;

namespace SOG.GamePlay.ResourceLine
{
  public class OnTakeEvent : GameEvent
  {
    public ItemType item;

    public int amount;

    public OnTakeEvent(ItemType _item, int _amount)
    {
      item = _item;

      amount = _amount;
    }
  }
}

