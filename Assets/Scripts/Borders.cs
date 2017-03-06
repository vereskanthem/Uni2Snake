using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Borders : MonoBehaviour {

    void OnTriggerEnter(Collider other) //Событие срабатывает при столкновении с триггером
    {
        if (other.CompareTag("SnakeMain")) //Сравнивает с объектом с тегом "SnakeMain"
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //Перезапуск уровня
        }
    }
}
