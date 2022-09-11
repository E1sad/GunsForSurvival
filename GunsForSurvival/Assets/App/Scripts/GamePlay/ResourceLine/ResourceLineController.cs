using UnityEngine;
using DynamicBox.EventManagement;
using SOG.GamePlayUi.Events;

namespace SOG.GamePlay.ResourceLine
{
  public class ResourceLineController : MonoBehaviour
  {
    [SerializeField] private ItemType item;

    private bool isInteractable = false;

    private void Start()
    {
      this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
      {
        isInteractable = true;
        EventManager.Instance.Raise(new OnResourceLineTriggerEnter());
        this.enabled = true;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
      {
        isInteractable = false;
        this.enabled = false;
        EventManager.Instance.Raise(new OnResourceLineTriggerExit());
      }
    }

    private void Interact()
    {
      if (isInteractable)
      {
        if (Input.GetKeyDown(KeyCode.E))
        {
          EventManager.Instance.Raise(new OnTakeEvent(item, 1));
        }
      }
    }

    private void Update()
    {
      Interact();
    }

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnGamePlayResourcesButtonPressed>(OnGamePlayResourcesButtonPressedHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnGamePlayResourcesButtonPressed>(OnGamePlayResourcesButtonPressedHandler);

    }

    #endregion

    #region Events Handlers
    private void OnGamePlayResourcesButtonPressedHandler(OnGamePlayResourcesButtonPressed eventDetails)
    {
      EventManager.Instance.Raise(new OnTakeEvent(item, 1));
    }

    #endregion
  }
}