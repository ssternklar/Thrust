using UnityEngine;
using System.Collections;

public class StraightFire : BulletPattern{

    public GameObject bullet;

    public float speed;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (timeSinceFire >= fireDelay)
        {
            fire(target.rigidbody2D.position);
            timeSinceFire = 0;
        }
        timeSinceFire++;
	}

    public override void fire(Vector2 destination)
    {
            Vector2 pos = this.rigidbody2D.position;
            Quaternion rot = Quaternion.identity;
            Bullet shell = ((GameObject)Instantiate(bullet, pos, rot)).GetComponent<Bullet>();
            shell.target = (destination - shell.rigidbody2D.position).normalized;
    }
}
