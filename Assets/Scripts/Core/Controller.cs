using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Controller : MonoBehaviour {
    Sprite sprite;
    public float maxSpeed;
    public float SpriteHalfWidth
    {
        get { return sprite.bounds.extents.x; }
    }

    public float SpriteHalfHeight
    {
        get { return sprite.bounds.extents.y; }
    }



	// Use this for initialization
	protected virtual void Start () {
        sprite = GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}
	
	//Translates by "velocity" amount
	public virtual void Translate(Vector2 velocity)
	{
		rigidbody2D.MovePosition((rigidbody2D.position + velocity * Time.fixedDeltaTime));
	}
	
	/// <summary>
    /// Directly sets position to "position"
	/// </summary>
	/// <param name="position">Thing to set position to</param>
	public virtual void MovePosition(Vector2 position)
	{
        Vector2 translation = position - rigidbody2D.position;
        if(translation.magnitude > maxSpeed * Time.fixedDeltaTime)
        {
            Translate(translation.normalized * maxSpeed);
        }
        else
        {
            rigidbody2D.MovePosition(position);
        }
	}

    /// <summary>
    /// Moves the controller on the X-axis
    /// </summary>
    /// <param name="xPos">Amount to move by</param>
    public virtual void MoveX(float xPos)
    {
        MovePosition(new Vector2(xPos, 0));
    }

    /// <summary>
    /// Moves the controller on the Y-axis
    /// </summary>
    /// <param name="xPos">Amount to move by</param>
    public virtual void MoveY(float yPos)
    {
        MovePosition(new Vector2(0, yPos));
    }

    /// <summary>
    /// Destroys the GameObject
    /// </summary>
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
