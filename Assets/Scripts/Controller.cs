using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	protected virtual void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}
	
	//Translates by "velocity" amount
	public virtual void Translate(Vector3 velocity)
	{
		rigidbody.MovePosition(rigidbody.position + velocity);
	}
	
	/// <summary>
    /// Directly sets position to "position"
	/// </summary>
	/// <param name="position">Thing to set position to</param>
	public virtual void MovePosition(Vector3 position)
	{
		rigidbody.MovePosition(position);
	}

    /// <summary>
    /// Destroys the GameObject
    /// </summary>
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
