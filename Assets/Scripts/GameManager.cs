using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _progress;

    private int _currentIndex = 0;
    [SerializeField, Tooltip("Шаг / длина одного блока")]
    private float _step = 15f;
    [SerializeField, Tooltip("Z координата последнего блока")]
    private float _lastBlockZ = 105f;

    public static GameManager Manager;
    
    [SerializeField, Range (1f, 100f), Tooltip ("Здоровье игрока")]
    private int _health = 3;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private Transform[] _blocks;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private Text _counter;
    [SerializeField]
    private float _timeLeft = 300f;

    private PlayerStatsComponent _stats;

    private void Start()
    {

        var playerObj = GameObject.Find("Player");
        _stats = playerObj.GetComponent<PlayerStatsComponent>();
        
    }

    private void Awake()
    {
        Manager = this;
    }

   public void SetDamage(int damage)
    {
        _health -= damage;

        // Уменьшаем скорость передвижения при получении урона
        _stats.SetForwardMoveSpeed( -(_stats.GetForwardMoveSpeed() / 1.5f) );
        
        // Выводим в консоль текущее здоровье
        Debug.Log("Current Health: " + _health);
        
        if (_health <= 0)
        {
            Debug.Log("---Game Finished---");
            // Останавливаем игру, если кончилось здоровье
            UnityEditor.EditorApplication.isPaused = true;
        }
    }

    private void Update()
    {
        if (_player.position.y < -5f) SetDamage(1000000);

        _timeLeft -= Time.deltaTime;
        _counter.text = "Time Left:" + Mathf.Round(_timeLeft);
        if (_timeLeft <= 0)
        {
            Debug.Log("---Тime is up---");
            UnityEditor.EditorApplication.isPaused = true;
        }
    }


    public void UpdateLevel()
    {
        _progress++; // Увеличиваем прогресс
        _text.text = "Blocks: " + _progress.ToString(); // Пишем прогресс в UI

        _lastBlockZ += _step;

        var position = _blocks[_currentIndex].position;
        position.z = _lastBlockZ;
        _blocks[_currentIndex].position = position;

        _currentIndex++;

        if(_currentIndex >= _blocks.Length)
        {
            _currentIndex = 0;
        }
    }
}
