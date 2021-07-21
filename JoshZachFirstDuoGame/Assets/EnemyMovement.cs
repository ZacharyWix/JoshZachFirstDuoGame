using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed;

    private bool forward;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startPoint.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.position == startPoint.position)
        {
            forward = true;
        } else if (gameObject.transform.position == endPoint.position)
        {
            forward = false;
        }

        if (forward)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endPoint.position, Time.deltaTime * moveSpeed);
        } else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, startPoint.position, Time.deltaTime * moveSpeed);
        }
    }

}
