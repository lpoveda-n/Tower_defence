using UnityEngine;
using UnityEngine.UI;

public class UI_antenne : MonoBehaviour
{
    public Turret turret;
    public Text turret_stats_antenne_text;
    public Text turret_antenne_current_buff_text;
    public Text empower_button_UI_antenne_text;
    private string turret_antenne_current_buff_string="Current buff:\n";
    public Button button_level2;
    public Button button_level3;
    public Button empower_button_UI_antenne;

    public void change_aura_none()
    {
        turret_antenne_current_buff_text.text=turret_antenne_current_buff_string;
        turret.set_aura(0);
    }
    public void change_aura_range()
    {
        turret_antenne_current_buff_text.text=turret_antenne_current_buff_string+"Range+5";
        turret.set_aura(1);
    }
    public void change_aura_damage()
    {
        turret_antenne_current_buff_text.text=turret_antenne_current_buff_string+"Damage + 20%";
        turret.set_aura(2);
    }
    public void change_aura_speed()
    {
        turret_antenne_current_buff_text.text=turret_antenne_current_buff_string+"Reload time -20%\nBullet speed +10";
        turret.set_aura(3);
    }
    public void parametrage_UI_antenne(Spot_turret target)
    {
        turret=target.turret.GetComponent<Turret>();
        button_level2.interactable=true;
        button_level3.interactable=true;
        if (target.level <= 2)
        {
            button_level3.interactable=false;
        }
        if (target.level <= 1)
        {
            button_level2.interactable=false;
        }
        if (turret.get_aura() == 0)
        {
            change_aura_none();
        }
        if (turret.get_aura() == 1)
        {
            change_aura_range();
        }
        if (turret.get_aura() == 2)
        {
            change_aura_damage();
        }
        if (turret.get_aura() == 3)
        {
            change_aura_speed();
        }
        if (turret.empowered)
        {
            if (target.level == 4)
            {
                turret_stats_antenne_text.text="<color=white> Range 20</color><color=#FFE200>->25 </color>\nDegats aux enemis dans la zone 1 par seconde";
            } else
            {
                turret_stats_antenne_text.text="<color=white> Range 20</color><color=#FFE200>->25 </color>";   
            }
        } else
        {
            if (target.level == 4)
            {
                turret_stats_antenne_text.text="<color=white> Range 20 </color>\nDegats aux enemis dans la zone 1 par seconde";
            } else
            {
                turret_stats_antenne_text.text="<color=white> Range 20 </color>";   
            }
        }
        if (turret.empowered)
        {
            empower_button_UI_antenne_text.text="Disempower";
            empower_button_UI_antenne.interactable=true;
        } else
        {
            if (Player_stats.Instance.empower <= 0)
            {
                empower_button_UI_antenne.interactable=false;
            } else
            {
                empower_button_UI_antenne.interactable=true;
            }
            empower_button_UI_antenne_text.text="Empower";
        }
    }
}
