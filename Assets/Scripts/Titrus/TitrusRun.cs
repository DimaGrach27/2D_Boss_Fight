using UnityEditor;
using UnityEngine;

public class TitrusRun : MonoBehaviour
{

    [SerializeField] Transform endPoint;

    [SerializeField] float speed = 2f;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);

        if (transform.position == endPoint.position)
            Destroy(gameObject);
    }
}
