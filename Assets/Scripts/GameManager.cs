using UnityEngine;
using System.Collections;

public class GameManager {

    private static GameManager sharedManager;
    public static GameManager SharedManager
    {
        get { if (sharedManager != null) return sharedManager; else return new GameManager(); }
    }

    public float screenWidth;
    public float screenHeight;

    private GameManager()
    {
        sharedManager = this;
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        screenHeight = Camera.main.orthographicSize;
    }
	
}
