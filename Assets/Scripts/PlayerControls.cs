using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float MovementScalar;
    public float VerticalScalar;
    public float MaxSpeed;
    private Rigidbody2D rb;
    private bool is_on_ground;
    private Animator animator;
    

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    

    void FixedUpdate()
    {
        float x_input = Input.GetAxis("Horizontal");
        float direction = Mathf.Sign(x_input);
        if (rb.velocity.magnitude < MaxSpeed)
        {
            if (direction <= 0f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if (direction >= 0f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            Vector2 x_force = new Vector2(x_input, 0);
            rb.AddForce(MovementScalar * x_force);
        }


        if (Input.GetButton("Jump") && is_on_ground)
        {
            rb.AddForce(new Vector2(0, VerticalScalar), ForceMode2D.Impulse);

            
        }
        animator.SetBool("IsMoving", x_input != 0);
        animator.SetFloat("YVelocity", Mathf.Sign(rb.velocity.y));
        if (is_on_ground)
        {
            animator.SetFloat("YVelocity", 0);
        }
    }
    
   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (CollisionIsWithGround(collision))
        {
            is_on_ground = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (!CollisionIsWithGround(collision))
        {
            is_on_ground = false;
        }
    }

    private bool CollisionIsWithGround(Collision2D collision)
    {
        bool is_with_ground = false;
        foreach (ContactPoint2D c in collision.contacts)
        {
            Vector2 collision_direction_vector = c.point - rb.position;
            if (collision_direction_vector.y < 0)
            {
                is_with_ground = true;
            }
        }
        return is_with_ground;
    }
}