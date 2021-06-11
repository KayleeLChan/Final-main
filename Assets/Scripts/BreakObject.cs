using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    public GameObject break1;
    public GameObject break2;
    public GameObject break3;

    public float randBreak;

    //When a tool collides with object, generate a random number that spawns in a random broken version of object
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Tool")
        {
            RandomGenerate();
            if(randBreak == 1)
            {
                Instantiate(break1, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
            if (randBreak == 2)
            {
                Instantiate(break2, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
            if (randBreak == 3)
            {
                Instantiate(break3, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

    void RandomGenerate()
    {
        randBreak = Random.Range(1, 3);
    }
}
