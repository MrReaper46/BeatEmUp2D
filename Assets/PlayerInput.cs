using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    private float _horizontalMove;
    private float _verticalMove;

    private void Awake()
    {
        characterMovement = this.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        characterMovement.Move(_horizontalMove,_verticalMove, false);
    }
}
