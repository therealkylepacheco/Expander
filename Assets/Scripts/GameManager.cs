using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float spawnRate = 2f;
    public GameObject block;
    public bool isGameActive = true;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"{score}";
        StartCoroutine(SpawnWall());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateScore()
    {
        score++;
        scoreText.text = $"{score}";
    }

    IEnumerator SpawnWall()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            GenerateWall();
        }
    }



    void GenerateWall()
    {
        Quaternion rotation = block.transform.rotation;

        Vector3 left = block.transform.position;
        Vector3 right = new Vector3(-1 * left.x, left.y, left.z);
        Vector3 middle = new Vector3(0, block.transform.position.y, block.transform.position.z);

        Instantiate(block, left, rotation);
        Instantiate(block, middle, rotation);
        Instantiate(block, right, rotation);


        /*
        Need to create three things here
        1.) left wall
        2.) right wall (mirror of left)
        3.) middle

        * Need to make is to that it's always possible for ball to pass inbetween
        * 1.25 clearance on either side
        */


        // Instantiate(middleWall);
    }


}
