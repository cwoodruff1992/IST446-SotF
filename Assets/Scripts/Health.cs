using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int hp = 100;
    public bool isEnemy = true;
    //private PointDisplay points;
    //private PointDisplay health;

    void Start()
    {
        //points = GameObject.Find("_GameMaster").GetComponent<PointDisplay>();
        //health = GameObject.Find("_GameMaster").GetComponent<PointDisplay>();
    }

	void OnTriggerEnter2D (Collider2D collider) {
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        
        if (shot != null)
        {
            if(shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
                //health.UpdateHealth();
                Destroy(shot.gameObject);

                if (hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void FixedUpdate ()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
