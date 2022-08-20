using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using SOG.UI.Views;
using SOG.UI.Events.CreditsMenu;

namespace SOG.UI.Controllers
{
  public class CreditsMenuController : MonoBehaviour
  {
    [Header("view reference")]
    [SerializeField] private CreditsMenuView view;

    public void OnBackButtonPressed()
    {
      EventManager.Instance.Raise(new OnBackButtonPressedEvent());
      view.SetDeactiveCreditsPanel();
    }

    #region Unity Event
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnCreditsButtonPressedEvent>(OnCreditsButtonPressedEventHandler);
    }
    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnCreditsButtonPressedEvent>(OnCreditsButtonPressedEventHandler);
    }

    #endregion

    #region Event Handler
    private void OnCreditsButtonPressedEventHandler(OnCreditsButtonPressedEvent eventDetails)
    {
      view.SetActiveCreditsPanel();
    }

    #endregion


  }
}
