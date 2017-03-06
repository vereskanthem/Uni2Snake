using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TailMovement : MonoBehaviour {

    public float speed; //Скорость движения хвоста
    public Vector3 tailTarget; //Позиция объекта за которым следует хвост
    public int indx; 
    public GameObject tailTargetObj; 
    public SnakeMovement mainSnake;
    void Start ()
    {
        mainSnake = GameObject.FindGameObjectWithTag("SnakeMain").GetComponent<SnakeMovement>();
        speed = mainSnake.speed+0.5f;
        tailTargetObj = mainSnake.tailObject[mainSnake.tailObject.Count-2];
        indx = mainSnake.tailObject.IndexOf(gameObject);
    }

	void Update () {
        tailTarget = tailTargetObj.transform.position;
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * speed);
	
	}
    void OnTriggerEnter(Collider other) //При столкновении хвоста с головой когда более 2х хвостовых блоков - перезапускать уровень
    {
        if(other.CompareTag("SnakeMain"))
        {
            if(indx>2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //Перезапуск уровня
            }
        }
    }
}
