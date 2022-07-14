using UnityEngine;

public class PlayerMove : MonoBehaviour, ICharacterMove
{
    [SerializeField] private Transform checkGround;

    private float speed = CharacterConstant.GetSpeedPlayer();
    private float forceJump = CharacterConstant.GetForceJumpPlayer();
    private bool isGrounded = true;
    
    Rigidbody2D _rigidbody;
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 1f;
    }

    private void FixedUpdate()
    {
        Move();

        Flip();
    }

    private void Update()
    {
        Jump();
    }

    public void Move()
    {
        CheckGround();

        if (Input.GetAxis("Horizontal") == 0 && isGrounded)
        {
            _animator.SetInteger("State", (int)CharacterConstant.Animation.Stay);
            _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * 0, _rigidbody.velocity.y);
        }
        else
        {
            _animator.SetInteger("State", (int)CharacterConstant.Animation.Run);
            _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rigidbody.velocity.y);
        }
    }

    public void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 0, gameObject.transform.rotation.z);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 180, gameObject.transform.rotation.z);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckGround();

            if (isGrounded)
            {
                _animator.SetInteger("State", (int)CharacterConstant.Animation.Jump);
                _rigidbody.AddForce(transform.up * forceJump, ForceMode2D.Impulse);
            }
        }
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkGround.position, 0.1f);
        isGrounded = colliders.Length > 1;
    }
}
