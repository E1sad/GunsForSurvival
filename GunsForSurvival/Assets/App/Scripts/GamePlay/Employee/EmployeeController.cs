using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlay.Employee.Ui.Events;

namespace SOG.GamePlay.Employee
{
  public class EmployeeController : MonoBehaviour
  {


    private void Start()
    {
      this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        this.enabled = true;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        EventManager.Instance.Raise(new OnEmployeeBagExitEvent());
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

  }
}