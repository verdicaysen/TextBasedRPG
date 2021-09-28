using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextRPG;




    public class Encounter : MonoBehaviour
    {
    public Enemy Enemy { get; set; }
    [SerializeField] Player player;
    [SerializeField] Button[] dynamicControls;
    public delegate void OnEnemyDieHandler();
    public static OnEnemyDieHandler OnEnemyDie;

    private void Start()
    {
        OnEnemyDie += Loot;
    }



    public void ResetDynamicControls()
    {
        foreach(Button button in dynamicControls)
        {
            button.interactable = false;
        }
    }

    public void StartCombat()
    {
        this.Enemy = player.Room.Enemy;
        dynamicControls[0].interactable = true;
        dynamicControls[1].interactable = true;
       
    }

    public void StartChest()
    {
        dynamicControls[3].interactable = true;
    }

    public void StartExit()
    {
        dynamicControls[2].interactable = true;
    }

    public void Attack()
    {
        int playerDamageAmount = (int)(Random.value * (player.Attack - Enemy.Defense));
        int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - player.Defense));
        Journal.Instance.Log("<color=#59ffa1>You attacked, dealing <b>" + playerDamageAmount + "</b> damage!</color>");
        Journal.Instance.Log("<color=#59ffa1>The enemy retaliated, dealing <b>" + enemyDamageAmount + "</b> damage!</color>");
        player.TakeDamage(enemyDamageAmount);
        Enemy.TakeDamage(playerDamageAmount);
    }

    public void Flee()
    {
        int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - player.Defense * .5f));
        player.Room.Enemy = null;
        player.TakeDamage(enemyDamageAmount);
        Journal.Instance.Log("<color=#59ffa1>You fled the fight, taking <b>" + enemyDamageAmount + "</b> damage!</color>");
        player.Investigate();
    }

    public void ExitFloor()
    {
        StartCoroutine(player.world.GenerateFloor());
        player.Floor += 1;
        Journal.Instance.Log("You found an exit to another floor. Floor: " + player.Floor);
    }

    public void Loot()
    {
        player.AddItem(this.Enemy.Inventory[0]);
        player.Gold += this.Enemy.Gold;
        Journal.Instance.Log(string.Format(
            "<color=#56FFC7FF>You've slain {0}. Searching the carcass, you find a {1} and {2} gold!</color>",
            this.Enemy.Description, this.Enemy.Inventory[0], this.Enemy.Gold
        ));
        this.Enemy = null;

        player.Room.Enemy = null;

        player.Investigate();
    }

}
