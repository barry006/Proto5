using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] int _pointValue;
    [SerializeField] ParticleSystem _explosionParticle;
    float _minSpeed = 12;
    float _maxSpeed = 16;
    float _maxTorque = 10;
    float _xRange = 4;
    float _ySpawnPos = -6;
    GameManager _gameManager;
    Rigidbody _targetRb;

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _targetRb = GetComponent<Rigidbody>();

        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }
    private void Update()
    {
        if (transform.position.y < -9 && !gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
        else if (transform.position.y < -9)
        {
            Destroy(gameObject);
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new(Random.Range(-_xRange, _xRange), _ySpawnPos);
    }
    private void OnMouseDown()
    {
        if (_gameManager.isGameActive && !_gameManager.gameOver)
        {
            Destroy(gameObject);
            Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
            _gameManager.UpdateScore(_pointValue);
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
    }
    */
}
