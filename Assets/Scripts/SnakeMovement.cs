using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour {

    public float speed; //Скорость движения змеи
    public float rotspeed; //Скорость поворота змеи
    public List<GameObject> tailObject = new List<GameObject>(); //Определяем массив для хвостов
    public GameObject tailPrefab1; //Определяем синий хвост как префаб
    public GameObject tailPrefab2; //Определяем зеленый хвост как префаб
    public GameObject tailPrefab3; //Определяем красный хвост как префаб
    public float z_offset = 0.3f; //Отсуп при начальном появлении хвоста
    public Text ScoreText; //Переменная текста счета для UI
    public int score = 0; //Начальное значение счета
    public float timer; //Переменная для времени
    public Text TimeText; //Переменная текста времени для UI

	private List<string> endOfTail = new List<string>();

	void Start () {
        timer = 0; //Устанавливаем таймер в 0
        tailObject.Add(gameObject); 
		FoodGeneration.currentFoodInField = 0; //Стартовое количество еды на поле = 0
		FoodGeneration.FoodCount = 0;
	}
	
	void Update ()
    {
        SetCountText();//Вызываем функцию отображающую счет
        timer = timer + Time.deltaTime; //Отображаем время
        //Красивое оформление времени
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        TimeText.text = "Time: " + niceTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime); //Постоянное движение змеи вперед со скоростью speed

        if(Input.GetKey(KeyCode.D)) 
        {
            transform.Rotate(Vector3.up*rotspeed*Time.deltaTime); //Поворот направо со скоростью rotspeed
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up*-1 * rotspeed * Time.deltaTime); //Поворот налево со скоростью rotspeed
        }
    }

    public void AddTail1() //Функция добавления синего хвоста
    {
        score++; //Увеличиваем счет
        SetCountText();
        Vector3 newTailPos = tailObject[tailObject.Count-1].transform.position; //Определяем позицию хвоста

        newTailPos.z -= z_offset; //Позиция хвоста - на расстоянии z_offset от предыдущего элемента
     
		endOfTail.Add (tailPrefab1.tag); //Даем tag синему хвосту

        tailObject.Add(Instantiate(tailPrefab1, newTailPos, Quaternion.identity) as GameObject); //Добавляем синий хвост как объект на сцену
    }
    public void AddTail2() //Тоже самое для зеленого
    {
        score++;
        SetCountText();
        Vector3 newTailPos = tailObject[tailObject.Count - 1].transform.position;

        newTailPos.z -= z_offset;

		endOfTail.Add (tailPrefab2.tag);

        tailObject.Add(Instantiate(tailPrefab2, newTailPos, Quaternion.identity) as GameObject);
    }
    public void AddTail3() //Тоже самое для синего
    {
        score++;
        SetCountText();
        Vector3 newTailPos = tailObject[tailObject.Count - 1].transform.position;

        newTailPos.z -= z_offset;

		endOfTail.Add (tailPrefab3.tag);

        tailObject.Add(Instantiate(tailPrefab3, newTailPos, Quaternion.identity) as GameObject);
    }

	public bool CheckTail()	{

		//print ("endOfTail = " + endOfTail.Count);

		//if (endOfTail.Count > 3) {

		//print ("endOfTail = " + endOfTail.Count);

		//	endOfTail.RemoveAt(0);

		//}

		print ("tailObject.Count = " + tailObject.Count);

		if (tailObject.Count >= 4) {

			if ((tailObject.ElementAt(tailObject.Count-1).tag == tailObject.ElementAt(tailObject.Count-2).tag) && (tailObject.ElementAt(tailObject.Count-2).tag == tailObject.ElementAt(tailObject.Count-3).tag))	{

				print ("CHECK !!");

				//for (int i = endOfTail.Count-1; i == 0 ; i--) {

				//	endOfTail.RemoveAt (endOfTail.Count-1);

				//}

				//endOfTail.RemoveAt (endOfTail.Count-1);
				//endOfTail.RemoveAt (endOfTail.Count-2);
				//endOfTail.RemoveAt (endOfTail.Count-3);

				return true;

			} else {

				//print ("TailHook is consist of DIFFERENT elements!");

				return false;

			}

		}

		return false;

	}

	public void DestroyTailObjects()	{

		if (CheckTail ()) {

			//print ("Destroing THREE elements for test:");
			print ("TRUE !! tailObject size:  " + tailObject.Count);

			try {

				if(tailObject.Count >= 4)	{

					for(int j = 0; j < 3; j++)	{

						if (tailObject.ElementAt (tailObject.Count - 1) != null) {

							print("Remove obj:" + tailObject.ElementAt(tailObject.Count - 1).tag + " #" + (tailObject.Count - 1)); // tailObject.RemoveAt (3);

							DestroyObject(tailObject.ElementAt (tailObject.Count-1));

							tailObject.RemoveAt(tailObject.Count-1);


						}

					}

					score = score + 10;

					//if (tailObject.ElementAt (tailObject.Count - 2) != null) print("Remove obj:" + tailObject.ElementAt(tailObject.Count - 2).tag + " #" + (tailObject.Count - 2));
					//if (tailObject.ElementAt (tailObject.Count - 3) != null) print("Remove obj:" + tailObject.ElementAt(tailObject.Count - 3).tag + " #" + (tailObject.Count - 3));

				}

			} catch(System.Exception e)	{

				print ("Error in removing objects List!\n" + e);

			}

			print ("tailObject size:  " + tailObject.Count + "; endOfTail size: " + endOfTail.Count);


			//tailObject.Add(gameObject);

		}

	}

    public  void SetCountText()	{
		
        ScoreText.text = "Score: " + score.ToString();

    }

}
