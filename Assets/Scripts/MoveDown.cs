using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 0f;
    private float lowerBound = -4f;
    private bool scoreCounted = false;
    // Start is called before the first frame update
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);

            if (transform.position.x == 0
            && transform.position.z < 0
            && !scoreCounted)
            {
                // add to score when middle passes origin
                gameManager.UpdateScore();
                scoreCounted = true;
            }

            if (transform.position.z < lowerBound)
            {
                Destroy(gameObject);
            }
        }
    }
}
