using UnityEngine;

[System.Serializable]
public class Turret_blueprint
{
    public string name;
    public bool is_antenne_turret;
    public bool is_generateur_turret;
    public bool is_banque_turret;
    public GameObject Level1_prefab;
    public GameObject Level2_prefab;
    public GameObject Level3_prefab;
    public GameObject Level4_prefab;
    public float damage_empower;
    public float fire_cooldown_empower;
    public float range_empower;
    public float bullet_speed_empower;
    public float blast_radius_empower;
    public int cost_Level1;
    public int cost_Level2;
    public int cost_Level3;
    public int cost_Level4;
    public string stats_level1;
    public string stats_level2;
    public string stats_level3;
    public string stats_level4;
    public string stats_empower_level1;
    public string stats_empower_level2;
    public string stats_empower_level3;
    public string stats_empower_level4;
    public string stats_level_up1;
    public string stats_level_up2;
    public string stats_level_up3;
}