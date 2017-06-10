using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{

    private GameObject[] spikes;
    private List<int> numbers = new List<int>(12);
    private bool firstExecute = false;
    private int score;
    private int maxSpike;

    // Use this for initialization
    void Start()
    {
        spikes = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject spike in spikes)
        {
            spike.SetActive(false);
        }
        maxSpike = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomSpikes()
    {

        foreach (GameObject spike in spikes)
        {
            spike.GetComponent<Animator>().Play("SpikeExit");
            spike.SetActive(false);
        }

        score = GameObject.FindGameObjectWithTag("Ball").GetComponent<PlayerScript>().score;
        if (score > 10)
        {
            score = 10;
        }

        int j;
        int[] forList = new int[5 + score];
        numbers = new List<int>(forList);

        for (int i = 0; i <= (maxSpike - 1) + score; i++)
        {
            Debug.Log(i);
            do
            {
                j = Random.Range(0, spikes.Length);
            } while (numbers.Contains(j));
            //j = Random.Range(0, spikes.Length);
            //spikes[j].SetActive(true);
            numbers.Add(j);
        }
        if (!firstExecute)
            firstExecute = true;
        else
            numbers.RemoveRange(0, maxSpike + score);

        foreach (int number in numbers)
        {
            spikes[number].SetActive(true);
        }
    }
}
