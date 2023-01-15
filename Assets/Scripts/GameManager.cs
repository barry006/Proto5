using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // public Button restartButton;
    public bool isGameActive;
    public bool gameOver = false;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _gameOverText;
    [SerializeField] List<GameObject> _targets;
    [SerializeField] GameObject _titleScreen;
    float _spawnRate = 1f;
    int _score = 0;

    public void StartGame(int difficulty)
    {
        Time.timeScale = 1f;
        gameOver = false;
        isGameActive = true;
        UpdateScore(0);
        _spawnRate /= difficulty;
        _titleScreen.SetActive(false);
        StartCoroutine(SpawnTarget());       
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, _targets.Count);
            Instantiate(_targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = "Score : " + _score;
    }
    public void GameOver()
    {
        _gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f;
        gameOver = true;
        //restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
