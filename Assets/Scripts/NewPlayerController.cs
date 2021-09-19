using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс для управления в новой системе ввода
public class NewPlayerController : BasePlayerController
{
    private RunnerPlayer _controls;

    protected override void Start()
    {
        base.Start();
    }

    private void Awake()
    {
        _controls = new RunnerPlayer();
        _controls.Runner.Jump.performed += _ => Jump();
    }

    void Update()
    {
        var direction = _controls.Runner.SideMove.ReadValue<float>() * _stats.GetSideMoveSpeed() * Time.deltaTime;

        if (direction == 0) return;
        _rigidbody.velocity += direction * transform.right; // Двигаемся в сторону

    }

    private void OnEnable()
    {
        _controls.Runner.Enable();
    }

    private void OnDisable()
    {
        _controls.Runner.Disable();
    }

    private void OnDestroy()
    {
        _controls.Runner.Jump.performed -= _ => Jump();
        _controls.Dispose();
    }
}
