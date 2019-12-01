using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 4f;
    float mobileSpeed = 2f;
    PlayerBounds bounds;
    BoxCollider2D boxCollider;
    GameManager gameManager;
    float horizontal, vertical;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
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
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(
            horizontal,
            vertical,
            0) * speed * Time.deltaTime);

        Vector3 temp = transform.position;

        temp.x = Mathf.Clamp(temp.x, bounds.left, bounds.right);
        temp.y = Mathf.Clamp(temp.y, bounds.bottom, bounds.top);

        transform.position = temp;

#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.MoveTowards(transform.position, touchedPos, mobileSpeed * Time.deltaTime);

                Vector3 temp = transform.position;

                temp.x = Mathf.Clamp(temp.x, bounds.left, bounds.right);
                temp.y = Mathf.Clamp(temp.y, bounds.bottom, bounds.top);

                transform.position = temp;
            }
        }
#endif
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.Pause();
        }
    }
}
