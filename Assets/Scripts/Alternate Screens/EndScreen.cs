using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<GUIText>().text = (Mathf.Round(GameManager.SharedManager.lastScore * 100) / 100).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0
#if UNITY_EDITOR
            || Input.GetMouseButton(0)
#endif
            )
        {
            Application.LoadLevel("Debug Scene");
        }
	}
}
