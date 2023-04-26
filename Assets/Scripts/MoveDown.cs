using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 0f;
    private float lowerBound = -5f;
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

            if (transform.position.z < lowerBound)
            {
                Destroy(gameObject);
            }
        }
    }
}
