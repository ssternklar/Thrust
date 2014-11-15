using UnityEngine;
using System.Collections;

public class LifeCounter : MonoBehaviour {

    public GameObject shipSprite;
    public GameObject lifeText;
    private ShipMovement sMovement;

    // Use this for initialization
    void Start()
    {
        sMovement = GetComponent<ShipMovement>();
        lifeText = GameObject.Find("GUI Text");
        lifeText.guiText.text = "Lives " + sMovement.lives;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.guiText.text = "Lives " + sMovement.lives;
    }
}
