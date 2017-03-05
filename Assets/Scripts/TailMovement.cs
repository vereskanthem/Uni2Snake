using UnityEngine;
using System.Collections;

public class TailMovement : MonoBehaviour {

    public float speed;
    public Vector3 tailTarget;
    public int indx;
    public GameObject tailTargetObj;
    public SnakeMovement mainSnake;
    void Start ()
    {
        mainSnake = GameObject.FindGameObjectWithTag("SnakeMain").GetComponent<SnakeMovement>();
        speed = mainSnake.speed+0.001f;
        tailTargetObj = mainSnake.tailObject[mainSnake.tailObject.Count-2];
        indx = mainSnake.tailObject.IndexOf(gameObject);
    }

	void Update () {
        tailTarget = tailTargetObj.transform.position;
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * speed);
	
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SnakeMain"))
        {
            if(indx>2)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
