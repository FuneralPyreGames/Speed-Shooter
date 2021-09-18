using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool spawnActive = false;
    [SerializeField]private float spawnRate = 2;
    public GameObject enemyPrefab;
    public GameObject Circle;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        spawnActive = true;
        StartCoroutine(SpawnManager());
    }
    void Update()
    {
        
    }
    IEnumerator SpawnManager(){
        while (spawnActive == true){
            yield return new WaitForSecondsRealtime(spawnRate);
            GameObject enemy = Instantiate(enemyPrefab, enemyPrefab.transform.position, enemyPrefab.transform.rotation);
        }
        yield return new WaitForEndOfFrame();
    }
}
