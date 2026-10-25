using UnityEngine;
using UnityEngine.UI;

public class Sound_manager : MonoBehaviour
{
    public Camera camera;
    public AudioClip[] musiques;
    private float sound_range=20f;
    public AudioSource audioSource_sound_effects;
    public AudioSource audioSource_music;
    public float music_multiplier;
    private int current_music=0;
    private float music_remaning_duration;
    public float sound_effect_multiplier;
    private float tir_heavy_cooldown=0.5f;
    private float current_tir_heavy_cooldown=0f;
    private float tir_railgun_cooldown=0.5f;
    private float current_tir_railgun_cooldown=0f;
    private float tir_standard_cooldown=0.5f;
    private float current_tir_standard_cooldown=0f;
    private float tir_shotgun_cooldown=0.5f;
    private float current_tir_shotgun_cooldown=0f;
    private float tir_sniper_cooldown=0.5f;
    private float current_tir_sniper_cooldown=0f;
    private float tir_poison_cooldown=0.5f;
    private float current_tir_poison_cooldown=0f;
    private float tir_missile_cooldown=0.5f;
    private float current_tir_missile_cooldown=0f;
    private float tir_troll_cooldown=0.5f;
    private float current_tir_troll_cooldown=0f;
    private float explosion_cooldown=0.25f;
    private float current_explosion_cooldown=0f;
    private float fire_cooldown=10f;
    private float current_fire_cooldown=0f;
    private float die_cooldown=1f;
    private float current_die_cooldown=0f;
    public bool troll;
    public AudioClip tir_railgun;
    public AudioClip tir_heavy;
    public AudioClip tir_standard;
    public AudioClip tir_shotgun;
    public AudioClip tir_sniper;
    public AudioClip tir_poison;
    public AudioClip tir_missile;
    public AudioClip explosion;
    public AudioClip empower;
    public AudioClip fire;
    public AudioClip die;
    public AudioClip big_die;
    public AudioClip cat_spawn;
    public AudioClip cat_die;
    public AudioClip tir_troll;
    public AudioClip die_troll;
    public static Sound_manager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        } else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSource_music.PlayOneShot(musiques[current_music],music_multiplier);
        music_remaning_duration=musiques[current_music].length;
    }
    public void play_sound(Vector3 position_sound,string name)
    {
        if (!troll && name == "Cat_spawn")
        {
            audioSource_sound_effects.PlayOneShot(cat_spawn,4f*sound_effect_multiplier);
            return;
        }
        if(Vector2.Distance(camera.transform.position, position_sound) > sound_range)
        {
            return;
        }
        if (troll && current_die_cooldown<=0 && (name=="Die" || name=="Big_die"))
        {
            current_die_cooldown=die_cooldown;
            audioSource_sound_effects.PlayOneShot(die_troll,2f*sound_effect_multiplier);
            return;
        }
        if (troll)
        {
            return;
        }
        if (name == "Fire" && current_fire_cooldown<=0)
        {
            current_fire_cooldown=fire_cooldown;
            audioSource_sound_effects.PlayOneShot(fire,0.5f*sound_effect_multiplier);
            return;
        }
        if (name == "Explosion" && current_explosion_cooldown<=0)
        {
            current_explosion_cooldown=explosion_cooldown;
            audioSource_sound_effects.PlayOneShot(explosion,0.5f*sound_effect_multiplier);
            return;
        }
        if (name == "Empower")
        {
            audioSource_sound_effects.PlayOneShot(empower,2.5f*sound_effect_multiplier);
            return;
        }
        if (current_die_cooldown<=0 && name == "Die")
        {
            current_die_cooldown=die_cooldown;
            audioSource_sound_effects.PlayOneShot(die,1f*sound_effect_multiplier);
            return;
        }
        if (current_die_cooldown<=0 && name == "Big_die")
        {
            current_die_cooldown=die_cooldown;
            audioSource_sound_effects.PlayOneShot(big_die,1f*sound_effect_multiplier);
            return;
        }
        if (name == "Cat_die")
        {
            audioSource_sound_effects.PlayOneShot(cat_die,4f*sound_effect_multiplier);
            return;
        }
    }
    public void play_tir(Vector3 position_sound,string name)
    {
        if(Vector2.Distance(camera.transform.position, position_sound) > sound_range)
        {
            return;
        }
        if (troll && current_tir_troll_cooldown<=0)
        {
            current_tir_troll_cooldown=tir_troll_cooldown;
            audioSource_sound_effects.PlayOneShot(tir_troll,2.5f*sound_effect_multiplier);
            return;
        }
        if (name == "Railgun" && current_tir_railgun_cooldown<=0)
        {
            current_tir_railgun_cooldown=tir_railgun_cooldown;
            audioSource_sound_effects.PlayOneShot(tir_railgun,1f*sound_effect_multiplier);
            return;
        }
        if (name == "Heavy" && current_tir_heavy_cooldown<=0)
        {
            current_tir_heavy_cooldown=tir_heavy_cooldown;
            audioSource_sound_effects.PlayOneShot(tir_heavy,1f*sound_effect_multiplier);
            return;
        }
        if (name == "Standard" && current_tir_standard_cooldown<=0)
        {
            current_tir_standard_cooldown=tir_standard_cooldown;
            audioSource_sound_effects.PlayOneShot(tir_standard,0.4f*sound_effect_multiplier);
            return;
        }
        if (name == "Shotgun" && current_tir_shotgun_cooldown<=0)
        {
            current_tir_shotgun_cooldown=tir_shotgun_cooldown;
            audioSource_sound_effects.PlayOneShot(tir_shotgun,0.65f*sound_effect_multiplier);
            return;
        }
        if (name == "Sniper" && current_tir_sniper_cooldown<=0)
        {
            current_tir_sniper_cooldown=tir_sniper_cooldown;
            audioSource_sound_effects.PlayOneShot(tir_sniper,0.4f*sound_effect_multiplier);
            return;
        }
        if (name == "Poison" && current_tir_poison_cooldown<=0)
        {
            current_tir_poison_cooldown=tir_poison_cooldown;
            audioSource_sound_effects.PlayOneShot(tir_poison,0.6f*sound_effect_multiplier);
            return;
        }
        if (name == "Missile" && current_tir_missile_cooldown<=0)
        {
            current_tir_missile_cooldown=tir_missile_cooldown;
            audioSource_sound_effects.PlayOneShot(tir_missile,0.75f*sound_effect_multiplier);
            return;
        }
    }
    public void play_die(Vector3 position_sound,AudioClip die)
    {
        if (Vector2.Distance(camera.transform.position, position_sound) <= sound_range && current_die_cooldown<=0)
        {
            audioSource_sound_effects.PlayOneShot(troll ? die_troll : die);
            current_die_cooldown=die_cooldown;
        }
    }
    void Update()
    {
        sound_range=camera.orthographicSize*1.6f;
        music_remaning_duration-=Time.deltaTime;
        if (music_remaning_duration <= 0)
        {
            current_music++;
            if (current_music >= musiques.Length)
            {
                current_music=0;
            }
            audioSource_music.PlayOneShot(musiques[current_music],music_multiplier);
            music_remaning_duration=musiques[current_music].length;
        }
        current_tir_troll_cooldown-=Time.deltaTime;
        if (current_tir_troll_cooldown <= 0)
        {
            current_tir_troll_cooldown=0;
        }
        current_tir_railgun_cooldown-=Time.deltaTime;
        if (current_tir_railgun_cooldown <= 0)
        {
            current_tir_railgun_cooldown=0;
        }
        current_tir_heavy_cooldown-=Time.deltaTime;
        if (current_tir_heavy_cooldown <= 0)
        {
            current_tir_heavy_cooldown=0;
        }
        current_tir_standard_cooldown-=Time.deltaTime;
        if (current_tir_standard_cooldown <= 0)
        {
            current_tir_standard_cooldown=0;
        }
        current_tir_shotgun_cooldown-=Time.deltaTime;
        if (current_tir_shotgun_cooldown <= 0)
        {
            current_tir_shotgun_cooldown=0;
        }
        current_tir_sniper_cooldown-=Time.deltaTime;
        if (current_tir_sniper_cooldown <= 0)
        {
            current_tir_sniper_cooldown=0;
        }
        current_tir_poison_cooldown-=Time.deltaTime;
        if (current_tir_poison_cooldown <= 0)
        {
            current_tir_poison_cooldown=0;
        }
        current_tir_missile_cooldown-=Time.deltaTime;
        if (current_tir_missile_cooldown <= 0)
        {
            current_tir_missile_cooldown=0;
        }
        current_explosion_cooldown-=Time.deltaTime;
        if (current_explosion_cooldown <= 0)
        {
            current_explosion_cooldown=0;
        }
        current_fire_cooldown-=Time.deltaTime;
        if (current_fire_cooldown <= 0)
        {
            current_fire_cooldown=0;
        }
        current_die_cooldown-=Time.deltaTime;
        if (current_die_cooldown <= 0)
        {
            current_die_cooldown=0;
        }
    }
}
