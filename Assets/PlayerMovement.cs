using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator Animator;
    bool isGrounded = false;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Transform GroundCheck1;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    void Start()
    {
        
    }
    public void onLanding(){
        Animator.SetBool("jump", false);
       // Debug.Log("LAND");
    }
    // Update is called once per frame
    void Update()
    {
        
        //===============================================================================================
        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, groundCheckRadius, groundLayer);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump")){
            jump = true;
            Animator.SetBool("jump", true);
        }
        if(Input.GetButtonDown("Crouch")){
            crouch = true;
        }
        if(Input.GetButtonUp("Crouch")){
            crouch = false;
        }

        Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        Animator.SetBool("isGrounded", isGrounded);
        //================================================================================================
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(GroundCheck1.position, groundCheckRadius);
    }
    

    /*private bool IsGrounded() {
        private float extraheight = 2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(Col.bounds.center, Col.bounds.size, 0f, Vector2.down, extraheight, 3);
        Color rayColor = Color.blue;
        if(raycastHit.collider != null){
            rayColor = Color.blue;
        }else {
            rayColor = Color.red;
        }
       // Debug.DrawRay(Col.bounds.center + new Vector3(Col.bounds.extents.x, 0), Vector2.down * (Col.bounds.extents.y + extraheight), rayColor);
       // Debug.DrawRay(Col.bounds.center - new Vector3(Col.bounds.extents.x, 0), Vector2.down * (Col.bounds.extents.y + extraheight), rayColor);
       // Debug.DrawRay(Col.bounds.center + new Vector3(Col.bounds.extents.x, Col.bounds.extents.y), Vector2.right * (Col.bounds.extents.x ), rayColor);
        
    }*/
}    