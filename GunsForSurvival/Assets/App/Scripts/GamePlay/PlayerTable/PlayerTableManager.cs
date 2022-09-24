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
    private float time;

    private void Start()
    {
      timerText.text = time.ToString();
      time = _time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      timer.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      timer.SetActive(false);
    }

    private void Update()
    {
      time -= Time.deltaTime;
      timerText.text = Mathf.Round(time).ToString();
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

