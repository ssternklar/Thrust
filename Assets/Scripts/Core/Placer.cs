using UnityEngine;
using System.Collections;

public class Placer : MonoBehaviour {

    public GameObject[] objects;
    //Camera activeCamera = Camera.allCameras;

    public StarfieldScrolling stars;
    public GUIText text;
    public Controller controller;

    public float updatesPassed;
    public float updatesNeeded;
    public float difficultyScale;

    public bool difficult;
    public float difficultTime;
    public float maxHardTime;

	// Use this for initialization
	void Start () 
    {
        stars = GameObject.Find("MasterStarField").GetComponent<StarfieldScrolling>();
        text = GetComponent<GUIText>();
        controller = GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (Time.frameCount % 1800 == 0)
        {
            updatesNeeded *= difficultyScale;
            stars.Speed /= difficultyScale;
            difficult = true;
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

        if (difficult && difficultTime < maxHardTime)
        {
            text.enabled = true;
            difficultTime += Time.deltaTime;
            controller.Translate(new Vector2(0, ((float)(1 / maxHardTime)) * Time.fixedDeltaTime));
        }
        else
        {
            text.enabled = false;
            difficultTime = 0;
            if (difficult)
            {
                controller.Translate(new Vector2(0, -1f));
            }
            difficult = false;
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
