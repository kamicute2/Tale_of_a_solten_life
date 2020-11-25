using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
	public int points = 0;
	float xRight, y, xLeft, distanceRight, distanceLeft;
	public bool isLeft = false, isRight = false, isAttacking;
	// точки, между которыми бот будет двигаться, в ожидании игрока
	public Transform waypointA;
	public Transform waypointB;
	public Vector2 speed = new Vector2(2f, 1f); // скорость движения
	private float curdist; //дистанция от игрока до бота
	private bool isTarget;
	private Rigidbody2D rb;
	public Vector2 direction;
	private Vector2 pos;
	private Vector2 endPositionRight;
	private Vector2 endPositionLeft;
	private float progress;
	public Transform player_info;
	private GameObject player;
	public Animator animator;
	private Collider2D coll;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		player = GameObject.FindGameObjectWithTag("Player");
		animator = GetComponent<Animator>();
		coll = GetComponent<Collider2D>();
		coll.isTrigger = true;
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		// физический контакт с целью
		Debug.Log(collision.gameObject.name);

	}
    private void Update()
    {
		//Debug.Log(gameObject.name + ' ' + isLeft);
		//Debug.Log(isRight);
		pos = transform.position;
		endPositionRight = new Vector2(player_info.transform.position.x + 1f, player_info.transform.position.y);
		endPositionLeft = new Vector2(player_info.transform.position.x + -1f, player_info.transform.position.y);
		xRight = pos.x - endPositionRight.x;
		xLeft = pos.x - endPositionLeft.x;
		y = pos.y - endPositionRight.y;
		if (isLeft)
        {
			if (points == 0)
				points += 1;
			if (player.GetComponent<Enemy_Target>().isLeft)
				player.GetComponent<Enemy_Target>().isLeft = false;
			if (!isAttacking)
			{
				direction = SetDirection(xLeft, y);
				transform.position = new Vector2(transform.position.x + speed.x * direction.x * Time.deltaTime, transform.position.y + speed.y * direction.y * Time.deltaTime);
			}
        }
		if (isRight)
		{
			if (points == 0)
				points += 1;
			if (player.GetComponent<Enemy_Target>().isRight)
				player.GetComponent<Enemy_Target>().isRight = false;
			if (!isAttacking)
			{
				direction = SetDirection(xRight, y);
				transform.position = new Vector2(transform.position.x + speed.x * direction.x * Time.deltaTime, transform.position.y + speed.y * direction.y * Time.deltaTime);
			}
		}
		if (direction.x == -1)
		{
			transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
			//animator.Play("Enemy_run");
		}
		if (direction.x == 1)
		{
			transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			//animator.Play("Enemy_run");
		}



	}
	Vector2 SetDirection(float x, float y)
	{
		if (x > 0.1 && y > 0.1)
			return new Vector2(-1, -1);
		else if (x < -0.1 && y < -0.1)
			return new Vector2(1, 1);
		else if (x < -0.1 && y > 0.1)
			return new Vector2(1, -1);
		else if (x > 0.1 && y < -0.1)
			return new Vector2(-1, 1);
		else if (x > 0.1 && y < 0.1 && y > -0.1)
			return new Vector2(-1, 0);
		else if (x < -0.1 && y < 0.1 && y > -0.1)
			return new Vector2(1, 0);
		else if (x > -0.1 && x < 0.1 && y > 0.1)
			return new Vector2(0, -1);
		else if (x > -0.1 && x < 0.1 && y < -0.1)
			return new Vector2(0, 1);
		else 
			return new Vector2(0, 0);

	}
	/*void Run()
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

	}*/
    public void Move()
    {
        
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
	
}
