using UnityEngine;
using System.Collections;

public class BasicEnemyBehavior : MonoBehaviour {

    public float MaxSpeed = 1.5f;
    private float shootTimer = 0;

	// Use this for initialization
	void Start () {
        rigidbody2D.velocity = new Vector2(0, -MaxSpeed);
        shootTimer = Random.Range(30, 100);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Movement
	    //call alignX on the player prefab

        //Attacking
        shootTimer -= 1;
        if (shootTimer<0)
        {
            shootTimer = Random.Range(30, 100);
            Shoot();
        }
	}

    /// <summary>
    /// Makes the object set it's xSpd to chase a target
    /// </summary>
    /// <param name="target"></param>
    /// <param name="buffer"></param>
    void AlignX(GameObject target, float buffer)
    {
        //If we're to the right, move left
        if(rigidbody2D.position.x > target.rigidbody2D.position.x + buffer)
        {
            rigidbody2D.velocity = new Vector2(-MaxSpeed, rigidbody2D.velocity.y);
        }
        //If we're to the left, move right
        else if (rigidbody2D.position.x < target.rigidbody2D.position.x - buffer)
        {
            rigidbody2D.velocity = new Vector2(MaxSpeed, rigidbody2D.velocity.y);
        }
        //else decelerate
        else
        {
            rigidbody2D.velocity *= .8f;
        }
        
    }//end alignX

    void Shoot()
    {
        //create a bullet prefab and make it move and things.
    }
}
