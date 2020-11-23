using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
	// точки, между которыми бот будет двигаться, в ожидании игрока
	public Transform waypointA;
	public Transform waypointB;
	public Vector2 speed = new Vector2(0.05f, 0.01f); // скорость движения
	private float curdist; //дистанция от игрока до бота
	private bool isTarget;
	private Rigidbody2D rb;
	public Vector2 direction;
	private Vector2 pos;
	private Vector2 endPosition;
	private Vector2 movement;
	public float step = 0.5f;	
	private float progress;
	public Transform player;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		// физический контакт с целью
		Debug.Log(collision.gameObject.name);

	}
    private void Update()
    {
	    float x = pos.x - endPosition.x;
		float y = pos.y - endPosition.y;
		pos = transform.position;
		endPosition = new Vector2(player.transform.position.x + 1f, player.transform.position.y - 0.55f);
		direction = SetDirection(x, y);
		//movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
		transform.position = new Vector2(transform.position.x + speed.x * direction.x, transform.position.y + speed.x * direction.y);
	 //	transform.position = new Vector2(transform.position.x - step, transform.position.y - step);


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
