using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Vector2 target;
    public Controller controller;

    public float lifeTimer;
    public float timeAlive;

	// Use this for initialization
	void Start () 
    {
        controller = GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        controller.Translate(target*5);

        if (timeAlive >= lifeTimer)
        {
            controller.Die();
        }

        timeAlive += Time.deltaTime;
	}
}
