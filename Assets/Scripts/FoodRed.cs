using UnityEngine;
using System.Collections;

public class FoodRed : MonoBehaviour
{
    //Комментарии аналогичны FoodBlue
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("SnakeMain"))
        {
            collider.GetComponent<SnakeMovement>().AddTail3();
			collider.GetComponent<SnakeMovement>().DestroyTailObjects();
            Destroy(gameObject);
			FoodGeneration.currentFoodInField -= 1;

        }
    }
}