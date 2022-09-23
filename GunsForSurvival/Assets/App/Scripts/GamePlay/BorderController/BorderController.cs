using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DynamicBox.EventManagement;

namespace SOG.GamePlay.BorderController
{
  public class BorderController : MonoBehaviour
  {
    [SerializeField] private CinemachineConfiner CmCamera;
    [SerializeField] private PolygonCollider2D border1;
    [SerializeField] private PolygonCollider2D border2;
    [SerializeField] private GameObject playerBorder1;
    [SerializeField] private GameObject playerBorder2;



    private void Start()
    {
      CmCamera.m_BoundingShape2D = border1;
      playerBorder1.SetActive(true);
      playerBorder2.SetActive(false);
    }


    private void OnEnable()
    {
      EventManager.Instance.AddListener<BorderUpgradeEvent>(BorderUpgradeEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<BorderUpgradeEvent>(BorderUpgradeEventHandler);
    }

    private void BorderUpgradeEventHandler(BorderUpgradeEvent eventDetails)
    {
      CmCamera.m_BoundingShape2D = border2;
      playerBorder1.SetActive(false);
      playerBorder2.SetActive(true);
    }

  }
}

