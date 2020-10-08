using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 3f;

    public Rigidbody2D RigidBody;
    public Animator Animator;
    public Transform FuturePosition;

    Vector2 movement;

    private void Start()
    {
        FuturePosition.parent = null;
    }

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        //Move();
        GridMove();
    }

    void ProcessInputs()
    {
        var horizontal = "Horizontal";
        var vertical = "Vertical";

        movement.x = Input.GetAxisRaw(horizontal);
        movement.y = Input.GetAxisRaw(vertical);

        Animator.SetFloat(horizontal, movement.x);
        Animator.SetFloat(vertical, movement.y);
        Animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void Move()
    {
        RigidBody.MovePosition(RigidBody.position + movement * MovementSpeed * Time.fixedDeltaTime);
    }

    void GridMove()
    {
        RigidBody.position = Vector3.MoveTowards(transform.position, FuturePosition.position, MovementSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, FuturePosition.position) <= 0.75f)
        {
            FuturePosition.position = RigidBody.transform.position;
            if (Mathf.Abs(movement.x) == 1f)
            {
                FuturePosition.position += new Vector3(movement.x, 0f, 0f);
            }
            else if (Mathf.Abs(movement.y) == 1f)
            {
                FuturePosition.position += new Vector3(0f, movement.y, 0f);
            }
        }

    }
}
