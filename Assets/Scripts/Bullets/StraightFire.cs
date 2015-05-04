using UnityEngine;
using System.Collections;

public class StraightFire : BulletPattern{

    public float speed;

	
	
	// Update is called once per frame
	public virtual void FixedUpdate () 
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (timeSinceFire >= fireDelay)
        {
            fire(target.GetComponent<Rigidbody2D>().position - GetComponent<Rigidbody2D>().position);
            timeSinceFire = 0;
            //I found the sound here: https://www.freesound.org/people/jobro/sounds/35474/
            GetComponent<AudioSource>().Play();
        }
        timeSinceFire++;
	}

    public override void fire(Vector2 direction)
    {
        Quaternion rot = Quaternion.identity;
        Bullet shell = ((GameObject)Instantiate(bullet, GetComponent<Rigidbody2D>().position, rot)).GetComponent<Bullet>();
        shell.target = direction.normalized;
    }
}
