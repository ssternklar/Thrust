using UnityEngine;
using System.Collections;

public class StarfieldScrolling : MonoBehaviour {

    public float Speed = 0;
    private float screenHeightHalf;

	// Use this for initialization
	void Start () {

        screenHeightHalf = Camera.main.orthographicSize;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);

        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position - GetComponent<Rigidbody2D>().velocity);

        if (GetComponent<Rigidbody2D>().position.y < -screenHeightHalf*2)
        {
            GetComponent<Rigidbody2D>().MovePosition(new Vector2(0, 0));
        }
	}
}
