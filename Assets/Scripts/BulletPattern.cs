using UnityEngine;
using System.Collections;

public abstract class BulletPattern : MonoBehaviour {

    Vector2 target;

    public float fireDelay;
    public float timer;
    
    public void Update()
    {
        timer += Time.deltaTime;
    }

    public abstract void fire();
}
