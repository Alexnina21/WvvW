using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _sprt;
    private MovementBehavior _mv;
    private Rigidbody2D _rb;
    private Respawn _respawn;
    public float speed;

    public UnityEvent pauseMode;
    private bool block;

    public Vector3 direction;
    private Vector3 camDir;

    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _sprt = GetComponent<SpriteRenderer>();
        _mv = GetComponent<MovementBehavior>();
        _rb = GetComponent<Rigidbody2D>();
        _respawn = GetComponent<Respawn>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        direction = new Vector3(hor*speed, _rb.velocity.y);

        if (block == false)
        {
            if (hor > 0.1)
            {
                _sprt.flipX = false;
                _anim.SetBool("Walk", true);
            }
            else if (hor < -0.1)
            {
                _sprt.flipX = true;
                _anim.SetBool("Walk", true);
            }
            else
            {
                _anim.SetBool("Walk", false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.gravityScale = -_rb.gravityScale;
                _anim.SetTrigger("Jump");
            }

            if (_rb.gravityScale >= 0)
            {
                _sprt.flipY = false;
            }
            else if (_rb.gravityScale < 0)
            {
                _sprt.flipY = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseMode.Invoke();
            block = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn.Instance.StartRespawn();
        }
    }

    public void BlockFalse()
    {
        block = false;
    }

    private void FixedUpdate()
    {
        _mv.MoveVelocity(direction);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _anim.SetTrigger("Fall");
    }


}
