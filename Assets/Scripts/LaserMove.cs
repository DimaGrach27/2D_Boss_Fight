using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    [SerializeField] Transform lastPoint;
    [SerializeField] float speedMove = 1f;

    public Vector2 push;

    private Vector2 lastTarget;

    private void Start()
    {
        push = (transform.right + transform.up) * 4f;
        lastTarget = new Vector2(lastPoint.position.x, transform.position.y);
        Debug.Log(push);

    }

    private void FixedUpdate()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, lastTarget, speedMove * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthSys player = collision.GetComponent<PlayerHealthSys>();

        if(player != null)
        {
            player.Damaget(1f);
        }
    }

}
