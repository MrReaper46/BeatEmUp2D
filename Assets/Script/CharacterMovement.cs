using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float hSpeed = 10f;
    [SerializeField] private float vSpeed = 6f;
    private Rigidbody2D _rb2D;
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private bool canMove = true;
    
    [Range(0, 1.0f)] [SerializeField] private float movementSmooth = 0.5f;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        _rb2D = this.GetComponent<Rigidbody2D>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Move(float hMove, float vMove, bool jump)
    {
        if (canMove)
        {
            Vector3 targetVelocity = new Vector2(hMove * hSpeed, vMove * vSpeed);

            _rb2D.velocity = Vector3.SmoothDamp(_rb2D.velocity, targetVelocity, ref velocity, movementSmooth);

            if (hMove > 0)
            {
                _spriteRenderer.flipX = false;
                _spriteRenderer.GetComponentInChildren<SpriteRenderer>(true).flipX = false;
                
            }
            else if (hMove < 0)
            {
                _spriteRenderer.flipX = true;
                _spriteRenderer.GetComponentInChildren<SpriteRenderer>(true).flipX = true;
            }
            
        }
    }
}
