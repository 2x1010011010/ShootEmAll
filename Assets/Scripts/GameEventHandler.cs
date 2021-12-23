using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameEventHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerAnimationSwitcher _animation;
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private List<ShootingPoint> _shootingPoints;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private bool _isOnPoint = false;
    private bool _isOnFinishPoint = false;
    private int _currentPointIndex;
    private int _nextPointIndex;

    private const string _idleAnimation = "m_pistol_idle_A";
    private const string _runAnimation = "m_pistol_run_rm";
    private const string _shootingAnimation = "m_pistol_shoot";

    private void Start()
    {
        Time.timeScale = 0;
        _animation.PlayAnimation(_idleAnimation);
        _currentPointIndex = 0;
        _nextPointIndex = 1;
        _startScreen.Open();
        _gameOverScreen.Close();
    }

    private void OnEnable()
    {
        _input.OnScreenClick += OnScreenClick;
        _playerCollisionHandler.OnPointArrived += OnPointArrived;
        _playerCollisionHandler.OnFinishPointArrived += OnFinishPointArrived;
    }

    private void OnDisable()
    {
        _input.OnScreenClick -= OnScreenClick;
        _playerCollisionHandler.OnPointArrived -= OnPointArrived;
        _playerCollisionHandler.OnFinishPointArrived -= OnFinishPointArrived;
    }

    private void OnScreenClick()
    {
        if (Time.timeScale == 0 && _currentPointIndex == 0)
        {
            Time.timeScale = 1;
            _animation.PlayAnimation(_runAnimation);
            _startScreen.Close();
            GoToNext(_shootingPoints[_nextPointIndex].transform.position);
        }
        else if(_isOnFinishPoint)
        {
            ReloadScene();
        }
        else if (_shootingPoints[_currentPointIndex].EnemiesCount == 0)
        {
            GoToNext(_shootingPoints[_nextPointIndex].transform.position);
        }
        else if (_isOnPoint)
        {
            _playerMover.LookAtEnemy(_input.TapPosition);
            _player.PushTrigger(_input.TapPosition);
            _animation.PlayAnimation(_shootingAnimation);
        }   
    }

    private void OnPointArrived() 
    {
        _isOnPoint = true;    
        _animation.PlayAnimation(_idleAnimation);
    }

    private void GoToNext(Vector3 point)
    {
        _isOnPoint = false;
        _animation.PlayAnimation(_runAnimation);
        _playerMover.MoveToPoint(point);
        _currentPointIndex = _nextPointIndex;
        _nextPointIndex++;
    }

    private void OnFinishPointArrived()
    {
        _gameOverScreen.Open();
        _isOnFinishPoint = true;
    }


    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
