using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private Light directionalLight; // Référence à la Directional Light
    [SerializeField]
    private ParticleSystem rainSystem; // Système de particules pour la pluie
    [SerializeField] 
    private float rainChance; // Probabilité qu'il pleuve chaque minute
    
    public float cycleDuration = 120.0f; // Durée du cycle complet jour/nuit en secondes
    private float rotationSpeed; // Vitesse de rotation calculée
    public float startTime = 12.0f; // Heure de départ en heures, où 0 représente minuit
    


    void Start()
    {
        // Vérifier si la lumière est correctement assignée
        if (directionalLight == null)
        {
            Debug.LogError("Directional Light is not assigned in the inspector!");
            return;
        }

        // Calcul de la vitesse de rotation pour compléter un tour en 'cycleDuration' secondes
        rotationSpeed = 360.0f / cycleDuration;

        // Définir la rotation initiale en fonction de l'heure de départ
        float initialRotationX = MapTimeToRotation(startTime);
        directionalLight.transform.eulerAngles = new Vector3(initialRotationX, 0, 0);

        rainSystem.Stop();
        InvokeRepeating("ManageRain", 0, 60.0f); // Vérifie la pluie toutes les minutes

    }

    void Update()
    {
        if (directionalLight != null)
        {
            // Faire tourner la lumière autour de l'axe x à chaque frame
            directionalLight.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        }
    }

    private float MapTimeToRotation(float time)
    {
        // Convertir l'heure en degrés (0 heure = -90 degrés, 12 heures = 90 degrés, 24 heures = -90 degrés)
        return (time * 15.0f) - 90.0f;
    }

    void ManageRain()
    {
        if (Random.Range(0.0f, 1.0f) < rainChance)
        {
            if (!rainSystem.isPlaying)
                rainSystem.Play();
        }
        else
        {
            if (rainSystem.isPlaying)
                rainSystem.Stop();
        }
    }
}
