using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;
    
    void Start()
    {
        // Charge le volume sonore actuel et met � jour le slider
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        SetVolume(volumeSlider.value);
    }

    // M�thode appel�e par le slider lorsqu'il est d�plac�
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // D�finit le volume du jeu
        PlayerPrefs.SetFloat("MasterVolume", volume); // Enregistre le volume dans les pr�f�rences du joueur
    }

    public void UpdateVolume() {
        SetVolume(volumeSlider.value);
    }
}
