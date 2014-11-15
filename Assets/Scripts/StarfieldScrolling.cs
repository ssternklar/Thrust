using UnityEngine;
using System.Collections;

public class StarfieldScrolling : MonoBehaviour {

    public float Speed = 0;
    private float screenHeightHalf;

	// Use this for initialization
	void Start () {

        screenHeightHalf = Camera.main.orthographicSize;
        rigidbody2D.velocity = new Vector2(0, Speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        rigidbody2D.velocity = new Vector2(0, Speed);

        rigidbody2D.MovePosition(rigidbody2D.position - rigidbody2D.velocity);

        if (rigidbody2D.position.y < -screenHeightHalf)
        {
            rigidbody2D.MovePosition(new Vector2(0, screenHeightHalf));
        }
	}
}
