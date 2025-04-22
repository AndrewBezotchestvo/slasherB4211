using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //_animator.SetBool("isGround", GetComponent<PlayerMove>()._isGround);
        _animator.SetFloat("speed", _rb.velocity.magnitude);
    }
}
