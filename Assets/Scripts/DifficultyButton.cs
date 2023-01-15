using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] int _difficulty;
    Button _button;
    GameManager _gameManager;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void SetDifficulty()
    {
        _gameManager.StartGame(_difficulty);
    }
}
