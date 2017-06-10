using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour {

    public GameObject point;

	// Use this for initialization
	void Start () {
        SpawnPoint();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPoint()
    {
        Vector2 pos = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        GameObject pointObject = Instantiate(point, pos, Quaternion.identity);
        pointObject.transform.parent = gameObject.transform;
    }
}
