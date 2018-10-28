using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    public  GameObject [] Enemy;

    private int y;
    [SerializeField] private float nextActionTime = 5f;
    [SerializeField] private float period = 0.1f;
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
	{
        if (Time.timeSinceLevelLoad > nextActionTime)
	    {
	        nextActionTime += period;
	        Instantiate(Enemy[Random.Range(0, Enemy.Length)], new Vector3(25, Random.Range(-4, 4), 1), new Quaternion(0, 0, 0, 0));
	        if (period > 1)
	        {
	            period /= 1.5f;
	        }
	        else
	        {
	            period -= 0.01f;
	        }
	    }
	   
    }

    void OnTriggerEnter2D(Collider2D colision)
    {
        Destroy(colision.gameObject);
    }

}
