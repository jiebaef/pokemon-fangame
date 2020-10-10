using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string Horizontal = "Horizontal", Vertical = "Vertical";

    public float MovementSpeed = 3f;

    public Rigidbody2D RigidBody;
    public Animator Animator;
    public Transform FuturePosition;

    private Vector2 movement;
    private bool IsMoving;


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
        movement.x = Input.GetAxisRaw(Horizontal);
        movement.y = Input.GetAxisRaw(Vertical);

        if (!IsMoving)
        {
            AnimateCharacter();
        }
    }

    void AnimateCharacter()
    {
        Animator.SetFloat(Horizontal, movement.x);
        Animator.SetFloat(Vertical, movement.y);
        Animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void Move()
    {
        RigidBody.MovePosition(RigidBody.position + movement * MovementSpeed * Time.fixedDeltaTime);
    }

    void GridMove()
    {
        RigidBody.position = Vector3.MoveTowards(transform.position, FuturePosition.position, MovementSpeed * Time.fixedDeltaTime);

        IsMoving = true;

        var distance = Vector3.Distance(transform.position, FuturePosition.position);

        if (distance <= 0.75f)
        {
            if (distance == 0f)
            {
                FuturePosition.position = RigidBody.transform.position;
                IsMoving = false;
            }

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
