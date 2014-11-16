using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Controller controller;
    public Vector2 velocity;
    private float health;
    public float HealthMax = 100;

	// Use this for initialization
	void Start () 
    {
        controller = GetComponent<Controller>();
        health = HealthMax;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        controller.Translate(-velocity);

        if (rigidbody2D.position.y < -GameManager.SharedManager.screenHeight)
        {
            controller.Die();
        }
	}

    void recieveDamage ()
    {
        health -= 20;

        if(health<=0)
        controller.Die();
    }

}
