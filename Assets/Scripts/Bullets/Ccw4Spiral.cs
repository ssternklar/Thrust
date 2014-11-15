using UnityEngine;
using System.Collections;

public class Ccw4Spiral : BulletPattern {

    public float fireAngle = 0;
    public int increaseAngle = 0;
    public int increment = 5;
    
    //public int numberOfPoints = 4;
    // Use this for initialization
    void Start()
    {
        //increaseAngle = 360 / numberOfPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(increaseAngle<10)
        {
            increaseAngle = 10;
        }
        if(fireAngle>360)
        {
            fireAngle -= 360;
        }
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (timeSinceFire >= fireDelay)
        {
            Vector2 pos = (target.rigidbody2D.position - rigidbody2D.position).normalized;

            for (int i = 0; i < 360; i+= increaseAngle)
            {
                fire(calcOffset(pos, i + fireAngle));
            }
            fireAngle += increment;
            timeSinceFire = 0;
        }
        timeSinceFire++;
    }

    public override void fire(Vector2 direction)//,Color color)
    {
        Quaternion rot = Quaternion.identity;
        Bullet shell = ((GameObject)Instantiate(bullet, rigidbody2D.position, rot)).GetComponent<Bullet>();
        shell.target = direction;
    }
}
