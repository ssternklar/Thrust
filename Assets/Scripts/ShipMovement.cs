using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class ShipMovement : MonoBehaviour {

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

            if(position.x > Screen.width - controller.SpriteHalfWidth)
            {
                position.x = Screen.width - controller.SpriteHalfWidth;
            }

            else if(position.y > Screen.height - controller.SpriteHalfHeight)
            {
                position.x = Screen.height - controller.SpriteHalfHeight;
            }

            else if(position.x < controller.SpriteHalfWidth)
            {
                position.x = controller.SpriteHalfWidth;
            }

            else if(position.y < controller.SpriteHalfHeight)
            {
                position.y = controller.SpriteHalfHeight;
            }

            controller.MovePosition(position);
        }
    }
}
