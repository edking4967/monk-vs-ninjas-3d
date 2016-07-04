using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        checkAround(15);	
	}

    void assignMarker(GameObject enemy)
    {

    }

    void checkAround(int distance)
    {
        GameObject[] enemies =  GameObject.FindGameObjectsWithTag("Enemy"); 
        ArrayList closeEnemies = new ArrayList();
        foreach (GameObject enemy in enemies)
        {
            if(Vector3.Distance( gameObject.transform.position, enemy.transform.position) 
                    < distance )
            {
                closeEnemies.Add(enemy); 
                if (enemy.GetComponent<FlashRed>())
                {
                    enemy.GetComponent<FlashRed>().flashForMsec(750);
                }
            }
        }

    }
}
