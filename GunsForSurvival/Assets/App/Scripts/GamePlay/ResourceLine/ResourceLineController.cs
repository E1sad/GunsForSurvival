using UnityEngine;
using DynamicBox.EventManagement;

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
        this.enabled = true;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
      {
        isInteractable = false;
        this.enabled = false;
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


  }
}