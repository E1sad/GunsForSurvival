using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.Characters.Player
{
  public class PlayerMovement : MonoBehaviour
  {
    [Header("Link refenrece")]
    [SerializeField] private Rigidbody2D playerRb;

    [Header("Parameters")]
    [SerializeField] private float speed;

    private void Movement()
    {
      float horizontalInput = SimpleInput.GetAxis("Horizontal");
      float verticalInput = SimpleInput.GetAxis("Vertical");

      playerRb.velocity = ((transform.up * verticalInput * speed) + (transform.right * horizontalInput * speed))*Time.deltaTime;
    }


    private void Update()
    {
      Movement();
    }
  }
}