using UnityEngine;
using System.Collections;

public class Ccw4Spiral : BulletPattern {

    public float fireAngle = 0;
    public int increaseAngle = 0;
    public int increment = 5;

    //A timer for if we are unleashing a "burst" or not
    private int burstTimer = 0;
    //Shots per burst
    private int burstNum = 3;
    private int burstsFired = 0;
    //time between bursts
    public int burstPause = 60;

    // Update is called once per frame
    void FixedUpdate()
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

        burstTimer-=1;
        if (burstTimer < 0)
        {
            if (timeSinceFire >= fireDelay)
            {
                Vector2 pos = (target.GetComponent<Rigidbody2D>().position - GetComponent<Rigidbody2D>().position).normalized;

                for (int i = 0; i < 360; i += increaseAngle)
                {
                    fire(calcOffset(pos, i + fireAngle));
                }
                fireAngle += increment;
                timeSinceFire = 0;
                //I found the sound here: https://www.freesound.org/people/jobro/sounds/35474/
                GetComponent<AudioSource>().Play();
                burstsFired += 1;
            }
            if(burstsFired==burstNum)
            {
                burstTimer = burstPause;
                burstsFired = 0;
            }
        }
        timeSinceFire++;

    }

    public override void fire(Vector2 direction)//,Color color)
    {
        Quaternion rot = Quaternion.identity;
        Bullet shell = ((GameObject)Instantiate(bullet, GetComponent<Rigidbody2D>().position, rot)).GetComponent<Bullet>();
        shell.target = direction;
    }
}
