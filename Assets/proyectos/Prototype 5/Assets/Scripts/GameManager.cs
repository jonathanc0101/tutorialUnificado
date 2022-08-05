using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 2;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score;

    private bool isGameActive = true;

    private GameObject mainCanvas;
    private GameObject gameCanvas;

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        VeryHard
    }

    // Start is called before the first frame update
    void Start()
    {

        mainCanvas = GameObject.Find("MainScreenCanvas");
        gameCanvas = GameObject.Find("GameCanvas");

        score = 0;

        iniciarInterfaz();

    }
    void setDifficulty(Difficulty dif)
    {
        switch (dif)
        {
            case Difficulty.Easy:
                spawnRate = 2;
                break;
            case Difficulty.Medium:
                spawnRate = 1.5f;
                break;
            case Difficulty.Hard:
                spawnRate = 1f;
                break;
            case Difficulty.VeryHard:
                spawnRate = 0.1f;
                break;

            default:
                spawnRate = 2;
                break;

        }
    }
    void iniciarInterfaz()
    {
        mainCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    void iniciarInterfazJuego()
    {
        mainCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void iniciarJuegoFacil()
    {
        setDifficulty(Difficulty.Easy);
        iniciarJuego();
    }
    public void iniciarJuegoMedio()
    {
        setDifficulty(Difficulty.Medium);
        iniciarJuego();
    }
    public void iniciarJuegoDificil()
    {
        setDifficulty(Difficulty.Hard);
        iniciarJuego();
    }

    public void iniciarJuegoMuyDificil()
    {
        setDifficulty(Difficulty.VeryHard);
        iniciarJuego();
    }

    public void iniciarJuego()
    {
        iniciarInterfazJuego();
        StartCoroutine(SpawnTarget());

        updateScore();
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            if (isGameActive)
            {
                Instantiate(targets[index]);
            }
        }
    }

    void updateScore()
    {
        updateScore(0);
    }
    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartButton.gameObject.SetActive(false);

        iniciarInterfazJuego();
    }
}
