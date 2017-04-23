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
    //public Text TimeText; //Переменная текста времени для UI
    public Text BonusText;//Переменная текста для бонуса
    private int BonusType; //Тип бонуса
    private int multi = 1; //Множитель очков
    private IEnumerator coroutine;

	private int BlueCountForDelete  = 3;
	private int GreenCountForDelete = 3;
	private int RedCountForDelete   = 3;
	private int RedCountForHook     = 3;

	private bool redPlusTrigger;

    //private List<string> endOfTail = new List<string>();
    private string colorOfDestroyingTail;

    void Start() {

        timer = 0; //Устанавливаем таймер в 0
        BonusText.text = " ";
        tailObject.Add(gameObject);
        FoodGeneration.currentFoodInField = 0; //Стартовое количество еды на поле = 0
        FoodGeneration.FoodCount = 0;
	
		BlueCountForDelete  = 3;
		GreenCountForDelete = 3;
		RedCountForDelete   = 3;
		RedCountForHook     = 3;

		redPlusTrigger = false;

    }

    void Update()
    {
        SetCountText();//Вызываем функцию отображающую счет
        //timer = timer + Time.deltaTime; //Отображаем время
        //Красивое оформление времени
        //int minutes = Mathf.FloorToInt(timer / 60F);
        //int seconds = Mathf.FloorToInt(timer - minutes * 60);
        //string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        //TimeText.text = "Time: " + niceTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime); //Постоянное движение змеи вперед со скоростью speed

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotspeed * Time.deltaTime); //Поворот направо со скоростью rotspeed
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -1 * rotspeed * Time.deltaTime); //Поворот налево со скоростью rotspeed
        }
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.up * rotspeed * Time.deltaTime); //Поворот направо со скоростью rotspeed
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.up * -1 * rotspeed * Time.deltaTime); //Поворот налево со скоростью rotspeed
		}
    }

    public void setSpeed(float _speed)
    {

        speed = _speed;

    }

    public void SetCountText()
    {

        ScoreText.text = "Score: " + score.ToString();

    }

    void BlueBonus()
    {
        BonusText.text = "Blue bonus!";
        BonusText.color = Color.blue;
        Time.timeScale = 0.5f;
        coroutine = BonusPause(5.0f);
        StartCoroutine(coroutine);
    }

    void RedBonus()//Красный бонус
    {
        BonusText.text = "Red bonus!";
        BonusText.color = Color.red;
        //multi = 2;
        coroutine = BonusPause(5.0f);
        StartCoroutine(coroutine);
    }

	void RedPlusBonus()//Красный+ бонус
	{
		BonusText.text = "RedPlus bonus!";
		BonusText.color = Color.red;
		coroutine = BonusPause(5.0f);
		StartCoroutine(coroutine);
	}

    void GreenBonus()
    {
        BonusText.text = "Green bonus!";
        BonusText.color = Color.green;
        //Игнорирование препятствий
        coroutine = BonusPause(5.0f);
        StartCoroutine(coroutine);
    }

    private IEnumerator BonusPause(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        multi = 1;
        Time.timeScale = 1;
        BonusText.text = " ";
        BonusText.color = Color.white;
    }

	public void AddTail(string ColorOfFood)		{

		score++;

		SetCountText();

		Vector3 newTailPos = tailObject[tailObject.Count - 1].transform.position;

		newTailPos.z -= z_offset;

		//endOfTail.Add (tailPrefab3.tag);

		if (ColorOfFood == "Blue") {

			tailObject.Add (Instantiate (tailPrefab1, newTailPos, Quaternion.identity) as GameObject);

		}

		if (ColorOfFood == "Green") {

			tailObject.Add (Instantiate (tailPrefab2, newTailPos, Quaternion.identity) as GameObject);

		}

		if (ColorOfFood == "Red") {

			tailObject.Add (Instantiate (tailPrefab3, newTailPos, Quaternion.identity) as GameObject);

		}

	}

	// Метод, который относится только к красному эффекту (RedPlus).
	// Добавляет обратно элементы, которые должны были остаться после уничтожения элеемнтов определенного цвета.
	private IEnumerator AddRemainingTailElements(List<string> massiveOfRemainingElements)	{

		// Сколько у нас в массиве оставшихся элементов? 
		int CountOfRemainingElements = massiveOfRemainingElements.Count;

		print("CountOfRemainingElements: " + CountOfRemainingElements);

		// Проверка на то, что в массиве оставшихся есть хоть что-то
		if(CountOfRemainingElements != 0)	{

			// Добавим в хвост нужные элементы
			for(int j = CountOfRemainingElements-1; j >= 0; j--)	{

				//for(int j = 0; j < CountOfRemainingElements; j++)	{

				//coroutine = CreatePause(5.0f);

				yield return new WaitForSeconds (1.0f);

				// Food1 - Синий цвет, Food2 - Зеленый цвет, Food3 - Красный цвет
				if(massiveOfRemainingElements.ElementAt(j) == "Food1")	{

					print("BLUE" + massiveOfRemainingElements.ElementAt(j));

					Vector3 newTailPos = tailObject[tailObject.Count - 1].transform.position;

					newTailPos.z -= z_offset;

					//endOfTail.Add (tailPrefab3.tag);

					tailObject.Add(Instantiate(tailPrefab1, newTailPos, Quaternion.identity) as GameObject);

				}

				if(massiveOfRemainingElements.ElementAt(j) == "Food2")	{

					print("GREEN" + massiveOfRemainingElements.ElementAt(j));

					Vector3 newTailPos = tailObject[tailObject.Count - 1].transform.position;

					newTailPos.z -= z_offset;

					//endOfTail.Add (tailPrefab3.tag);

					tailObject.Add(Instantiate(tailPrefab2, newTailPos, Quaternion.identity) as GameObject);

				}

				if(massiveOfRemainingElements.ElementAt(j) == "Food3")	{

					print("RED" + massiveOfRemainingElements.ElementAt(j));

					Vector3 newTailPos = tailObject[tailObject.Count - 1].transform.position;

					newTailPos.z -= z_offset;

					//endOfTail.Add (tailPrefab3.tag);

					tailObject.Add(Instantiate(tailPrefab3, newTailPos, Quaternion.identity) as GameObject);

				}

			}

		}

	}

	public string CheckTail()	{

		// print ("tailObject.Count = " + tailObject.Count);

		if (tailObject.Count >= 4) {

			if ((tailObject.ElementAt(tailObject.Count-1).tag == tailObject.ElementAt(tailObject.Count-2).tag) && (tailObject.ElementAt(tailObject.Count-2).tag == tailObject.ElementAt(tailObject.Count-3).tag))	{

				if ((tailObject.ElementAt (tailObject.Count - 1).tag == "Food1") && (tailObject.ElementAt (tailObject.Count - 2).tag == "Food1") && (tailObject.ElementAt (tailObject.Count - 3).tag == "Food1")) {

					return "Blue";

				}

				if ((tailObject.ElementAt (tailObject.Count - 1).tag == "Food2") && (tailObject.ElementAt (tailObject.Count - 2).tag == "Food2") && (tailObject.ElementAt (tailObject.Count - 3).tag == "Food2")) {

					return "Green";

				}

				if ((redPlusTrigger == false) && (tailObject.ElementAt (tailObject.Count - 1).tag == "Food3") && (tailObject.ElementAt (tailObject.Count - 2).tag == "Food3") && (tailObject.ElementAt (tailObject.Count - 3).tag == "Food3")) {
					// Чтобы при наборе большего числа красных элементов не срабатывал постоянно хук на "Red"
					// Ибо нужно чтобы следующим после Red сработал RedPlus
					redPlusTrigger = true;

					return "Red";

				}

			}

			if ((tailObject.Count >= 5) && (redPlusTrigger = true)) {

				if ((tailObject.ElementAt (tailObject.Count - 2).tag == tailObject.ElementAt (tailObject.Count - 3).tag) && (tailObject.ElementAt (tailObject.Count - 3).tag == tailObject.ElementAt (tailObject.Count - 4).tag)) {

					if ((tailObject.ElementAt (tailObject.Count - 2).tag == "Food3") && (tailObject.ElementAt (tailObject.Count - 3).tag == "Food3") && (tailObject.ElementAt (tailObject.Count - 4).tag == "Food3")) {
						// Сбросим хук на Red на false, теперь в него можно войти и метод может вернуть "Red"
						redPlusTrigger = false;

						return "RedPlus";

					}

				}

			}

		}

		return "None";

	}

	public void DeleteEndOfTail(string FoodColor)	{

		string ColorOfLastTailElement;

		try {

			if(tailObject.Count >= 4)	{

				if (tailObject.ElementAt (tailObject.Count - 1) != null) {

					// Food1 - Синий цвет, Food2 - Зеленый цвет, Food3 - Красный цвет
					if(FoodColor == "Blue")	{

						for(int j = 0; j < BlueCountForDelete; j++)	{

							print("Remove obj:" + tailObject.ElementAt(tailObject.Count - 1).tag + " #" + (tailObject.Count - 1)); // tailObject.RemoveAt (3);

							colorOfDestroyingTail = tailObject.ElementAt(tailObject.Count - 1).tag;

							print("Color: " + colorOfDestroyingTail);

							DestroyObject(tailObject.ElementAt (tailObject.Count-1));

							tailObject.RemoveAt(tailObject.Count-1);

						}

						print("Spelling Effect fo BLUE Food!");
						BlueBonus();

						// Здесь можно написать код, который относится к вызову эффекта после удаления синих

					}

					if(FoodColor == "Green")	{

						for(int j = 0; j < GreenCountForDelete; j++)	{

							print("Remove obj:" + tailObject.ElementAt(tailObject.Count - 1).tag + " #" + (tailObject.Count - 1)); // tailObject.RemoveAt (3);

							colorOfDestroyingTail = tailObject.ElementAt(tailObject.Count - 1).tag;

							print("Color: " + colorOfDestroyingTail);

							DestroyObject(tailObject.ElementAt (tailObject.Count-1));

							tailObject.RemoveAt(tailObject.Count-1);

						}
						print("Spelling Effect fo GREEN Food!");
						GreenBonus();

						// Здесь можно написать код, который относится к вызову эффекта после удаления зеленых

					}

					if(FoodColor == "RedPlus")	{

						// Вычисляем какого цвета последний элемент в хвосте и будем удалять только такие же по цвету элементы из хвоста
						ColorOfLastTailElement = tailObject.ElementAt(tailObject.Count - 1).tag;

						// Массив для сохранения тегов элементов, которые должны остаться
						List<string> massiveOfRemainingElements = new List<string>();
						// Счетчик на количество сохраненных элементов
						int SavedCount = 0;
						// Сначала запомним элементы, которые должны остаться
						// j = (tailObject.Count - 5) - чтобы не учитывать красное комбо и последний элемент

						print("tailObject.Count: " + tailObject.Count);
						print("colorOfLastTailElement: " + ColorOfLastTailElement);
						for(int j = (tailObject.Count - 5); j > 0 ; j--)	{

							// Если у нас цвет (тег) не такой же, как цвет (тег цвета) последнего элемента, то сохраним в коллекцию
							if(tailObject.ElementAt(j).tag != ColorOfLastTailElement)	{

								massiveOfRemainingElements.Add(tailObject.ElementAt(j).tag);

								SavedCount += 1;
								print("Saved: " + SavedCount + " :: " + tailObject.ElementAt(j).tag);

							}

						}

						print("massiveOfRemainingElements: " + massiveOfRemainingElements.Count); 
						// Удалим весь хвост
						for(int j = (tailObject.Count - 1); j > 0; j--)	{

							DestroyObject(tailObject.ElementAt (j));

							tailObject.RemoveAt(j);

							print("BANG! - " + (j));

						}

						StartCoroutine(AddRemainingTailElements(massiveOfRemainingElements));

						//for(int k = 1; k < (tailObject.Count - 1); k++)	{

						//	DestroyObject(tailObject.ElementAt (k));

						//}


						// Потом создадим его заново из элементов, которые имеют отличный от последнего элемента в хвосте цвет

					}

					print("Spelling Effect for RED Food (3 red + 1 any color)!");
					RedPlusBonus();
					// Здесь можно написать код, который относится к вызову эффекта после удаления красных

				}

				score = score + 10;

				//if (tailObject.ElementAt (tailObject.Count - 2) != null) print("Remove obj:" + tailObject.ElementAt(tailObject.Count - 2).tag + " #" + (tailObject.Count - 2));
				//if (tailObject.ElementAt (tailObject.Count - 3) != null) print("Remove obj:" + tailObject.ElementAt(tailObject.Count - 3).tag + " #" + (tailObject.Count - 3));

			}

		} catch(System.Exception e)	{

			print ("Error in removing objects List!\n" + e);

		}

	}

	public void DestroyTailObjects()	{
		// Если у нас 3 синих (в конце)
		if (CheckTail () == "Blue") {

			print ("TRUE !! tailObject size:  " + tailObject.Count + " BLUE!");

			DeleteEndOfTail ("Blue");

		}
		// Если у нас 3 зеленых (в конце)
		if (CheckTail () == "Green") {

			print ("TRUE !! tailObject size:  " + tailObject.Count + " Green!");

			DeleteEndOfTail ("Green");

		}
		// Если у нас 3 красных (в конце)
		if (CheckTail () == "Red") {

			print ("Red Animation! ");

			// Здесь нужно вставить анимацию (горение последних трех красных)

			//			DeleteEndOfTail ("Red");

		}
		// Если у нас 3 красных + 1 рандом после (в конце)
		if (CheckTail () == "RedPlus") {

			print ("TRUE !! tailObject size:  " + tailObject.Count + " Red!");

			DeleteEndOfTail ("RedPlus");

		}

	}

    private IEnumerator TailDestruction(float waitTime)
	{
    	yield return new WaitForSeconds(waitTime);
        DestroyObject(tailObject.ElementAt(tailObject.Count - 1));
        tailObject.RemoveAt(tailObject.Count - 1);  
		BlueBonus ();
		score = score + (10*multi);
		//if (tailObject.ElementAt (tailObject.Count - 2) != null) print("Remove obj:" + tailObject.ElementAt(tailObject.Count - 2).tag + " #" + (tailObject.Count - 2));
		//if (tailObject.ElementAt (tailObject.Count - 3) != null) print("Remove obj:" + tailObject.ElementAt(tailObject.Count - 3).tag + " #" + (tailObject.Count - 3));

	}

} 

