using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public Text scoreUI;
    public GameObject GameOver;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CallGameOver(int score)
    {
        GameOver.SetActive(true);
        scoreUI.text = score.ToString();
    }

    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
