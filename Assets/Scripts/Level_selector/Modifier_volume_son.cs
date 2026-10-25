using UnityEngine;
using UnityEngine.UI;

public class Modifier_volume_son : MonoBehaviour
{
    public Sound_manager sound_Manager;
    public int sound_effects_volume;
    public int music_volume;
    private AudioSource sound_effects;
    private AudioSource music;
    public Text sound_effects_text;
    public Text music_text;
    void Start()
    {
        sound_effects=sound_Manager.audioSource_sound_effects;
        music=sound_Manager.audioSource_music;
        sound_effects_volume=PlayerPrefs.GetInt("sound_effects_volume",50);
        music_volume=PlayerPrefs.GetInt("music_volume",50);
        sound_effects.volume=(float)sound_effects_volume/100;
        sound_effects_text.text="Volume des efets sonores "+ sound_effects_volume + "%";
        music.volume=(float)music_volume/100;
        music_text.text="Volume de la musique "+ music_volume + "%";
    }
    public void change_sound_effects_volume(int n)
    {
        sound_effects_volume+=n;
        if (sound_effects_volume >= 100)
        {
            sound_effects_volume=100;
        }
        if (sound_effects_volume <= 0)
        {
            sound_effects_volume=0;
        }
        sound_effects.volume=(float)sound_effects_volume/100;
        sound_effects_text.text="Volume des efets sonores "+ sound_effects_volume + "%";
        PlayerPrefs.SetInt("sound_effects_volume",sound_effects_volume);
    }
    public void change_music_volume(int n)
    {
        music_volume+=n;
        if (music_volume >= 100)
        {
            music_volume=100;
        }
        if (music_volume <= 0)
        {
            music_volume=0;
        }
        music.volume=(float)music_volume/100;
        PlayerPrefs.SetInt("music_volume",music_volume);
        music_text.text="Volume de la musique "+ music_volume + "%";
    }
}
