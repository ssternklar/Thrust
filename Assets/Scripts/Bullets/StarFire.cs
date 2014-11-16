using UnityEngine;
using System.Collections;

public class StarFire : BulletPattern {

	
	// Update is called once per frame
    void Update()
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
            audio.Play();
        }
        timeSinceFire++;
    }

    public override void fire(Vector2 direction)
    {
        GameManager.SharedManager.GetBullet(transform.position, direction, sprite);
    }

}
