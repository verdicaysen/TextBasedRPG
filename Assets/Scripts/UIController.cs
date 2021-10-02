using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextRPG;

public class UIController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Text playerStatsText, enemyStatsText, playerInventoryText;
    public delegate void OnPlayerUpdateHandler();
    public static OnPlayerUpdateHandler OnPlayerStatChange;
    public static OnPlayerUpdateHandler OnPlayerInventoryChange;

    public delegate void OnEnemyUpdateHandler(Enemy enemy); // You could also do this for Player Update Handler and say Player player and put it in the two Player methods in parameters. We're doing this to handle multiple enemies, you'd also do this to handle multiple players. (Which I will)
    public static OnEnemyUpdateHandler OnEnemyUpdate;
    void Start()
    {
        OnPlayerStatChange += UpdatePlayerStats;
        OnPlayerInventoryChange += UpdatePlayerInventory;
        OnEnemyUpdate += UpdateEnemyStats;
        
    }

    
    public void UpdatePlayerStats()
    {
        playerStatsText.text = string.Format("Player: {0} Energy, {1} Attack, {2} Defense, {3} Gold", player.Energy, player.Attack, player.Defense, player.Gold);
    }

    public void UpdatePlayerInventory()
    {
        playerInventoryText.text = "Items: ";
        foreach (string item in player.Inventory)
        {

            playerInventoryText.text += item + " / ";
        }
    }
    public void UpdateEnemyStats(Enemy enemy)
    {
        if (enemy)
            enemyStatsText.text = string.Format("{0}: {1} Energy, {2} Attack, {3} Defense", enemy.Description, enemy.Energy, enemy.Attack, enemy.Defense);
        else
            enemyStatsText.text = "";
    }
}
