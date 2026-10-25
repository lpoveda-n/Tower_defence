using UnityEngine;
using UnityEngine.UI;

public class Open_infos : MonoBehaviour
{
    public GameObject infos;
    public bool active=true;
    void Start()
    {
        if (PlayerPrefs.GetInt("Reset", 0) == 1)
        {
            cacher();
            PlayerPrefs.SetInt("Reset", 0);
        }
    }
    public void cacher()
    {
        active=!active;
        infos.SetActive(active);
    }
}