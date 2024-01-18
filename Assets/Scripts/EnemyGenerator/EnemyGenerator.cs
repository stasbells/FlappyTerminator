using UnityEngine;

public class EnemyGenerator : ObjectPool
{
    [SerializeField] private Game _game;
    [SerializeField] private Enemy _enemyTamplate;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;
    private bool IsActive;

    private void OnEnable()
    {
        _game.GameStartet += StartGenerate;
        _game.GameOver += StopGenerate;
        _game.GameOver += ResetPool;
    }

    private void OnDisable()
    {
        _game.GameStartet -= StartGenerate;
        _game.GameOver -= StopGenerate;
        _game.GameOver -= ResetPool;
    }

    private void Awake()
    {
        _capacity = _spawnPoints.Length;
        Initialize(_enemyTamplate);
        IsActive = false;
    }

    private void Update()
    {
        if (IsActive)
            OnGenerate();

        ResetInactiveObjects();
    }

    private void OnGenerate()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out Enemy enemy))           
                RandomSpawn(enemy);         
        }
    }

    private void RandomSpawn(Enemy enemy)
    {
        int randomIndex = GetRandomIndex();
        _elapsedTime = 0;

        if (GetActiveObjectsCount() < _spawnPoints.Length)
        {           
            while (!_spawnPoints[randomIndex].IsPointFree)            
                randomIndex = GetRandomIndex();
                          
            enemy.transform.position = _spawnPoints[randomIndex].transform.position;
            enemy.gameObject.SetActive(true);
        }
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, _spawnPoints.Length);
    }

    private void StartGenerate()
    {
        IsActive = true;
    }

    private void StopGenerate()
    {
        IsActive = false;
    }
}