using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D enemyRB;
    public GameObject Circle; 
    public float speed = 0.25f;
    public float spawnRange;
    public GameManager gameManager;
    void Awake(){
        Circle = GameObject.Find("Player");
        spawnRange = Random.Range(1, 360);
        transform.RotateAround(Circle.transform.position, Vector3.back, spawnRange);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = gameManager.speed;
    }
    void FixedUpdate()
    {
        Vector3 lookDirection = (Circle.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed, ForceMode2D.Force);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet"){
            gameManager.score += 1;
            gameManager.scoreText.text = "";
            gameManager.scoreText.text += gameManager.score;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player"){
            gameManager.EndGame();
            Destroy(gameObject);
        }
    }
}
