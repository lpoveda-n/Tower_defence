using UnityEngine;

public class Capacite_speciale_manager : MonoBehaviour
{
    public static Capacite_speciale_manager Instance;
    public bool capacite_speciale_sniper_unlock;
    public bool capacite_speciale_slow_unlock;
    public bool capacite_speciale_antenne_unlock;
    public bool capacite_speciale_heavy_unlock;
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
        capacite_speciale_sniper_unlock=PlayerPrefs.GetInt("capacite_speciale_sniper_unlock",0)==1;
        capacite_speciale_slow_unlock=PlayerPrefs.GetInt("capacite_speciale_slow_unlock",0)==1;
        capacite_speciale_antenne_unlock=PlayerPrefs.GetInt("capacite_speciale_antenne_unlock",0)==1;
        capacite_speciale_heavy_unlock=PlayerPrefs.GetInt("capacite_speciale_heavy_unlock",0)==1;
    }
    public bool capacite_speciale_unlock_fct(string name)
    {
        if(name=="Sniper" && capacite_speciale_sniper_unlock)
        {
            return true;
        }
        if(name=="Slow" && capacite_speciale_slow_unlock)
        {
            return true;
        }
        if(name=="Antenne" && capacite_speciale_antenne_unlock)
        {
            return true;
        }
        if(name=="Heavy" && capacite_speciale_heavy_unlock)
        {
            return true;
        }
        return false;
    }
}
