using UnityEngine;
using System.Collections;

public class Placer : MonoBehaviour {

    public GameObject[] objects;
    //Camera activeCamera = Camera.allCameras;

    public StarfieldScrolling stars;

    public float updatesPassed;
    public float updatesNeeded;
    public float difficultyScale;

	// Use this for initialization
	void Start () 
    {
        stars = GameObject.Find("MasterStarField").GetComponent<StarfieldScrolling>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (Time.frameCount % 1800 == 0)
        {
            updatesNeeded *= difficultyScale;
            stars.Speed /= difficultyScale;
        }
        else if (Time.frameCount % 900 == 0)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");

            if (objs != null)
            {
                foreach (GameObject enemy in objs)
                {
                    enemy.GetComponent<BulletPattern>().fireDelay *= difficultyScale;
                }
            }
        }

        if (updatesPassed < updatesNeeded)
        {
            updatesPassed++;
            return;
        }

        int num = Random.Range(0, objects.Length);
        Vector2 pos = new Vector2(Random.Range(-GameManager.SharedManager.screenWidth,GameManager.SharedManager.screenWidth), GameManager.SharedManager.screenHeight);//Camera.main.transform.position.x + Random.Range(0, Camera.main.pixelWidth), Camera.main.transform.position.y+Camera.main.pixelHeight + 5);

        Instantiate(objects[num],pos,Quaternion.identity);

        updatesPassed = 0;
	}
}
