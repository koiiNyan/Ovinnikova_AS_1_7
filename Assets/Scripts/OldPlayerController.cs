using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс для управления в старой системе ввода
public class OldPlayerController : BasePlayerController
{

    protected override void Start()
    {
        base.Start();
    }


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump(); // Прыгаем при нажатии на Space

        var direction = Input.GetAxis("Horizontal") * _stats.GetSideMoveSpeed() * Time.fixedDeltaTime;

        if (direction == 0) return;
        _rigidbody.velocity += direction * transform.right; // Двигаемся в сторону
    }
}
