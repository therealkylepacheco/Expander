using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool expand;
    private Vector3 expandVector;
    private Vector3 contractVector;
    public float upperDomain = 5f;
    public float lowerDomain = 0.75f;
    public float speed;
    public string expandDirection;

    // Start is called before the first frame update
    void Start()
    {
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
        expand = Input.GetKey(KeyCode.Space);
        Move(expand);
    }

    void Move(bool expand)
    {
        float currentX = Mathf.Abs(transform.position.x);
        if (expand && currentX < upperDomain)
        {
            transform.Translate(expandVector * Time.deltaTime * speed);
        }
        else if (currentX > lowerDomain)
        {
            transform.Translate(contractVector * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            // Stop the game
        }
    }
}
