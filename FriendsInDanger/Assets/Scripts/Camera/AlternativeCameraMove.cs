using UnityEngine;

public class AlternativeCameraMove : MonoBehaviour
{
    [SerializeField] private GameObject[] players;

    private GameObject target;
    private readonly float speed = 8f;

    private void Start()
    {
        target = GetTarget().gameObject;
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
        }
    }

    private Transform GetTarget()
    {
        GameObject target = null;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].activeInHierarchy)
            {
                target = players[i];
                break;
            }
        }

        return target.transform;
    }
}
