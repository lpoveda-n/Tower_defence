using UnityEngine;
using UnityEngine.UI;

public class Health_bar_gigachonk : MonoBehaviour
{
    public Image healthbar;
    public GameObject health;
    public static Health_bar_gigachonk Instance;
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
}
