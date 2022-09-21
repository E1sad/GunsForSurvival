using DynamicBox.EventManagement;
using SOG.GamePlay.DemandController;
using SOG.GamePlayUi.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.EndOfDayManager
{
  public class EndOfDayManager : MonoBehaviour
  {

    [SerializeField] private float DayTime;
    private int Day;
    private int Demand = 20;

    #region SaveSystem
    public void FromSaveDay(int _day)
    {
      Day = _day;
    }
    #endregion

    private void Start()
    {
      //TEMPORARY
      Day = 0;
      //TEMPORARY
      NextDay();
    }

    public void DayCycle()
    {
      Invoke("EndOfDay", DayTime);
    }

    public void EndOfDay()
    {
      
      EventManager.Instance.Raise(new GetDayEvent(Day));
      EventManager.Instance.Raise(new EndOfDayMessageEvent());
    }

    public void NextDay()
    {
      NextDayDemand(Day);
      Day++;
      DayCycle();
      Debug.Log(Day);
    }

    private void NextDayDemand(int day)
    {
      Demand += day*2;
      EventManager.Instance.Raise(new DemandAmountEvent(Demand));
    }

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnNextDayButtonPressendEvent>(OnNextDayButtonPressendEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnNextDayButtonPressendEvent>(OnNextDayButtonPressendEventHandler);
    }

    #endregion

    #region Event handlers
    private void OnNextDayButtonPressendEventHandler(OnNextDayButtonPressendEvent eventDetails)
    {
      NextDay();
    }
    #endregion

  }
}

