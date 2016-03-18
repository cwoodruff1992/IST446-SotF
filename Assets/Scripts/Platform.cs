using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

 	// Update on collisions with 2D surfaces for platforms
	void OnCollisionEnter2D (Collision2D collision) {

        // Get the instance of the object colliding with me
        Player player = collision.gameObject.GetComponent<Player>();

        
    }
}
