using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Controllers;

namespace SOG.GamePlayUi.Views
{
  public class FactoryShopView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private FactoryShopController controller;



    public void OnPressedBackbutton()
    {
      Debug.Log("Ouch!!!");
    }
  }
}
