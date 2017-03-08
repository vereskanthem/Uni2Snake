using UnityEngine;
using System.Collections;

public class FoodGeneration : MonoBehaviour
{

    public float XSize = 7f; //Размер поля по X
    public float ZSize = 7f; //Размер поля по Z
    public GameObject food1Prefab; //Задаем префаб синей еды как GameObject
    public GameObject food2Prefab; //Задаем префаб зеленой еды как GameObject
    public GameObject food3Prefab; //Задаем префаб красной еды как GameObject
    public static GameObject curFood1; //Переменная для появившейся на поле синей еды
    public static GameObject curFood2; //Переменная для появившейся на поле зеленой еды
    public static GameObject curFood3; //Переменная для появившейся на поле красной еды
    public Vector3 curPos1; //Коордианат появления еды
    public static int FoodType; //Переменная, определяющая тип еды
	public static uint FoodCount = 0; //Общее количество съеденной еды
	public static int maxFoodInField = 1; //Максимальное количество еды на поле
	public static uint currentFoodInField = 0; //Текущее количество еды на поле

	public void AddNewFood1() //Функция добавления еды
    {
        RandomType(); //Вызов функции определния типа еды
        if (FoodType == 1)
        {
            RandomPos(); //Вызов функции случайной координаты появления еды
           
			//if()	{

				curFood1 = GameObject.Instantiate(food1Prefab, curPos1, Quaternion.identity) as GameObject; //Создаем синюю еду на поле
				//curFoodTrigger = true;

			//}	else {



			//}

			//FoodCount++; //Увеличиваем счетчик подобранной еды на 1
        }
        if (FoodType == 2) //Аналогично прдедущему
        {
            RandomPos();
            curFood2 = GameObject.Instantiate(food2Prefab, curPos1, Quaternion.identity) as GameObject;
			//FoodCount++;
        }
        if (FoodType == 3)
        {
            RandomPos();
            curFood3 = GameObject.Instantiate(food3Prefab, curPos1, Quaternion.identity) as GameObject;
			//FoodCount++;
        }
			
    }

    public void RandomPos() //Функция определения случайной координаты
    {
        curPos1 = new Vector3(Random.Range(XSize * -1, XSize), 0.25f, Random.Range(ZSize * -1, ZSize));
    }

	public void RandomType() //Функция выбора цвета еды
    {
        FoodType = Random.Range(1, 4); //Случайное значение от 1 до 3
    }
    void Update()
    {
        //Функция увеличения количества еды
		if (FoodCount < 5) {

			maxFoodInField = 1; //Максимальное количество еды до 5 собранных = 1

			if (currentFoodInField == 0) {
				
				AddNewFood1 ();
				currentFoodInField += 1;
		

			}
	
		}

		if ((FoodCount >= 5) && (FoodCount < 15)) { //Максимальное количество еды после 5 собранных = 2

			maxFoodInField = 2;

			if (currentFoodInField < maxFoodInField) { //Спауним пока не превысит максимальное количество
					
					AddNewFood1 ();
					currentFoodInField += 1;

				}


		}

		if (FoodCount >= 15) { //Более 15 съеденной еды - спауним по 3

			maxFoodInField = 3;

				if (currentFoodInField < maxFoodInField) {

					AddNewFood1 ();
					currentFoodInField += 1;


				}

		}
    }
}