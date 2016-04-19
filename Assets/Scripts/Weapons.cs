using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    public Transform shotPrefab;
    public float shootingRate = 0.25f;
    public float shotCooldown;
    public bool canFire = false;
    private Vector2 shotDirection = new Vector2(1, 0);

    private bool right;
    //private int last;

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

            right = gameObject.GetComponent<Player>().right;

            if(shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            Movement move = shotTransform.gameObject.GetComponent<Movement>();

            if (move != null)
            {
                move.direction = shotDirection;
                if (right)
                {
                    move.direction.x = 1;
                    shotTransform.position = new Vector3(shotTransform.position.x - 1.2f, shotTransform.position.y, shotTransform.position.z);
                }
                else if(!right)
                {
                    move.direction.x = -1;
                    shotTransform.position = new Vector3(shotTransform.position.x + 1.2f, shotTransform.position.y, shotTransform.position.z);
                }
            }
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
