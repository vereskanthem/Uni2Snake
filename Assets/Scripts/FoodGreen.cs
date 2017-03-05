using UnityEngine;
using System.Collections;

public class FoodGreen : MonoBehaviour
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
            collider.GetComponent<SnakeMovement>().AddTail2();

			Update ();

			//yield return StartCoroutine(Waiting (5.0f));

			collider.GetComponent<SnakeMovement>().DestroyTailObjects();

            Destroy(gameObject);
			FoodGeneration.currentFoodInField -= 1;
        }
    }
}
