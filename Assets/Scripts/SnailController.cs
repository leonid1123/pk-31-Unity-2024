using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform boundaryLeft; // Левый предел
    public Transform boundaryRight; // Правый предел
    public float speed = 2f; // Скорость движения
    private bool movingRight = false; // Направление движения
    private Rigidbody2D rb2d; // Компонент Rigidbody2D
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = Vector2.zero; // Вектор движения

        if (movingRight)
        {
            movement = Vector2.right * speed; // Движение вправо

            // Проверка на достижение правой границы
            if (transform.position.x >= boundaryRight.position.x)
            {
                movingRight = false; // Меняем направление
                Flip();
            }
        }
        else
        {
            movement = Vector2.left * speed; // Движение влево

            // Проверка на достижение левой границы
            if (transform.position.x <= boundaryLeft.position.x)
            {
                movingRight = true; // Меняем направление
                Flip();
            }
        }

        // Применяем движение к Rigidbody2D
        rb2d.velocity = new Vector2(movement.x, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Обработка столкновений, если необходимо
        if (collision.gameObject.CompareTag("Player"))
        {
            // Логика столкновения с игроком
            Debug.Log("Враг столкнулся с игроком!");
        }
    }

    private void Flip()
    {
        
        transform.Rotate(0, 180, 0);
    }
}