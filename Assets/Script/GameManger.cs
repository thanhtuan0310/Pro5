using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManger : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI gameovertext;
    public List<GameObject> target;
    private float rate = 1.0f;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdargeScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(rate);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index]);

        }
    }

    public void UpdargeScore(int scoreadd)
    {
        score += scoreadd;
        scoretext.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameovertext.gameObject.SetActive(true);
    }
}
