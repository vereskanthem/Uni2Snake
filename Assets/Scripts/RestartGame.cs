using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartGame : MonoBehaviour
{

    public void Restart()
    {

		FoodGeneration.FoodCount = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

}