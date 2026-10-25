using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class Player_stats : MonoBehaviour
{
    public static int money;
    public bool game_started=false;
    public int starting_money = 400;
    public static int lives;
    public int starting_lives=5;
    public static Player_stats Instance;
    private Game_manager game_Manager;
    private Text money_text;
    private Text health_text;
    private Text supply_text;
    private Text empower_text;
    public int supply_amount=0;
    public int supply_income=5;
    private float supply_cooldown=2;
    private float current_supply_cooldown=2;
    public int empower;
    public int max_empower;
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
    void Start (){
        game_Manager=Game_manager.Instance;
        money=starting_money;
        lives=starting_lives;
        empower=max_empower;
        money_text=GameObject.FindGameObjectWithTag("Text money").GetComponent<Text>();
        money_text.text=Convert.ToString(MathF.Round(money));
        health_text=GameObject.FindGameObjectWithTag("Text health").GetComponent<Text>();
        health_text.text=Convert.ToString(lives)+"/"+starting_lives;
        supply_text=GameObject.FindGameObjectWithTag("Text supply").GetComponent<Text>();
        empower_text=GameObject.FindGameObjectWithTag("Text empower").GetComponent<Text>();
        empower_text.text=Convert.ToString(empower)+"/"+max_empower;
    }
    void FixedUpdate()
    {
        if(!game_started)
        {
            return;
        }
        current_supply_cooldown-=Time.deltaTime;
        if (current_supply_cooldown <= 0)
        {
            current_supply_cooldown=supply_cooldown;
            supply_amount+=supply_income;
            supply_text.text=Convert.ToString(supply_amount);
        }
    }
    public void change_money(int nb)
    {
        money+=nb;
        money_text.text=Convert.ToString(MathF.Round(money));
    }
    public void change_supply(int nb)
    {
        supply_amount+=nb;
        supply_text.text=Convert.ToString(MathF.Round(supply_amount));
    }
    public void change_empower(bool empowering)
    {
        empower += empowering ? -1 : 1;
        empower_text.text=Convert.ToString(empower)+"/"+max_empower;
    }
    public void change_max_empower(int n)
    {
        empower += n;
        max_empower += n;
        empower_text.text=Convert.ToString(empower)+"/"+max_empower;
    }
    public void base_damaged(int damage)
    {
        if(game_Manager.game_over || game_Manager.win)
        {
            return;
        }
        lives-=damage;
        health_text.text=Convert.ToString(MathF.Max(lives,0))+"/"+starting_lives;
        if (lives <= 0)
        {
            lives=0;
            game_Manager.game_over_fct();
        }
    }
}
