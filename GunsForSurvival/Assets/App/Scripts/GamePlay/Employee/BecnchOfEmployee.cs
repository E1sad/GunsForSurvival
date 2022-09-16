using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.Employee
{
  public class BecnchOfEmployee : MonoBehaviour
  {
    [SerializeField] private EmployeeController controller;

    private void FixedUpdate()
    {
      controller.ProduceGun();
    }
  }
}

