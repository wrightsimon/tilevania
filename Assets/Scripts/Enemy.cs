using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Config params
    [SerializeField] float moveSpeed = 1f;

    // Cached component references
    Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }
}
