using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private bool expand;
    private Vector3 expandVector;
    private Vector3 contractVector;
    private KeyCode moveKey;
    public float upperDomain = 5f;
    public float lowerDomain = 0.75f;
    public float speed; // 2
    public string expandDirection;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        moveKey = KeyCode.Space;

        if (expandDirection == "left")
        {
            expandVector = Vector3.left;
            contractVector = Vector3.right;
        }
        else
        {
            expandVector = Vector3.right;
            contractVector = Vector3.left;
        }

    }

    // Update is called once per frame
    void Update()
    {
        expand = Input.GetKey(moveKey);
        Move(expand);
    }

    void Move(bool expand)
    {
        if (gameManager.isGameActive)
        {
            float currentX = Mathf.Abs(transform.position.x);
            if (expand && currentX < upperDomain)
            {
                transform.Translate(expandVector * Time.deltaTime * speed / 2); // kdp messing around with slow expand, fast contract
            }
            else if (currentX > lowerDomain)
            {
                transform.Translate(contractVector * Time.deltaTime * speed);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            // Stop the game
            gameManager.StopGame();
        }
    }
}
