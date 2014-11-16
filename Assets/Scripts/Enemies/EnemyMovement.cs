using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Controller controller;
    public Vector2 velocity;

	// Use this for initialization
	void Start () 
    {
        controller = GetComponent<Controller>();
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
}
