using UnityEngine;
using System.Collections;

public class BurstFire : StarFire {

	
	// Update is called once per frame
	void Update () 
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (timeSinceFire >= fireDelay)
        {
            Vector2 dir = (target.rigidbody2D.position - rigidbody2D.position).normalized;
            base.fire(dir);
            base.fire(calcOffset(dir, 45f));
            base.fire(calcOffset(dir, -45f));

            timeSinceFire = 0;
        }
        timeSinceFire++;
	}
}
