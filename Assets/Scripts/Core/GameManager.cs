using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager {

    private static GameManager sharedManager;
    public static GameManager SharedManager
    {
        get { if (sharedManager != null) return sharedManager; else return new GameManager(); }
    }

    Queue<GameObject> bullets;

    public float screenWidth;
    public float screenHeight;
    public float lastScore;

    private GameManager()
    {
        sharedManager = this;
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        screenHeight = Camera.main.orthographicSize;
        lastScore = 0;
        bullets = new Queue<GameObject>();
        for (int i = 0; i < 150; i++)
        {
            bullets.Enqueue(MakeNewBullet(Vector2.zero, Vector2.zero, null));
        }
    }

    public void ResetScore()
    {
        lastScore = 0;
    }

    private GameObject MakeNewBullet(Vector2 pos, Vector2 direction, Sprite sprite)
    {
        GameObject obj = new GameObject();
        obj.AddComponent<SpriteRenderer>().sprite = sprite;
        obj.AddComponent<Controller>();
        BoxCollider2D box = obj.AddComponent<BoxCollider2D>();
        box.size = new Vector2(.32f, .32f);
        box.isTrigger = true;
        Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.MovePosition(pos);
        Bullet b = obj.AddComponent<Bullet>();
        b.target = direction;
        b.bulletSpeed = 3;
        b.lifeTimer = 3.5f;
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetBullet(Vector2 pos, Vector2 direction)
    {
        return GetBullet(pos, direction, bullets.Peek().GetComponent<SpriteRenderer>().sprite);
    }

    public GameObject GetBullet(Vector2 pos, Vector2 direction, Sprite sprite)
    {
        if (bullets.Count > 0)
        {
            GameObject obj = bullets.Dequeue();
            obj.SetActive(true);
            obj.transform.position = pos;
            Debug.Log(obj.rigidbody2D.position);
            obj.GetComponent<Bullet>().target = direction;
            obj.GetComponent<SpriteRenderer>().sprite = sprite;
            obj.transform.localScale = new Vector3(.5f, .5f);
            return obj;
        }
        else
        {
            return MakeNewBullet(pos, direction, sprite);
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullets.Enqueue(bullet);
        bullet.SetActive(false);
    }
	
}
