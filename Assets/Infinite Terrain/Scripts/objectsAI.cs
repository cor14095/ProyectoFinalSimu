using UnityEngine;
using System.Collections;

public class objectsAI : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.y <= -50)
        {
            Destroy(gameObject);
        }
	}
}
