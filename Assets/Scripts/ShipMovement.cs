using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class ShipMovement : MonoBehaviour {

    public int lives = 3;
    public Vector2 offset;
    Controller controller;

    public void Start()
    {
        controller = GetComponent<Controller>();
    }

    public void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            Vector2 position = new Vector2();
            foreach(Touch touch in Input.touches)
            {
                position += touch.position;
            }
            position /= Input.touchCount;
            position += offset;

            float maxLeft =  - controller.SpriteHalfWidth;
            float maxTop =  - controller.SpriteHalfHeight;
            if (position.x > maxLeft)
            {
                position.x = maxLeft;
            }
            else if (position.x < -maxLeft)
            {
                position.x = -maxLeft;
            }
            else if (position.y > maxTop)
            {
                position.y = maxTop;
            }
            else if (position.y < -maxTop)
            {
                position.y = -maxTop;
            }

            controller.MovePosition(position);
        }
        else if(Input.GetMouseButton(0))
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position += offset;
            float maxLeft = GameManager.SharedManager.screenWidth - controller.SpriteHalfWidth;
            float maxTop = GameManager.SharedManager.screenHeight - controller.SpriteHalfHeight;
            if (position.x > maxLeft)
            {
                position.x = maxLeft;
            }
            else if (position.x < -maxLeft)
            {
                position.x = -maxLeft;
            }
            if (position.y > maxTop)
            {
                position.y = maxTop;
            }
            else if (position.y < -maxTop)
            {
                position.y = -maxTop;
            }

            controller.MovePosition(position);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Player Bullet")
        {
            ResetPlayer();
        }
    }

    public void ResetPlayer()
    {
        rigidbody2D.MovePosition(new Vector2(0, -3.5f));
        lives--;
    }
}
