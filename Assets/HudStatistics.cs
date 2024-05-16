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
    private float elapsedTime = 0f;
    private bool isTimerRunning = false;

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
        }
        altitude.text = ((int)plane.transform.position.y).ToString() + " m";

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
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }
}
