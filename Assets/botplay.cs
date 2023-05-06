using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botplay : MonoBehaviour
{
    float speed = 15;
    public Transform ball;
    public Transform hitTarget;
    float force = 18;
    public string ballTag = "Ball";
    Vector3 targetPos;

    public Transform[] targets;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    void Move()
    {
        targetPos.z = ball.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    Vector3 PickTarget()
    {
        int randomVal = Random.Range(0, targets.Length);
        return targets[randomVal].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = PickTarget() - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 8, 0);
            Vector3 ballDir = ball.position - transform.position;
        }

    }
}
