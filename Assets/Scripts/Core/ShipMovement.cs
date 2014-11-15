using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class ShipMovement : MonoBehaviour {

    public int lives;
    public Vector2 offset;
    Controller controller;
    SpriteRenderer renderer;
    public float invulnTimer;
    float timer;
    float flashTimer;

    public void Start()
    {
        flashTimer = 0;
        timer = invulnTimer + 1;
        controller = GetComponent<Controller>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if(timer < invulnTimer)
        {
            flashTimer+=1;
            //renderer.enabled = (int)(timer / Time.fixedDeltaTime) % 2 == 0;
            if(flashTimer<5)
            {
                renderer.color = Color.white;
            }
            else
            {
                renderer.color = Color.red;
                if(flashTimer>10)
                {
                    flashTimer = 0;
                }
            }
        }
        else
        {
            //renderer.enabled = true;
            renderer.color = Color.cyan;
        }
    }

    public void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > invulnTimer / 2)
        {
            if (Input.touchCount > 0)
            {
                Vector2 position = new Vector2();
                foreach (Touch touch in Input.touches)
                {
                    position += touch.position;
                }
                position /= Input.touchCount;
                position += offset;
                position = Camera.main.ScreenToWorldPoint(position);
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
#if UNITY_EDITOR
            else if (Input.GetMouseButton(0))
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
#endif
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (invulnTimer < timer)
        {
            ResetPlayer();
        }
    }

    public void ResetPlayer()
    {
        rigidbody2D.MovePosition(new Vector2(0, -3.5f));
        lives--;
        timer = 0;
        if (lives < 0)
        {
            Application.LoadLevel("Start Screen");
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }
    }
}
