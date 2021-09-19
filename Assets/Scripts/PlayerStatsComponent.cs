using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsComponent : MonoBehaviour
{
    [SerializeField, Range(1f, 10f), Header("Настройки персонажа")]
    private float _jumpForce = 1f;
    [SerializeField, Range(1f, 30f)]
    private float _forwardMoveSpeed = 1f;
    [SerializeField, Range(10f, 30f)]
    private float _sideMoveSpeed = 10f;
    [SerializeField, Range(0.01f, 2f), Tooltip("Множитель скорости")]
    private float _speedMultiplier = 0.01f;




    // Возвращаем значения приватных полей
    public float GetJumpForce()
    {
        return _jumpForce;
    }

    public float GetForwardMoveSpeed()
    {
        return _forwardMoveSpeed;
    }

    public float GetSideMoveSpeed()
    {
        return _sideMoveSpeed;
    }

    public float GetSpeedMultiplier()
    {
        return _speedMultiplier;
    }

    public float SetForwardMoveSpeed(float number)
    {
        return _forwardMoveSpeed += number;
    }
}
