using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Views;
using SOG.GamePlayUi.Events;
using DynamicBox.EventManagement;

namespace SOG.GamePlayUi.Controllers
{
  public class InventoryPanelController : MonoBehaviour
  {
    [Header("View reference")]
    [SerializeField] private InventoryPanelView view;

    public void BackButtonPressed()
    {
      view.SetActivePanel(false);
      EventManager.Instance.Raise(new OnInventoryBackButtonPressed());
    }

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnGamePlayBagButtonPressed>(OnGamePlayBagButtonPressedHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnGamePlayBagButtonPressed>(OnGamePlayBagButtonPressedHandler);
    }
    #endregion

    #region Event Handlers
    private void OnGamePlayBagButtonPressedHandler(OnGamePlayBagButtonPressed eventDetails)
    {
      view.SetActivePanel(true);
    }

    #endregion

  }
}