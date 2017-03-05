using UnityEngine;
using System.Collections;

public class FoodGeneration : MonoBehaviour
{

    public float XSize = 2.0f;
    public float ZSize = 2.0f;
    public GameObject food1Prefab;
    public GameObject food2Prefab;
    public GameObject food3Prefab;
    public static GameObject curFood1;
    public static GameObject curFood2;
    public static GameObject curFood3;
    public Vector3 curPos1;
    public int FoodType;
	public int FoodCount = 0;
	public int maxFoodInField = 1;
	public static int currentFoodInField = 0;

    void AddNewFood1()
    {
        RandomType();
        if (FoodType == 1)
        {
            RandomPos();
            curFood1 = GameObject.Instantiate(food1Prefab, curPos1, Quaternion.identity) as GameObject;
			FoodCount++;
			//curFood1.tag = "blueObj";
        }
        if (FoodType == 2)
        {
            RandomPos();
            curFood2 = GameObject.Instantiate(food2Prefab, curPos1, Quaternion.identity) as GameObject;
			FoodCount++;
			//curFood2.tag = "greenObj";
        }
        if (FoodType == 3)
        {
            RandomPos();
            curFood3 = GameObject.Instantiate(food3Prefab, curPos1, Quaternion.identity) as GameObject;
			FoodCount++;
			//curFood3.tag = "redObj";
        }
			
    }

    void RandomPos()
    {
        curPos1 = new Vector3(Random.Range(XSize * -1, XSize), 0.25f, Random.Range(ZSize * -1, ZSize));
    }

    void RandomType()
    {
        FoodType = Random.Range(1, 4);
    }
    void Update()
    {

		//print ("Food Count: " + FoodCount);

		if (FoodCount < 5) {

			maxFoodInField = 1;

			if (!curFood1 && !curFood2 && !curFood3) {
				
				AddNewFood1 ();
				currentFoodInField += 1;
				print ("Food In Field: " + currentFoodInField);

			}
		}

		if (FoodCount >= 5) {

			maxFoodInField = 2;

			if (!curFood1 && !curFood2 && !curFood3) {

				if (currentFoodInField == 0) {
					
					for (int i = 0; i < maxFoodInField; i++) {

						AddNewFood1 ();
						currentFoodInField += 1;
						print ("Food In Field: " + currentFoodInField);

					}

				}

			}

			if (((!curFood1 && !curFood2) || (!curFood2 && !curFood3) || (!curFood1 && !curFood3))) {

				if (currentFoodInField < maxFoodInField) {
					
					AddNewFood1 ();
					currentFoodInField += 1;
					print ("Food In Filed: " + currentFoodInField);

				}

			}

		}

		if (FoodCount >= 10) {

			maxFoodInField = 3;

			if (!curFood1 && !curFood2 && !curFood3) {

				if (currentFoodInField == 0) {

					for (int i = 0; i < maxFoodInField; i++) {

						AddNewFood1 ();
						currentFoodInField += 1;
						print ("Food In Field: " + currentFoodInField);

					}

				}

			}

			if (((!curFood1 && !curFood2) || (!curFood2 && !curFood3) || (!curFood1 && !curFood3))) {

				if (currentFoodInField < maxFoodInField) {

					AddNewFood1 ();
					currentFoodInField += 1;
					print ("Food In Filed: " + currentFoodInField);

				}

			}

		}
    }

}