using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// RigidBody, PlayerStatsComponent - делаем обязательным компоненты
[RequireComponent(typeof(Rigidbody), typeof(PlayerStatsComponent))] 
public abstract class BasePlayerController : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    protected PlayerStatsComponent _stats;

    private bool _canJump;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _stats = GetComponent<PlayerStatsComponent>();
        StartCoroutine(MoveForward()); 
    }


    // Прыжок. Уровень доступа Protected для возможности использования в Old/New PlayerComponent (дочках)
    protected void Jump()
    {
        if (_canJump)
            _rigidbody.AddForce(transform.up * _stats.GetJumpForce(), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _canJump = false;
    }

    //Корутина постоянного движения вперед
    private IEnumerator MoveForward()
    {
        while (true)
        {
            transform.position += transform.forward * _stats.GetForwardMoveSpeed() * Time.deltaTime * _stats.GetSpeedMultiplier();
            _stats.SetForwardMoveSpeed(_stats.GetSpeedMultiplier()); // Добавляем множитель к скорости персонажа
            yield return null;
        }
    }
}
