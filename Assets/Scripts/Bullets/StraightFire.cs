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
        base.Update();
	}

    public override void fire()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (timeSinceFire >= fireDelay)
        {
            Vector2 pos = this.rigidbody2D.position;
            Quaternion rot = Quaternion.identity;
            Bullet shell = ((GameObject)Instantiate(bullet, pos, rot)).GetComponent<Bullet>();
            shell.target = (target.rigidbody2D.position-shell.rigidbody2D.position).normalized;

            timeSinceFire = 0;
        }

        timeSinceFire++;
    }
}
