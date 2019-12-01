using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBgAnimation : MonoBehaviour
{
    PlayerBounds bounds;
    BoxCollider2D boxCollider;
    public float movementSpeed = 1f;
    bool runForwards = true;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        bounds = new PlayerBounds();

        bounds.left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + boxCollider.bounds.extents.x;
        // Debug.Log("bounds.left : " + bounds.left);
        bounds.right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - boxCollider.bounds.extents.x;
        // Debug.Log("bounds.right : " + bounds.right);
    }

    private void FixedUpdate()
    {
        bounds.top = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - boxCollider.bounds.extents.y;
        //  Debug.Log("bounds.top : " + boxCollider.bounds.extents.y);
        bounds.bottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + boxCollider.bounds.extents.y;
        // Debug.Log("bounds.bottom : " + bounds.bottom);
    }

    // Update is called once per frame
    void Update()
    {

        UpdatePosition();

        Vector3 temp = transform.position;

        temp.x = Mathf.Clamp(temp.x, bounds.left, bounds.right);
        temp.y = Mathf.Clamp(temp.y, bounds.bottom, bounds.top);

        transform.position = temp;
    }

    void UpdatePosition()
    {
        WallCollsionHandler();

        Vector3 oPos = transform.position;
        float calculatedPosition;

        if (runForwards)
        {
            calculatedPosition = oPos.x + movementSpeed;
        }
        else
        {
            calculatedPosition = oPos.x - movementSpeed;
        }

        transform.position = new Vector3(oPos.x + movementSpeed, oPos.y, oPos.z);
    }

    void WallCollsionHandler()
    {
        if (transform.position.x == bounds.left)
        {
            runForwards = false;

            // Or
            // JumpBackwards()
        }
        else if (transform.position.x == bounds.right)
        {
            runForwards = true;

            // Or
            // JumpForwards()
        }
    }
}
