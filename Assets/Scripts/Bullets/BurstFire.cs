using UnityEngine;
using System.Collections;

public class BurstFire : StarFire {

	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (timeSinceFire >= fireDelay)
        {
            Vector2 dir = (target.GetComponent<Rigidbody2D>().position - GetComponent<Rigidbody2D>().position).normalized;
            base.fire(dir);
            base.fire(calcOffset(dir, 45f));
            base.fire(calcOffset(dir, -45f));

            timeSinceFire = 0;
            //I found the sound here: https://www.freesound.org/people/jobro/sounds/35474/
            GetComponent<AudioSource>().Play();
        }
        timeSinceFire++;
	}
}
