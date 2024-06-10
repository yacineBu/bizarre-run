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
    public bool alive;

    private void Start()
    {
        alive = true;
    }
    void Update()
    {
        if (collisionDetector.Alive == false)
        {
            alive = false;
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
