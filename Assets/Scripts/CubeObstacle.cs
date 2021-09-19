using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CubeObstacle : MonoBehaviour
{
	[SerializeField, Range(0f, 15f), Tooltip("Время ожидания в углах")]
	private float _waitInCorners;
	[SerializeField, Range(1f, 15f), Tooltip("Скорость перемещения куба")]
	private float _cubeSpeed = 5f;
	[SerializeField, Range(5f, 10f), Tooltip("Точка Х, в которую двигается Куб")]
	private float _xCoord = 10f;
	[SerializeField, Tooltip("Нужно ли кубу двигаться в другую сторону? (Влево)")]
	private bool _changedDirection;
	private void Start()
	{
		StartCoroutine(PingPongWithDelay());
	}


	// Корутина для передвижения из одной точки в другую
	private IEnumerator MoveFromTo(Vector3 startPosition, Vector3 endPosition, float time)
	{
		var currentTime = 0f;
		while (currentTime < time)
		{
			transform.position = Vector3.Lerp(startPosition, endPosition, 1 - (time - currentTime) / time);
			currentTime += Time.deltaTime;
			yield return null;
		}
		transform.position = endPosition;
	}

	//Корутина для движения Куба
	private IEnumerator PingPongWithDelay()
	{
		while (true)
		{
			if (transform.localPosition.z < -7 || transform.localPosition.z > 7) // Проверка, чтобы при перемещении уровня вперед, куб тоже переместился вперед.
					transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 0f);

			// Если изменненое направление - двигаем куб в "зеркальном" направлении, сначала влево, потом вправо.
			if (_changedDirection)
			{
				yield return MoveFromTo(transform.position, transform.position -= new Vector3(_xCoord, 0f, 0f), _cubeSpeed);
				yield return new WaitForSeconds(_waitInCorners);
				yield return MoveFromTo(transform.position, transform.position += new Vector3(_xCoord, 0f, 0f), _cubeSpeed);
				yield return new WaitForSeconds(_waitInCorners);
			}
			else
            {
				yield return MoveFromTo(transform.position, transform.position += new Vector3(_xCoord, 0f, 0f), _cubeSpeed);
				yield return new WaitForSeconds(_waitInCorners);
				yield return MoveFromTo(transform.position, transform.position -= new Vector3(_xCoord, 0f, 0f), _cubeSpeed);
				yield return new WaitForSeconds(_waitInCorners);
			}
		}
	}


}
