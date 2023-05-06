using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform aimTarget;
    public float speed = 15;
    public float force = 50;
    public Transform ball;
    Vector3 aimTargetInitialPosition;
    bool hitting;
    ShotManager shotManager;
    Shot currentshot;
    // Start is called before the first frame update
    void Start()
    {
       aimTargetInitialPosition = aimTarget.position;
        shotManager = GetComponent<ShotManager>();
        currentshot = shotManager.topspin;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

       if (Input.GetKeyDown(KeyCode.F))
        {
            currentshot = shotManager.topspin;
        }

        else if(Input.GetKeyUp(KeyCode.F))
        {
            hitting=false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            hitting = true;
            currentshot = shotManager.flat;
        }

        else if (Input.GetKeyUp(KeyCode.E))
        {
            hitting = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            hitting = true;
            currentshot = shotManager.flatServe;
        }

        else if (Input.GetKeyUp(KeyCode.R))
        {
            hitting = false;
        }

        if (hitting) 
        { 
            aimTarget.Translate(new Vector3(x, 0, 0) * speed * 2 * Time.deltaTime);
        }

        if ((x != 0 || z != 0) && !hitting)
        {
            transform.Translate(new Vector3(x, 0, z) * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * currentshot.hitforce + new Vector3(0, currentshot.upforce, 0);
        }
        
    }

   
}
