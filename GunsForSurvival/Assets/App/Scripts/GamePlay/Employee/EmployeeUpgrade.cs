using DynamicBox.EventManagement;
using SOG.GamePlay.MoneyAndUpgrade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.Employee
{
  public class EmployeeUpgrade : MonoBehaviour
  {
    [SerializeField] private EmployeeController[] Employees;

    private int AmountofEmpoyees;


    private void Start()
    {
      AmountofEmpoyees = 3;
    }

    private void OnEnable()
    {
      EventManager.Instance.AddListener<newEmployeeEvent>(newEmployeeEventHandler);
      EventManager.Instance.AddListener<ProduceSpeedEvent>(ProduceSpeedEventHandler);
      
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<newEmployeeEvent>(newEmployeeEventHandler);
      EventManager.Instance.AddListener<ProduceSpeedEvent>(ProduceSpeedEventHandler);

    }

    private void newEmployeeEventHandler(newEmployeeEvent eventDetails)
    {
      AmountofEmpoyees++;
      for (int i = 0; i < AmountofEmpoyees; i++)
      {
        Employees[i].gameObject.SetActive(true);
      }
      for (int j = AmountofEmpoyees; j < Employees.Length; j++)
      {
        Employees[j].gameObject.SetActive(false);
      }
    }

    private void ProduceSpeedEventHandler(ProduceSpeedEvent eventDetails)
    {
      for (int j = 0; j < Employees.Length; j++)
      {
        Employees[j].ProduceSpeedUpgrade();
      }

    }
  }
}

