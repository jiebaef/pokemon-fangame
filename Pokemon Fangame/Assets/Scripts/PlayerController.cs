using Assets.Scripts.AnimationManagement.AnimationNames;
using Assets.Scripts.AnimationManagement.Animations;
using Assets.Scripts.Enums;
using Assets.Scripts.TilemapHandling;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal", Vertical = "Vertical";

#pragma warning disable 0649
    [SerializeField]
    private Animator Animator;

    [SerializeField]
    private Rigidbody2D RigidBody;

    [SerializeField]
    private Transform FuturePosition;

    [SerializeField]
    private Tilemap GroundTilemap;

    [SerializeField]
    private Tilemap EnvironmentTilemap;

#pragma warning restore 0649

    [SerializeField]
    private CharacterDirection CharacterFacingDirection = CharacterDirection.DOWN;

    [SerializeField]
    private float MovementSpeed = 3f;

    private PlayerAnimationManager PlayerAnimationManager;

    private TilemapHandler TilemapHandler;

    private Vector3 PreviousPlayerPosition, PlayerMovementDirection;

    private Vector2 Movement;

    private bool IsMoving;

    private float DistanceToFuturePosition;

    private void Start()
    {
        FuturePosition.parent = null;

        PlayerAnimationManager = new PlayerAnimationManager(
            new PlayerAnimation(Animator),
            new PlayerMovementAnimationHandler(Gender.MALE, MoveState.IDLING)
        );

        TilemapHandler = new TilemapHandler(GroundTilemap, EnvironmentTilemap);
    }

    void Update()
    {
        ProcessInputs();

        if (CanPlayerMove())
        {
            DetermineCharacterFacingDirection(FuturePosition.position);

            PlayerAnimationManager.AnimateCharacter(IsMoving, MoveState.WALKING, CharacterFacingDirection);
        }

    }

    private void FixedUpdate()
    {
        GridMove();

        DistanceToFuturePosition = Vector3.Distance(transform.position, FuturePosition.position);

        CheckIfCharacterIsMoving();

        DetermineFuturePosition(DistanceToFuturePosition);
    }

    void ProcessInputs()
    {
        Movement.x = Input.GetAxisRaw(Horizontal);
        Movement.y = Input.GetAxisRaw(Vertical);
    }

    void GridMove()
    {
        if (CanPlayerMove())
            RigidBody.position = Vector3.MoveTowards(transform.position, FuturePosition.position, MovementSpeed * Time.fixedDeltaTime);
    }

    void DetermineFuturePosition(float distance)
    {
        if (distance <= 0.15f)
        {
            if (distance == 0f)
            {
                FuturePosition.position = RigidBody.transform.position;
                IsMoving = false;
            }

            if (Mathf.Abs(Movement.x) == 1f)
            {
                FuturePosition.position += new Vector3(Movement.x, 0f, 0f);
            }
            else if (Mathf.Abs(Movement.y) == 1f)
            {
                FuturePosition.position += new Vector3(0f, Movement.y, 0f);
            }
        }
    }

    void DetermineCharacterFacingDirection(Vector3 futurePlayerPosition)
    {
        PlayerMovementDirection = (futurePlayerPosition - PreviousPlayerPosition).normalized;
        PreviousPlayerPosition = futurePlayerPosition;

        if (PlayerMovementDirection.x > 0)
            CharacterFacingDirection = CharacterDirection.RIGHT;
        else if (PlayerMovementDirection.x < 0)
            CharacterFacingDirection = CharacterDirection.LEFT;
        else if (PlayerMovementDirection.y > 0)
            CharacterFacingDirection = CharacterDirection.UP;
        else if (PlayerMovementDirection.y < 0)
            CharacterFacingDirection = CharacterDirection.DOWN;
    }

    void CheckIfCharacterIsMoving()
    {
        if (DistanceToFuturePosition > 0f)
            IsMoving = true;
    }

    bool CanPlayerMove() => TilemapHandler.CanMove(FuturePosition.position);
}
