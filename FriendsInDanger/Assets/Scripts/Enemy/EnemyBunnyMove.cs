using UnityEngine;

public class EnemyBunnyMove : MonoBehaviour, ICharacterMove
{
    [SerializeField] private bool moveLeft = true;
    [SerializeField] private Transform groundDetect;
    [SerializeField] private float factorSpeed = 1f;

    private float speed = CharacterConstant.GetSpeedEnemyBunny();

    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(factorSpeed * speed * Time.deltaTime * Vector2.left);
        _animator.SetInteger("State", (int)CharacterConstant.Animation.Run);
        Flip();
    }

    public void Flip()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 1f);

        if (!groundInfo.collider)
        {
            if (moveLeft)
            {
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 180, gameObject.transform.rotation.z);
                moveLeft = false;
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 0, gameObject.transform.rotation.z);
                moveLeft = true;
            }
        }
    }

    public void Jump()
    {
        //
        // Bunny dont jump
        //
    }
}
