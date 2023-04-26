using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float spawnRate = 5f;
    public GameObject block;
    public bool isGameActive = true;

    public float gapWidth = 1.50f;
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

    public void UpdateScore()
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

        // Creating 3 pieces to each wall
        Vector3 left = block.transform.position;
        Vector3 right = new Vector3(-1 * left.x, left.y, left.z);
        Vector3 middle = new Vector3(0, block.transform.position.y, block.transform.position.z);

        GameObject leftWall = Instantiate(block, left, rotation);
        GameObject middleWall = Instantiate(block, middle, rotation);
        GameObject rightWall = Instantiate(block, right, rotation);

        float middleWallScale = Random.Range(0.5f, 8f);
        middleWall.transform.localScale = new Vector3(middleWallScale, middleWall.transform.localScale.y, middleWall.transform.localScale.z);

        BoxCollider middleBoxCollider = middleWall.GetComponent<BoxCollider>();


        // calculating right edge of middleWall
        float middleRightEdgeX = (middleWall.transform.localScale.x / 2) + middleWall.transform.position.x;
        // calculating side scalar value
        float sideScalar = ((rightWall.transform.position.x - middleRightEdgeX) * 2) - (gapWidth * 2);
        // applying scalar to both walls
        rightWall.transform.localScale = new Vector3(sideScalar, rightWall.transform.localScale.y, rightWall.transform.localScale.z);
        leftWall.transform.localScale = new Vector3(sideScalar, leftWall.transform.localScale.y, leftWall.transform.localScale.z);
    }

    public void StopGame()
    {
        Debug.Log("GAME OVER");
        // kdp uncomment these
        // isGameActive = false;
        // StopCoroutine(SpawnWall());
    }


}
