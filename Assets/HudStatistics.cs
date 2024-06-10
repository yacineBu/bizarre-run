using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudStatistics : MonoBehaviour
{
    public GameObject plane;
    public TMP_Text altitude;
    public Transform target; // L'objet dont la rotation est utilisée comme référence pour la boussole
    public TMP_Text directionText; // Texte affichant la direction actuelle
    public TextMeshProUGUI timerText;
    public TMP_Text pieces; // Texte affichant la direction actuelle
    public TMP_Text tours; // Texte affichant la direction actuelle
    public ScoreManager scoreManager;
    private float elapsedTime = 0f;
    private bool isTimerRunning = false;
    public int tour = 0; // Variable pour suivre les tours

    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();

            // Vérifie si 30 secondes se sont écoulées
            if (elapsedTime >= 30 * (tour + 1))
            {
                tour++;
                Debug.Log("Tour: " + tour); // Affiche le nombre de tours dans la console
            }
        }
        tours.text = "Tour : " + tour.ToString();
        altitude.text = ((int)plane.transform.position.y).ToString() + " m";
        pieces.text = scoreManager.Score.ToString();

        // Vérifie si la cible est définie
        if (target != null)
        {
            // Récupère la rotation en radians sur l'axe Y de la cible
            float angle = target.eulerAngles.y;

            // Convertit l'angle en degrés en une direction
            string direction = "";

            if (angle >= 315 || angle < 45)
                direction = "Nord";
            else if (angle >= 45 && angle < 135)
                direction = "Est";
            else if (angle >= 135 && angle < 225)
                direction = "Sud";
            else if (angle >= 225 && angle < 315)
                direction = "Ouest";

            // Affiche la direction dans le texte
            directionText.text = direction;
        }
    }

    void StartTimer()
    {
        elapsedTime = 0f;
        isTimerRunning = true;
        tour = 0; // Réinitialise le compteur de tours au début
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }
}
