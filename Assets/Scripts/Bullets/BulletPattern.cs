using UnityEngine;
using System.Collections;

public abstract class BulletPattern : MonoBehaviour {

    public GameObject target;

    public float timeSinceFire = 0;
    public float fireDelay;
    
    public void Update()
    {
        fire();
    }

    public abstract void fire();
}
