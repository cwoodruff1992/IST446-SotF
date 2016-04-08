using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    public Transform shotPrefab;

    public float shootingRate = 0.25f;

    public float shotCooldown;

    public Vector2 shotDirection = new Vector2(0, 1);

    public bool canFire = false;

	// Use this for initialization
	void Start () {
        shotCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (shotCooldown > 0)
        {
            shotCooldown -= Time.deltaTime;
        }
	}

    public void Attack(bool isEnemy)
    {
        if (CanAttack && canFire)
        {
            shotCooldown = shootingRate;

            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

            if(shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            //Movement move = shotTransform.gameObject.GetComponent<Movement>();

            //if(move != null)
            //{

            //    move.direction = shotDirection;
            //}
        }
    }

    public bool CanAttack
    {
        get
        {
            return shotCooldown <= 0f;
        }
    }
}
