using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;
    
    void Start()
    {
        // Charge le volume sonore actuel et met à jour le slider
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        SetVolume(volumeSlider.value);
    }

    // Méthode appelée par le slider lorsqu'il est déplacé
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Définit le volume du jeu
        PlayerPrefs.SetFloat("MasterVolume", volume); // Enregistre le volume dans les préférences du joueur
    }

    public void UpdateVolume() {
        SetVolume(volumeSlider.value);
    }
}
