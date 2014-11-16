using UnityEngine;
using System.Collections;

public abstract class BulletPattern : MonoBehaviour {
    public GameObject bullet;
    public GameObject target;

    public float timeSinceFire = 0;
    public float fireDelay;


    void Start()
    {
        timeSinceFire = Random.Range(0, fireDelay);
        float percent = fireDelay *.1f;
        fireDelay += Random.Range(-percent, percent);
    }
    public void Update()
    {
        //fire();
    }

    public abstract void fire(Vector2 direction);


    public Vector2 calcOffset(Vector2 direction, float angle)
    {
        Quaternion rot = Quaternion.Euler(0, 0, angle);
        return rot * direction;
    }
}
