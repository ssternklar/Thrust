using UnityEngine;
using System.Collections;

public class BasicEnemyBehavior : MonoBehaviour {

    public float MaxSpeed = 1.5f;
    private float shootTimer = 0;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -MaxSpeed);
        shootTimer = Random.Range(30, 100);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Movement
	    AlignX(GameObject.FindGameObjectWithTag("Player"),32);

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
        if(GetComponent<Rigidbody2D>().position.x > target.GetComponent<Rigidbody2D>().position.x + buffer)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        //If we're to the left, move right
        else if (GetComponent<Rigidbody2D>().position.x < target.GetComponent<Rigidbody2D>().position.x - buffer)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        //else decelerate
        else
        {
            GetComponent<Rigidbody2D>().velocity *= .8f;
        }
        
    }//end alignX

    void Shoot()
    {
        //create a bullet prefab and make it move and things.
    }
}
