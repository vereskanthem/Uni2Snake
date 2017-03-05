using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour {

    public float speed;
    public float rotspeed;
    public List<GameObject> tailObject = new List<GameObject>();
    public GameObject tailPrefab1;
    public GameObject tailPrefab2;
    public GameObject tailPrefab3;
    public float z_offset = 0.3f;
    public Text ScoreText;
    public int score = 0;
    public float timer;
    public Text TimeText;

	private List<string> endOfTail = new List<string>();

	// Use this for initialization
	void Start () {
        timer = 0;
        tailObject.Add(gameObject);
		FoodGeneration.currentFoodInField = 0;
	}
	
	void Update ()
    {
        SetCountText();

        timer = timer + Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        TimeText.text = "Время: " + niceTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up*rotspeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up*-1 * rotspeed * Time.deltaTime);
        }
    }

    public void AddTail1()
    {
        score++;
        SetCountText();
        Vector3 newTailPos = tailObject[tailObject.Count-1].transform.position;

        newTailPos.z -= z_offset;

		print ("Added BLUE: " + tailPrefab1.tag);

		endOfTail.Add (tailPrefab1.tag);

        tailObject.Add(Instantiate(tailPrefab1, newTailPos, Quaternion.identity) as GameObject);
    }
    public void AddTail2()
    {
        score++;
        SetCountText();
        Vector3 newTailPos = tailObject[tailObject.Count - 1].transform.position;

        newTailPos.z -= z_offset;

		print ("Added GREEN: " + tailPrefab2.tag);

		endOfTail.Add (tailPrefab2.tag);

        tailObject.Add(Instantiate(tailPrefab2, newTailPos, Quaternion.identity) as GameObject);
    }
    public void AddTail3()
    {
        score++;
        SetCountText();
        Vector3 newTailPos = tailObject[tailObject.Count - 1].transform.position;

        newTailPos.z -= z_offset;

		print ("Added RED: " + tailPrefab3.tag);

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
		
        ScoreText.text = "Счет: " + score.ToString();

    }

}
