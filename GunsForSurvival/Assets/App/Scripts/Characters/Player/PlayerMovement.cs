using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.Characters.Player
{
  public class PlayerMovement : MonoBehaviour
  {
    [Header("Link refenrece")]
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator playerAnimator;


    [Header("Parameters")]
    [SerializeField] private float speed;

    private void Movement()
    {
      float horizontalInput = SimpleInput.GetAxis("Horizontal");
      float verticalInput = SimpleInput.GetAxis("Vertical");

      playerAnimator.SetFloat("Horizontal", horizontalInput);
      playerAnimator.SetFloat("Vertical", verticalInput);
      playerRb.velocity = ((transform.up * verticalInput * speed) + (transform.right * horizontalInput * speed))*Time.deltaTime;
      


      if (0.1<Mathf.Abs(horizontalInput) || 0.1 < Mathf.Abs(verticalInput))
      {
        playerAnimator.SetBool("IsMove", true);

        if(horizontalInput>0)
        {
          gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(horizontalInput<0)
        {
          gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

      }
      else
      {
        playerAnimator.SetBool("IsMove", false);
      }
      

    
    }


    private void Update()
    {
      Movement();
    }
  }
}