using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private bool _isDamage;

    
    void Start()
    {
        // Проставляем в коллайдер объекта признак триггера, если в инспекторе забыли проставить.
        _collider.isTrigger = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Если триггер на урон -> наносим урон
        if (_isDamage)
        {
            GameManager.Manager.SetDamage(1);
        }
        // Если триггер НЕ на урон -> обновляем уровень
        else
        {
            GameManager.Manager.UpdateLevel();
        }
    }
}
