using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rigid;
    private Renderer[] rends;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rends = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePosition();
        HandleBoundary();
    }

    void HandlePosition()
    {
        rigid.velocity = Vector3.left * moveSpeed;
    }

    void HandleBoundary()
    {
        Vector3 transformPos = transform.position;

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transformPos);
        if (IsVisible() == false && viewportPos.x < 0)
        {
            Destroy(gameObject);
        }
    }

    bool IsVisible()
    {
        foreach ( var renderer in rends)
        {
            if (renderer.isVisible)
            {
                return true;
            }
        }
        return false;
    }
}
