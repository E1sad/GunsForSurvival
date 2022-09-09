using DynamicBox.EventManagement;

namespace SOG.GamePlay.Employee
{
  public class OnGiveEvent : GameEvent
  {
    public ItemType item;

    public int amount;

    public OnGiveEvent(ItemType _item, int _amount)
    {
      item = _item;

      amount = _amount;
    }
  }
}