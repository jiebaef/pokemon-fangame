using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 3f;

    public Rigidbody2D RigidBody;
    public Animator animator;
    Vector2 movement;
    

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        var horizontal = "Horizontal";
        var vertical = "Vertical";

        movement.x = Input.GetAxisRaw(horizontal);
        movement.y = Input.GetAxisRaw(vertical);

        animator.SetFloat(horizontal, movement.x);
        animator.SetFloat(vertical, movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void Move()
    {
        RigidBody.MovePosition(RigidBody.position + movement * MovementSpeed * Time.fixedDeltaTime);
    }
}
