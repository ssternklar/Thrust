using UnityEngine;
using System.Collections;

public class BurstFire : StraightFire {

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
            base.fire(target.rigidbody2D.position);
            base.fire(calcOffset(target.rigidbody2D.position, true));
            base.fire(calcOffset(target.rigidbody2D.position, false));

            timeSinceFire = 0;
        }
        timeSinceFire++;
	}

    Vector2 calcOffset(Vector2 position, bool left)
    {
        Vector2 off = this.rigidbody2D.position - position;
        Vector2 perpendicular = new Vector2(-off.y, off.x);

        if (left)
        {
            return perpendicular;
        }
        return -perpendicular;
    }
}
