using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol3 : MonoBehaviour {
    public GameObject[] waypints;
    public int num = 0;
    public float minDis;
    public float speed;
    public bool rand = false;
    public bool go = true;
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(gameObject.transform.position, waypints[num].transform.position);

        if (go)
        {
            if (dist > minDis)
            {
                Move();
            }
            else
            {
                if (!rand)
                {
                    if (num + 1 == waypints.Length)
                    {
                        num = 0;
                    }
                    else
                    {
                        num++;
                    }

                }
                else
                {
                    num = Random.Range(0, waypints.Length);
                }
            }
        }
    }
    public void Move()
    {
        gameObject.transform.LookAt(waypints[num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }
}
