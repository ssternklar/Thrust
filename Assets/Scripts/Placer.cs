using UnityEngine;
using System.Collections;

public class Placer : MonoBehaviour {

    public GameObject[] objects;
    //Camera activeCamera = Camera.allCameras;

    public float updatesPassed;
    public float updatesNeeded;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (updatesPassed < updatesNeeded)
        {
            updatesPassed++;
            return;
        }

        int num = Random.Range(0, objects.Length);
        Vector2 pos = new Vector2(Random.Range(-(Camera.main.aspect*(Camera.main.orthographicSize))/2,(Camera.main.aspect*(Camera.main.orthographicSize))/2), Camera.main.orthographicSize);//Camera.main.transform.position.x + Random.Range(0, Camera.main.pixelWidth), Camera.main.transform.position.y+Camera.main.pixelHeight + 5);
        Quaternion rot = Quaternion.Euler(0,0,0);
        Debug.Log(Camera.main.aspect);

        Instantiate(objects[num],pos,rot);

        updatesPassed = 0;
	}
}
