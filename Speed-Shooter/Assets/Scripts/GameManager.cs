using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool spawnActive = false;
    private bool gameOn = false;
    [SerializeField]private float spawnRate = 2;
    public float speed = 0.25f;
    [SerializeField]private float numberOfSpawns;
    public int score = 0;
    public int highScore = 0;
    public GameObject enemyPrefab;
    public GameObject Circle;
    public GameObject mainMenu;
    public GameObject gameUI;
    private GameObject[] enemy; 
    //public CameraRotator cameraRotator;   
    public TextMeshProUGUI scoreText;
    public HighScoreLoader highScoreLoader;
    void Update()
    {
        if (Input.GetKeyDown("return") && gameOn == false){
            StartGame();
        }
        if (Input.GetKeyDown("escape")){
            Application.Quit();
        }
        if (Input.GetKeyDown("z")){
            highScoreLoader.ResetHighScore();
        }
    }

    void StartGame(){
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        Debug.Log("Game on");
        spawnActive = true;
        gameOn = true;
        StartCoroutine(SpawnManager());
        //cameraRotator.isInAction = true;
        //cameraRotator.RotationManager();
    }

    public void EndGame(){
        spawnActive = false;
        StopAllCoroutines();
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in enemy)
        {
            Destroy(target);
        }
        //cameraRotator.isInAction = false;
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
        Debug.Log("Game over");
        gameOn = false;
        highScore = score;
        highScoreLoader.SetHighScore(highScore);
        score = 0;
        spawnRate = 2;
        speed = 0.25f;
    }
    IEnumerator SpawnManager(){
        while (spawnActive == true){
            yield return new WaitForSecondsRealtime(spawnRate);
            speed += 0.01f;
            Debug.Log("New speed is " + speed);
            numberOfSpawns += 1;
            if (numberOfSpawns == 5){
                spawnRate -= 0.1f;
                Debug.Log("New spawn rate is " + spawnRate);
                numberOfSpawns = 0;
            }
            GameObject enemy = Instantiate(enemyPrefab, enemyPrefab.transform.position, enemyPrefab.transform.rotation);
        }
        yield return new WaitForEndOfFrame();
    }
}
