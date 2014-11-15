using UnityEngine;
using System.Collections;

public class StarfieldScrolling : MonoBehaviour {

    public float Speed = 0;

	// Use this for initialization
	void Start () {
        rigidbody.velocity = new Vector2(0, Speed);
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.MovePosition(rigidbody.position + rigidbody.velocity);
        
        if(rigidbody.position.y > camera.orthographicSize)
        {
            rigidbody.MovePosition(new Vector2(rigidbody.position.x, -camera.orthographicSize));
        }
	}
}
