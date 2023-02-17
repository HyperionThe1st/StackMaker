using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CardinalDirection
{
    Standby,
    Forward,
    Right,
    Backward,
    Left,
    Unknown
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public CardinalDirection MovingDirection { get; set; }
    public Vector3 MoveTargetPosition { get; set; }
    public Vector3 MovingDirectionVector => VectorUtils.CardinalDirectionVectorOf(MovingDirection);
    public bool IsMoving => MovingDirection != CardinalDirection.Standby;

    private void Awake()
    {
        OnInit();
    }

    private void FixedUpdate()
    {
        if (MovingDirection == CardinalDirection.Standby)
        {
            return;
        }
        MoveToTargetPosition();
    }
    void OnInit()
    {
        MoveTargetPosition = transform.position;
    }
    void MoveToTargetPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, MoveTargetPosition, Time.fixedDeltaTime * MoveSpeed);
        if (VectorUtils.Approximately(transform.position, MoveTargetPosition))
        {
            MovingDirection = CardinalDirection.Standby;
        }
    }
    RaycastHit RaycastInDirection(Vector3 HuongbanRayCast)
    {
        Vector3 diemban = transform.position + Vector3.up * 0.1f + HuongbanRayCast * GameConstant.TILESIZE / 4;
        RaycastHit hit;

        Physics.Raycast(
            diemban,
            HuongbanRayCast,
            out hit,
            10000f,
            1 << LayerMask.NameToLayer(GameConstant.Brick.UnCollectable.LAYER_NAME)
        );

        
        return hit;
    }
    public Vector3 DetectMoveTargetPosition(CardinalDirection direction)
    {
        Vector3 directionVector = VectorUtils.CardinalDirectionVectorOf(direction);

        RaycastHit hit = RaycastInDirection(directionVector);

        return hit.transform.position - GameConstant.TILESIZE * directionVector;
    }
}
