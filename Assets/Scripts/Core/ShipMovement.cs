using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller))]
public class ShipMovement : MonoBehaviour
{

    public int lives;
    public Vector2 offset;
    Controller controller;
    SpriteRenderer spriteRenderer;
    public float invulnTimer;
    public float timer;
    float flashTimer;
    private bool invuln;
    public bool Invuln { get { return invuln; } }

    //Shooting variables
    private int shootTimer;
    public int shootTimerResetValue = 30;
    public GameObject bullet;
    private float shootOffset = 0.135f;
    //public GameObject target;

    public void Start()
    {
        invuln = false;
        flashTimer = 0;
        timer = invulnTimer + 1;
        controller = GetComponent<Controller>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (timer < invulnTimer)
        {
            invuln = true;
            flashTimer += 1;
            //renderer.enabled = (int)(timer / Time.fixedDeltaTime) % 2 == 0;
            if (flashTimer < 5)
            {
                spriteRenderer.color = Color.white;
            }
            else
            {
                spriteRenderer.color = Color.red;
                if (flashTimer > 10)
                {
                    flashTimer = 0;
                }
            }
        }
        else
        {
            //renderer.enabled = true;
            spriteRenderer.color = Color.white;
            invuln = false;
        }

        //Shooting logic
        shootTimer -= 1;
        if (shootTimer <= 0)
        {
            //
            Vector2 dir = new Vector2(0, -1);
            fire(dir);

            //spriteRenderer.color = Color.yellow;
            shootTimer = shootTimerResetValue;
        }
    }

    public void fire(Vector2 direction)
    {
        Quaternion rot = Quaternion.identity;

        Vector2 lPosition = new Vector2(rigidbody2D.position.x - shootOffset, rigidbody2D.position.y);
        Vector2 rPosition = new Vector2(rigidbody2D.position.x + shootOffset, rigidbody2D.position.y);

        Bullet shell = ((GameObject)Instantiate(bullet, lPosition, rot)).GetComponent<Bullet>();
        shell.target = direction;

        shell = ((GameObject)Instantiate(bullet, rPosition, rot)).GetComponent<Bullet>();
        shell.target = direction;
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
            //ResetPlayer();
        }
    }

    public void ResetPlayer()
    {
        lives--;
        timer = 0;
        if (lives < 0)
        {
            Application.LoadLevel("End Screen");
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }
    }
}
