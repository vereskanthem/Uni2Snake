using UnityEngine;
using System.Collections;

public class FoodBlue : MonoBehaviour
{

    void OnTriggerEnter(Collider collider) //Событие срабатывает при столкновении с триггером
    {
        if (collider.CompareTag("SnakeMain")) //Сравнивает с объектом с тегом "SnakeMain"
        {
            collider.GetComponent<SnakeMovement>().AddTail1(); //Добавляет синий хвост, вызывая функцию AddTail1
			collider.GetComponent<SnakeMovement>().DestroyTailObjects(); //Вызывает функцию уничтожения 3-х одинаковых блоков
            Destroy(gameObject); //Убирает еду с поля
			FoodGeneration.currentFoodInField -= 1; //Уменьшает счетчик текущего количества еды на поле
        }
    }
}
