using UnityEngine;
using System.Collections;

public class animalsAI : MonoBehaviour {

    private int orientation;
    private float prob;
    private Vector3 rotation;
    
	// Update is called once per frame
	void Update () {
        prob = UnityEngine.Random.Range(0.0f, 1.0f);
        orientation = UnityEngine.Random.Range(1, 5);

        // First we have a 10% chance of the animal to rotate.
        if (prob <= 0.01f)
        {
            // Then we need to know in what direction it'll move.
            if (orientation == 1)
            {
                // Front...
                rotation = new Vector3(0, 0.0f, 0);
                transform.rotation = Quaternion.Euler(rotation);
            }
            else if (orientation == 2)
            {
                // Left rotation.
                rotation = new Vector3(0, 90.0f, 0);
                transform.rotation = Quaternion.Euler(rotation);
            }
            else if (orientation == 3)
            {
                // Right rotation.
                rotation = new Vector3(0, 270.0f, 0);
                transform.rotation = Quaternion.Euler(rotation);
            }
            else
            {
                // Back rotation.
                rotation = new Vector3(0, 180.0f, 0);
                transform.rotation = Quaternion.Euler(rotation);
            }
        }
        // Then we must move the animal.
        transform.position += transform.forward * 0.1f;
		}
}
