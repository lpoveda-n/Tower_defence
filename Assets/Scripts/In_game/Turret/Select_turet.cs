using UnityEngine;

public class Select_turet : MonoBehaviour
{
    public Turret_blueprint standard_turret;
    public Turret_blueprint sniper_turret;
    public Turret_blueprint slow_turret;
    public Turret_blueprint missile_launcher_turret;
    public Turret_blueprint antenne_turret;
    public Turret_blueprint generateur_turret;
    public Turret_blueprint shotgun_turret;
    public Turret_blueprint heavy_turret;
    public Turret_blueprint banque_turret;
    public Turret_blueprint poison_turret;
    public Turret_blueprint railgun_turret;
    private Build_manager build_Manager;
    public Open_shop open_Shop;
    void Start()
    {
        build_Manager=Build_manager.Instance;
    }
    public void select_standard_turret()
    {
        build_Manager.select_turet(standard_turret);
    }
    public void select_sniper_turret()
    {
        build_Manager.select_turet(sniper_turret);
    }
    public void select_slow_turret()
    {
        build_Manager.select_turet(slow_turret);
    }
    public void select_missile_launcher_turret()
    {
        build_Manager.select_turet(missile_launcher_turret);
    }
    public void select_antenne_turret()
    {
        build_Manager.select_turet(antenne_turret);
    }
    public void select_generateur_turret()
    {
        build_Manager.select_turet(generateur_turret);
    }
    public void select_shotgun_turret()
    {
        build_Manager.select_turet(shotgun_turret);
    }
    public void select_heavy_turret()
    {
        build_Manager.select_turet(heavy_turret);
    }
    public void select_banque_turret()
    {
        build_Manager.select_turet(banque_turret);
    }
    public void select_poison_turret()
    {
        build_Manager.select_turet(poison_turret);
    }
    public void select_railgun_turret()
    {
        build_Manager.select_turet(railgun_turret);
    }
}
