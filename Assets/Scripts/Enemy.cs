using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

// We're inheriting from everything in the TextRPG namespace (from character) via using TextRPG; for enemies.
   public interface IBaddie //lets say I want to enforce anything that implements IBaddie will do it's battle cry method.
{
    void Cry();
    string Description {  get; set; }
        
}
    public class Enemy : Character, IBaddie
    {
    public string Description { get; set; }
    public override void TakeDamage(int amount)
    {
        
        base.TakeDamage(amount);
        Debug.Log("This also happens, but only on enemy! Not other characers.");
        UIController.OnEnemyUpdate(this);
    }

    public void Cry() //We need this for IBaddie implementation.
    {

    }

    public override void Die()
    {
        Encounter.OnEnemyDie();
        Debug.Log("Character died, was enemy.");
    }

}


