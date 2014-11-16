using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LifeCounter : MonoBehaviour {
        
    public GameObject lifeText;
    public GameObject shipSprite;
    private ShipMovement sMovement;
    private List<GameObject> livesArray;

    // Use this for initialization
    void Start()
    {        
        sMovement = GetComponent<ShipMovement>();
        lifeText = GameObject.Find("GUI Text");
        lifeText.guiText.text = "Lives: ";
        livesArray = new List<GameObject>();

        float off = 0;        
        for (int i = 0; i < sMovement.lives; i++)
        {
            livesArray.Add((GameObject)Instantiate(shipSprite));
            livesArray[i].transform.position = new Vector2(-1.5f + off, 4.75f);
            off += 0.6f;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.guiText.text = "Lives: ";
    }
}
