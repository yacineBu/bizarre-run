using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private Light directionalLight; // R�f�rence � la Directional Light
    [SerializeField]
    private ParticleSystem rainSystem; // Syst�me de particules pour la pluie
    [SerializeField] 
    private float rainChance; // Probabilit� qu'il pleuve chaque minute
    
    public float cycleDuration = 120.0f; // Dur�e du cycle complet jour/nuit en secondes
    private float rotationSpeed; // Vitesse de rotation calcul�e
    public float startTime = 12.0f; // Heure de d�part en heures, o� 0 repr�sente minuit
    


    void Start()
    {
        // V�rifier si la lumi�re est correctement assign�e
        if (directionalLight == null)
        {
            Debug.LogError("Directional Light is not assigned in the inspector!");
            return;
        }

        // Calcul de la vitesse de rotation pour compl�ter un tour en 'cycleDuration' secondes
        rotationSpeed = 360.0f / cycleDuration;

        // D�finir la rotation initiale en fonction de l'heure de d�part
        float initialRotationX = MapTimeToRotation(startTime);
        directionalLight.transform.eulerAngles = new Vector3(initialRotationX, 0, 0);

        rainSystem.Stop();
        InvokeRepeating("ManageRain", 0, 60.0f); // V�rifie la pluie toutes les minutes

    }

    void Update()
    {
        if (directionalLight != null)
        {
            // Faire tourner la lumi�re autour de l'axe x � chaque frame
            directionalLight.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        }
    }

    private float MapTimeToRotation(float time)
    {
        // Convertir l'heure en degr�s (0 heure = -90 degr�s, 12 heures = 90 degr�s, 24 heures = -90 degr�s)
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
