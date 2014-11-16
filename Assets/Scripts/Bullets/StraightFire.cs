using UnityEngine;
using System.Collections;

public class StraightFire : BulletPattern{

    public float speed;

	
	
	// Update is called once per frame
	public virtual void Update () 
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (timeSinceFire >= fireDelay)
        {
            fire(target.rigidbody2D.position - rigidbody2D.position);
            timeSinceFire = 0;
        }
        timeSinceFire++;
	}

    public override void fire(Vector2 direction)
    {
        Quaternion rot = Quaternion.identity;
        Bullet shell = ((GameObject)Instantiate(bullet, rigidbody2D.position, rot)).GetComponent<Bullet>();
        shell.target = direction.normalized;
    }
}
