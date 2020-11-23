﻿/*using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyAI : MonoBehaviour
{

	// точки, между которыми бот будет двигаться, в ожидании игрока
	public Transform waypointA;
	public Transform waypointB;

	public float speed = 1.5f; // скорость движения
	public float acceleration = 10;
	public float searchDistance = 3; // с какого расстояния бот сможет "увидеть" игрока
	public float checkDistance = 1; // расстояние с которого бот проверку перед собой, на наличие обрыва
	public float resetDistance = 50; // макс дистанция, когда бот отслеживает позицию игрока
	public float height = 2; // маск высота, для падения (например, если надо спуститься по ступеням за игроком)

	// действие, когда позиция игрока не отслеживается (например, он ушел далеко вперед)
	// возврат в стартовую позицию и отключение, отключение в текущей позиции, уничтожение объекта
	public enum Mode { WaypointsAndDisabled = 0, Disabled = 1, Destroy = 2 };
	public Mode action = Mode.WaypointsAndDisabled;

	public bool facingRight = true; // бот смотрит вправо?

	private int layerMask;
	private bool isTarget, isWait;
	private Rigidbody2D body;
	private Vector3 direction;
	private Vector3 startPosition;
	private float curDist;

	void Awake()
	{
		layerMask = 1 << gameObject.layer | 1 << 2;
		layerMask = ~layerMask;
		body = GetComponent<Rigidbody2D>();
		body.freezeRotation = true;
		startPosition = transform.position;
	}

	void OnCollisionEnter(Collision collision)
	{
		// физический контакт с целью
		Debug.Log(collision.gameObject.name);

	}

	Vector3 SetDirection(float xPos)
	{
		return new Vector3(xPos, transform.position.y, transform.position.z) - transform.position;
	}

	void Walk() // зацикленное движение от А к В и обратно
	{
		float a = Vector3.Distance(transform.position, waypointA.position);
		float b = Vector3.Distance(transform.position, waypointB.position);

		if (a < 1)
		{
			direction = SetDirection(waypointB.position.x);
		}
		else if (b < 1)
		{
			direction = SetDirection(waypointA.position.x);
		}
		else if (body.velocity.x == 0)
		{
			direction = SetDirection(waypointA.position.x);
		}
		else if (curDist > resetDistance)
		{
			Choose();
		}

	}

	void Follow() // преследование игрока
	{
		if (curDist > checkDistance || body.velocity.magnitude == 0 && curDist > searchDistance)
		{
			direction = Vector3.zero;
			body.velocity = Vector3.zero;
			isWait = true;
		}
		else if (curDist > resetDistance)
		{
			Choose();
		}
		else
		{
			direction = SetDirection(GameManager.player.position.x);
		}
	}

	void Wait() // режим ожидания
	{
		if (curDist < searchDistance)
		{
			isWait = false;
		}
		else if (curDist > resetDistance)
		{
			Choose();
		}
	}

	void Choose() // финальное действие
	{
		switch (action)
		{
			case Mode.Disabled:
				isWait = false;
				isTarget = false;
				gameObject.SetActive(false);
				break;

			case Mode.WaypointsAndDisabled:
				transform.position = startPosition;
				isWait = false;
				isTarget = false;
				gameObject.SetActive(false);
				break;

			case Mode.Destroy:
				Destroy(gameObject);
				break;
		}
	}

	void LateUpdate()
	{
		if (!waypointA || !waypointB) return;

		curDist = Vector3.Distance(GameManager.player.position, transform.position);

		if (!isTarget)
		{
			Walk();
		}
		else if (!isWait && isTarget)
		{
			Follow();
		}
		else if (isWait && isTarget)
		{
			Wait();
		}

		if (body.velocity.x > 0 && !facingRight) Flip();
		else if (body.velocity.x < 0 && facingRight) Flip();
	}

	void FixedUpdate()
	{
		body.AddForce(direction.normalized * body.mass * speed * acceleration);

		if (Mathf.Abs(body.velocity.x) > speed)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
		}
	}

	void Flip() // отражение по горизонтали
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void GenerateWaypoints(GameObject point) // вспомогательная функция для создания вейпоинтов
	{
		if (!waypointA && !waypointB)
		{
			GameObject obj = new GameObject(gameObject.name + "_Waypoints");
			obj.transform.position = transform.position;

			GameObject clone = Instantiate(point) as GameObject;
			clone.transform.parent = obj.transform;
			clone.transform.localPosition = new Vector2(3, 0);
			clone.name = "Point_A";
			waypointA = clone.transform;

			clone = Instantiate(point) as GameObject;
			clone.transform.parent = obj.transform;
			clone.transform.localPosition = new Vector2(-3, 0);
			clone.name = "Point_B";
			waypointB = clone.transform;
		}
	}
	/////////////////////////
	

}*/