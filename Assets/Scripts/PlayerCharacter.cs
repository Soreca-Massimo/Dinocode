using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float jumpVelocity;
    private Vector2 direction;
    [SerializeField] private Rigidbody2D rb;
    public float JumpHeight;

    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
         if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

    }

    private void Jump()
    {
        //jumpVelocity = RadQuadrata * gravità * h jump
        jumpVelocity = Mathf.Sqrt(2f * Physics2D.gravity.magnitude * rb.gravityScale * JumpHeight);
        rb.velocity = Vector2.up * jumpVelocity;
        isGrounded = false;
    }

    void Move(float speed)
    {
        transform.position += speed * Vector3.right * Time.deltaTime;
    }
}
