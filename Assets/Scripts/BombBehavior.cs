using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour {

    //the explosion prefab goes here
    public GameObject explosionPrefab;
    //the explosion prefab for target goes here
    public GameObject targetExplosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            //look for each game ogject with tag "Target"
            foreach (GameObject target in GameObject.FindGameObjectsWithTag("Target"))
            {
                //destroy the target
                Destroy(target);

                //show the explosion
                Instantiate(targetExplosionPrefab, target.transform.position, target.transform.rotation);
            }

            if (explosionPrefab)
            {
                // Instantiate an explosion effect at the gameObjects position and rotation
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            // destroy the projectile
            Destroy(collision.gameObject);

            // destroy self
            Destroy(gameObject);
        }
    }
}
