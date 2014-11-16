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
            audio.Play();
        }
        timeSinceFire++;
	}

    public override void fire(Vector2 direction)
    {
        GameManager.SharedManager.GetBullet(rigidbody2D.position, direction.normalized, sprite);
    }
}
