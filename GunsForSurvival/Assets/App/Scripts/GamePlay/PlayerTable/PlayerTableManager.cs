using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DynamicBox.EventManagement;
using SOG.GamePlayUi.Events;

namespace SOG.GamePlay.PlayerTable
{
  public class PlayerTableManager : MonoBehaviour
  {
    [SerializeField] private GameObject timer;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float _time;

    private float second;
    private float minute;
    private float Generalsecond;
    private float time;

    private void Start()
    {
      timerText.text = time.ToString();
      time = _time;
    }

    private void Update()
    {
      time -= Time.deltaTime;
      Generalsecond = Mathf.Round(time);

      minute = Mathf.Round(Generalsecond / 60);
      second = Generalsecond % 60;
      timerText.text = minute.ToString() + ":" + second;
    }


    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnNextDayButtonPressendEvent>(OnNextDayButtonPressendEventHandler);
    }
    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnNextDayButtonPressendEvent>(OnNextDayButtonPressendEventHandler);

    }

    private void OnNextDayButtonPressendEventHandler(OnNextDayButtonPressendEvent eventDetails)
    {
      time = _time;
    }

  }
}

