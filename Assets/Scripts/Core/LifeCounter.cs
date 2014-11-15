using UnityEngine;
using System.Collections;

public class LifeCounter : MonoBehaviour {

    public GameObject shipSprite;
    public GameObject lifeText;
    private ShipMovement sMovement;
    private int lives;

    // Use this for initialization
    void Start()
    {
        sMovement = GetComponent<ShipMovement>();        
        lives = sMovement.lives;
        lifeText.guiText.text = "Lives " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        lives = sMovement.lives;

        lifeText.guiText.text = "Lives " + lives;
    }
}
