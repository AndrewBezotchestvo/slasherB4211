using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private bool _isRight;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;

    private Rigidbody2D _rb;
    private bool _isGround;
    private Vector3 _movement;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movement = Vector3.zero;
        _isGround = true;
    }

    void Update()
    {
       if(_isRight)
       {
            transform.rotation = Quaternion.Euler(0, 180, 0);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                _movement.x = _speed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                _movement.x = -_speed;
            }
            else
            {
                _movement.x = 0;
            }

            if(Input.GetKeyDown(KeyCode.UpArrow) && _isGround)
            {
                _isGround = false;
                _movement.y = _jumpForce;
                _rb.velocity = _movement;
            }
       }
       else
       {
            transform.rotation = Quaternion.Euler(0, 0, 0);

            if (Input.GetKey(KeyCode.D))
            {
                _movement.x = _speed;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _movement.x = -_speed;
            }
            else
            {
                _movement.x = 0;
            }

            if (Input.GetKeyDown(KeyCode.W) && _isGround)
            {
                _isGround = false;
                _movement.y = _jumpForce;
                _rb.velocity = _movement;
            }
        }


       if(!_isGround)
        {
            _movement.y -= _gravityScale * Time.fixedDeltaTime;
            _rb.velocity = _movement;
        }
       else
        {
            _movement.y = 0;
        }

        _movement.y = _rb.velocity.y;
       _rb.velocity = _movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }
}
