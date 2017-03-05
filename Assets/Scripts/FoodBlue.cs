using UnityEngine;
using System.Collections;

public class FoodBlue : MonoBehaviour
{
	
	IEnumerator Waiting (float secWait)
	{

		yield return new WaitForSeconds (secWait);

	}

	public IEnumerator Update()	{

		yield return StartCoroutine(Waiting (5));

	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("SnakeMain"))
        {
            collider.GetComponent<SnakeMovement>().AddTail1();

			Update ();

			collider.GetComponent<SnakeMovement>().DestroyTailObjects();

            Destroy(gameObject);

			FoodGeneration.currentFoodInField -= 1;
        }
    }
}
