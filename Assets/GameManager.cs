using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvas;
    public FadeInCanvasGroup canvasTransition;
    public CollisionDetector collisionDetector;
    public GameObject plane;
    void Update()
    {
        if (collisionDetector.Alive == false)
        {
            canvas.SetActive(true);
            canvasTransition.StartFadeIn();
            plane.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
