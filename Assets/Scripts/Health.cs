using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    // 
    public int hp = 5;
    public bool isEnemy = true;
    public int deathPoints = 100;
    private GameMaster GM;
    private int playerNum;

    void Start()
    {
        GM = GameObject.Find("_GameMaster").GetComponent<GameMaster>();
        playerNum = gameObject.GetComponent<Player>().number;
    }

	void OnTriggerEnter2D (Collider2D collider) {
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        
        if (shot != null)
        {
            if(shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
                Destroy(shot.gameObject);

                if (hp <= 0)
                {
                    GM.Died(playerNum);
                    GM.AllotScore(shot.GetComponentInParent<Player>().number, deathPoints);
                    Destroy(gameObject);
                }
            }
        }
    }

    void FixedUpdate ()
    {
        if (hp <= 0)
        {
            GM.Died(playerNum);
            Destroy(gameObject);
        }
    }
}
