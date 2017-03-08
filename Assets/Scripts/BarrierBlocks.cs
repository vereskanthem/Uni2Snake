using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BarrierBlocks : MonoBehaviour {

	void OnTriggerStay(Collider other) //Событие срабатывает при столкновении с триггером
	{


//		print ("Enter Collider BarrierBlocks");

		//FoodGeneration FoodGenerator = new FoodGeneration ();

		if (other.CompareTag ("SnakeMain")) { //Сравнивает с объектом с тегом "SnakeMain"

			SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //Перезапуск уровня

		}


		if (other.CompareTag("Food1")) //Сравнивает с объектом с тегом "Food1"
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //Перезапуск уровня

			//print ("Food1 BARRIER IS WORKS !!");

			//SnakeMovement.score = 0;

			if (FoodGeneration.currentFoodInField > 0) {

				DestroyObject (FoodGeneration.curFood1);
				FoodGeneration.currentFoodInField -= 1;

			}

			//if(FoodGeneration.FoodCount > 0) FoodGeneration.FoodCount -= 1;

			//FoodGenerator.AddNewFood1();


		}
			
		if (other.CompareTag("Food2")) //Сравнивает с объектом с тегом "Food2"
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //Перезапуск уровня

//			print ("Food2 BARRIER IS WORKS !!");

			if (FoodGeneration.currentFoodInField > 0) {

				DestroyObject (FoodGeneration.curFood2);
				FoodGeneration.currentFoodInField -= 1;

			}

//			if(FoodGeneration.FoodCount > 0) FoodGeneration.FoodCount -= 1;

			//FoodGenerator.AddNewFood1 ();

		}

		if (other.CompareTag("Food3")) //Сравнивает с объектом с тегом "Food3"
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //Перезапуск уровня

			//print ("Food3 BARRIER IS WORKS !!");


			if (FoodGeneration.currentFoodInField > 0) {
				
				DestroyObject (FoodGeneration.curFood3);
				FoodGeneration.currentFoodInField -= 1;

			}

			//if(FoodGeneration.FoodCount > 0) FoodGeneration.FoodCount -= 1;

			//FoodGenerator.AddNewFood1 ();

		}

	}
}
