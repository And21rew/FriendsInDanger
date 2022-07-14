using System.Collections;
using UnityEngine;

public class EnemySaw : MonoBehaviour, ICharacterMove
{
    [SerializeField] private Transform[] controlPoints;
    [SerializeField] private float factorSpeed = 1f;
    [SerializeField] private float waitTime = 1f;

    private float speed = CharacterConstant.GetSpeedEnemySaw();
    private bool canGo = true;
    private int i = 1;

    private void Start()
    {
        gameObject.transform.position = new Vector3(controlPoints[0].position.x, controlPoints[0].position.y, transform.position.z);
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (canGo)
            transform.position = Vector3.MoveTowards(transform.position, controlPoints[i].position, factorSpeed * speed * Time.deltaTime);
        if (transform.position == controlPoints[i].position)
        {
            if (i < controlPoints.Length - 1)
                i++;
            else
                i = 0;
            canGo = false;
            StartCoroutine(Waiting());
        }
    }

    public void Flip()
    {
        //
        // Saw dont flip
        //
    }

    public void Jump()
    {
        //
        // Saw dont jump
        //
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        canGo = true;
    }
}
