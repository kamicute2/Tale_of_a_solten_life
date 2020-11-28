using UnityEngine;
using System.Collections;

public class EnemyAI: MonoBehaviour
{
	public int points = 0;
	float xRight, y, xLeft, distanceRight, distanceLeft;
	public float xPoint, yPoint;
	public bool isLeft = false, isRight = false;
	public bool isPoint = false;
	public bool isAttacking, isAttack = true;
	public bool rand = true; 
	// точки, между которыми бот будет двигаться, в ожидании игрока
	public Transform waypointA;
	public Transform waypointB;
	public Vector2 speed = new Vector2(2f, 1f); // скорость движения
	private bool isTarget;
	private Rigidbody2D rb;
	public Vector2 direction;
	private Vector2 pos;
	private Vector2 endPositionRight;
	private Vector2 endPositionLeft;
	private float progress;
	private int targetPoint;
	public Transform pointBound;
	public Transform player_info;
	private Transform mainCamera;
	private GameObject player;
	public Animator animator;
	private Collider2D coll;
	public GameObject attackHitBox;
	private Vector2 targetPointMain;
	int a;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		player = GameObject.FindGameObjectWithTag("Player");
		player_info = player.GetComponent<Transform>();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		animator = GetComponent<Animator>();
		coll = GetComponent<Collider2D>();
		coll.isTrigger = true;
		attackHitBox = gameObject.transform.GetChild(0).gameObject;
		attackHitBox.SetActive(false);
		isAttack = true;

	}
    private void Update()
    {
		player_info = player.GetComponent<Transform>();
		pos = transform.position;
		//Мы вычитаем из позиции объекта позицию игрока, и по ней определяем вектор направления движения
		endPositionRight = new Vector2(player_info.transform.position.x + 1f, player_info.transform.position.y);
		endPositionLeft = new Vector2(player_info.transform.position.x + -1f, player_info.transform.position.y);
		xRight = pos.x - endPositionRight.x;
		xLeft = pos.x - endPositionLeft.x;
		y = pos.y - endPositionRight.y;
		//Атака
        if (isAttacking)
        {
			if (player_info.position.x - pos.x < 0)
				transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
			if (player_info.position.x - pos.x > 0)
				transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			if (isAttack)
				StartCoroutine(DoAttack());
		}

		//Тут нерабочий ИИ, трогай, только аккуратно!


		/*
		if (!isAttacking && !isLeft && !isRight && isPoint)
        {
			 targetPoint = SetPoint(mainCamera.position.x - player_info.position.x, mainCamera.position.y - player_info.position.y);
			if (rand)
            {
				if (targetPoint == 0)
					targetPointMain = GameObject.Find("Player_Obj_7").transform.position;
				else if (targetPoint == 1)
					targetPointMain = GameObject.Find("Player_Obj_3").transform.position;
				else if (targetPoint == 2)
                {
					a = Random.Range(0, 10);
					if (a < 5)
						targetPointMain = GameObject.Find("Player_Obj_7").transform.position;
					else
						targetPointMain = GameObject.Find("Player_Obj_3").transform.position;
				}
				/*
				 * if (targetPoint == 0)
					targetPointMain = GameObject.Find("Player_Obj_7").transform.position;
				else if (targetPoint == 1)
					targetPointMain = GameObject.Find("Player_Obj_7").transform.position;
				else if (targetPoint == 2)
					targetPointMain = GameObject.Find("Player_Obj_7").transform.position;
				else if (targetPoint == 3)
					targetPointMain = GameObject.Find("Player_Obj_3").transform.position;
				else if (targetPoint == 4)
					targetPointMain = GameObject.Find("Player_Obj_3").transform.position;
				else if (targetPoint == 5)
					targetPointMain = GameObject.Find("Player_Obj_3").transform.position;
				else if (targetPoint == 6)
					targetPointMain = GameObject.Find("Player_Obj_1").transform.position;
				else if (targetPoint == 7)
					targetPointMain = GameObject.Find("Player_Obj_5").transform.position;
				else if (targetPoint == 8)
					targetPointMain = GameObject.Find("Player_Obj_5").transform.position;
				
				xPoint = targetPointMain.x;
				yPoint = targetPointMain.y + Random.Range(-1.4f, 1.4f);
				rand = false;
			}
			if (targetPoint > -1 && pos.y - yPoint >= -0.51f) 
				direction = SetDirection(pos.x - xPoint, pos.y - yPoint);
			else
				direction = new Vector2(0, 0);
			if (Vector2.Distance(pos, new Vector2(xPoint, yPoint)) < 0.1)
			{
				animator.Play("Enemy_Idle");
				StartCoroutine(DoWait());
			}
			else
			{
				if (direction.x == -1)
				{
					transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
					animator.Play("Enemy_Run");
				}
				if (direction.x == 1)
				{
					transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
					animator.Play("Enemy_Run");
				}
				if (direction.x == 1 && direction.y == 0)
				{ 
					
				}
				transform.position = new Vector2(transform.position.x + speed.x * direction.x * Time.deltaTime, transform.position.y + speed.y * direction.y * Time.deltaTime);
			}
				
			
			
		}*/
	}
    private void FixedUpdate()
    {
		if (isPoint)
		{
			//Правая позиция
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
				if (Mathf.Abs(xRight) <= 0.3f && Mathf.Abs(y) <= 0.2f)
				{
					isAttacking = true;
				}
			}
			//Левая позиция
			else if (isLeft)
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
				if (Mathf.Abs(xLeft) <= 0.3f && Mathf.Abs(y) <= 0.2f)
                {
					isAttacking = true;
				}
			}
			//Направление следования
			if (!isAttacking && direction.x == -1 && (direction.y >= -1 || direction.y <= 1))
			{
				transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
				animator.Play("Enemy_Run");
			}
			if (!isAttacking && direction.x == 1 && (direction.y >= -1 || direction.y <= 1))
			{
				transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				animator.Play("Enemy_Run");
			}
			if (!isAttacking && direction.x == 0 && direction.y == 0)
            {
				animator.Play("Enemy_Idle");
			}
		}
		else
		{
			
			//Передвежение до обязательной точки
			direction = SetDirection(pos.x - pointBound.position.x, pos.y - pointBound.position.y);
			if (direction.x == -1)
			{
				transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
				animator.Play("Enemy_Run");
			}
			if (direction.x == 1)
			{
				transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				animator.Play("Enemy_Run");
			}
			if (direction.x == 0 && direction.y == 0)
            {
				animator.Play("Enemy_Idle");
			}
				transform.position = new Vector2(transform.position.x + speed.x * direction.x * Time.deltaTime, transform.position.y + speed.y * direction.y * Time.deltaTime);
			//Функция делает примерное сравнение
			if (Mathf.Abs(pos.x - pointBound.position.x) < 0.2f && Mathf.Abs(pos.y - pointBound.position.y) < 0.2f)
			{
				isPoint = true;
			}
		}
	}
    Vector2 SetDirection(float x, float y)
	{
		if (x > 0.2 && y > 0.2)
			return new Vector2(-1, -1);
		else if (x < -0.2 && y < -0.2)
			return new Vector2(1, 1);
		else if (x < -0.2 && y > 0.2)
			return new Vector2(1, -1);
		else if (x > 0.2 && y < -0.2)
			return new Vector2(-1, 1);
		else if (x > 0.2 && y < 0.2 && y > -0.2)
			return new Vector2(-1, 0);
		else if (x < -0.2 && y < 0.2 && y > -0.2)
			return new Vector2(1, 0);
		else if (x > -0.2 && x < 0.2 && y > 0.2)
			return new Vector2(0, -1);
		else if (x > -0.2 && x < 0.2 && y < -0.2)
			return new Vector2(0, 1);
		else 
			return new Vector2(0, 0);

	}
    
	IEnumerator DoWait()
    {
		yield return new WaitForSeconds(4f);
		rand = true;
	}
	IEnumerator DoAttack()
	{
		isAttack = false;
		animator.Play("Enemy_Beat");
		attackHitBox.SetActive(true);
		yield return new WaitForSeconds(0.23f);
		StartCoroutine(DoReturnIsAttack());
		attackHitBox.SetActive(false);
		animator.Play("Enemy_Idle");	
	}
	IEnumerator DoReturnIsAttack()
    {
		yield return new WaitForSeconds(0.23f);
		isAttack = true;
		isAttacking = false;
	}
	//Короче эту функцию пока юзать опасно, она должна выбирать объект, на который будет тригерриться враг, но все идет так, как в принципе все может идти в России
	int SetPoint(float playerX, float playerY)
    {
		//mainCamera.position.y - player_info.position.y
		GameObject[] masMas = GameObject.FindGameObjectsWithTag("Place");
		if (playerX <= -2.6f)
        {
			return 0;
			/*if (playerY + 1.66f >= 3f && playerY + 1.66f <= 2.61f)
            {
				return 0;
				//правый низ
            }
			else if (playerY + 1.66f >= 1.83f && playerY + 1.66f <= 1.14f)
			{
				return 1;
				//правый верх
			}
			else
			{
				return 2;
				//правый центр
			}*/

		}
		else if (playerX >= 2.3f)
		{
			return 1;
			/*if (playerY + 1.66f >= 3f && playerY + 1.66f <= 2.61f)
            {
				return 3;
				//левый низ
			}
			else if (playerY + 1.66f >= 1.83f && playerY + 1.66f <= 1.14f)
			{
				return 4;
				//левый верх
			}
			else 
			{
				return 5;
				//левый центр
			}*/
		}
		else
		{
			return 2;
			/*if (playerY + 1.66f >= 3f && playerY + 1.66f <= 2.61f)
            {
				return 6;
				//низ
			}
			else if (playerY + 1.66f >= 1.83f && playerY + 1.66f <= 1.14f)
			{
				return 7;
				//верх
			}
			else
			{
				return 8;
				//центр
			}*/
		}
    }
}
