using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Jump,
    Cheer,
    Lose
}

public class Player : MonoBehaviour
{

    [SerializeField] private PlayerStack playerStack;
    [SerializeField] private Animator animator;
    public PlayerState CurrentState { get; private set; }



    public PlayerAction PlayerAction { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerInputHandle PlayerInputHandle { get; private set; }
    public PlayerStack PlayerStack { get => playerStack;}



    private void Awake()
    {
        PlayerInputHandle = GetComponent<PlayerInputHandle>();
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerAction = GetComponent<PlayerAction>();
        CurrentState = PlayerState.Idle;
    }


    public void ChangeState(PlayerState state)
    {
        if (CurrentState != state)
        {
            animator.SetInteger("state", (int)state);
            CurrentState = state;
        }
    }
}
