using UnityEngine;
using System.Collections;

public class FoodGreen : MonoBehaviour
{
    //Комментарии аналогичны FoodBlue
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("SnakeMain"))
        {
			collider.GetComponent<SnakeMovement>().AddTail("Green");
			collider.GetComponent<SnakeMovement>().DestroyTailObjects();
            Destroy(gameObject);

			FoodGeneration.currentFoodInField -= 1;
			FoodGeneration.FoodCount += 1;

			print (FoodGeneration.FoodCount);
        }
    }
}
