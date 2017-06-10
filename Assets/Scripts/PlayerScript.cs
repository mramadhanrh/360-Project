using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    [Range(0, 10)]
    public int speed;
    public int score;

    public Text scoreUI;

    private bool resistance;

    public GameObject deathEffect;

    public AudioClip clip;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(100f * speed, 100f * speed));
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
        }

        scoreUI.text = score.ToString();
	}

    IEnumerator BallResistance()
    {
        yield return new WaitForSeconds(1f);
        resistance = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Circle")
        {
            GameObject spikeManager = GameObject.FindGameObjectWithTag("SpikeManager");
            spikeManager.GetComponent<SpikeManager>().RandomSpikes();
            resistance = true;
            StartCoroutine(BallResistance());
            GetComponent<AudioSource>().clip = clip;
            GetComponent<AudioSource>().Play();
        }

        if (col.gameObject.tag == "Spike")
        {
            if (!resistance)
            {
                gameObject.SetActive(false);
                Instantiate(deathEffect, transform.position, Quaternion.identity);

                GetComponent<AudioSource>().clip = clip;
                GetComponent<AudioSource>().Play();

                GameObject go = GameObject.FindGameObjectWithTag("GameOver");
                go.GetComponent<GameOverManager>().CallGameOver(score);
                Destroy(GameObject.Find("PressManager"));

                GameObject ads = GameObject.FindGameObjectWithTag("AdsManager");
                ads.GetComponent<LoadAd>().ShowInters();
            }
                
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Point")
        {
            score++;
            GameObject sp = GameObject.FindGameObjectWithTag("ScorePoint");
            sp.GetComponent<ScorePoint>().SpawnPoint();
        }
    }
}
