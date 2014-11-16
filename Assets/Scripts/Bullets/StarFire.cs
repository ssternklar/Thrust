using UnityEngine;
using System.Collections;

public class StarFire : BulletPattern {

	
	// Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (timeSinceFire >= fireDelay)
        {
            Vector2 pos = (target.rigidbody2D.position - rigidbody2D.position).normalized;
            fire(pos);
            fire(-pos);
            fire(calcOffset(pos, 45f));
            fire(calcOffset(pos, -45f));
            fire(calcOffset(-pos, 45f));
            fire(calcOffset(-pos, -45f));
            Vector2 sides = new Vector2(-pos.y, pos.x);
            fire(sides);
            fire(-sides);

            timeSinceFire = 0;
            //I found the sound here: https://www.freesound.org/people/jobro/sounds/35474/
            audio.Play();
        }
        timeSinceFire++;
    }

    public override void fire(Vector2 direction)
    {
        Quaternion rot = Quaternion.identity;
        Bullet shell = ((GameObject)Instantiate(bullet, rigidbody2D.position, rot)).GetComponent<Bullet>();
        shell.target = direction;
    }

}
