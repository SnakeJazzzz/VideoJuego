using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "NPCManager", fileName =
"Set")]
public class NPCManager : ScriptableObject
{

    public  RSGameObject EnemyTowers;
    public  RSGameObject EnemyNPCs;
    public  RSGameObject PlayerTowers;
    public  RSGameObject PlayerNPCs;
    public RSRSGameObject AllEntities;
    public List<List<List<GameObject>>> Entities = new List<List<List<GameObject>>>
    {
        new List<List<GameObject>>{ new List<GameObject>(), new List<GameObject>()}, // First empty list
        new List<List<GameObject>>{ new List<GameObject>(), new List<GameObject>()}, // Second empty list
    };
    

    public void Register(GameObject toRegister, int team, bool isTower)
    {   
       
        int index = isTower ? 1 : 0;
        Entities[team][index].Add(toRegister);
        /*
        int count = 0;
        for (int i = 0; i < Entities.Count; i++)
        {
           for (int j = 0; j < Entities[i].Count; j++) 
           {
                for (int k = 0; k < Entities[i][j].Count; k++)
                {
                    count++;
                }
           } 
        }
        Debug.Log(count + "entities ATM.");*/

    }

     public void Delete(GameObject toRegister, int team, bool isTower)
    {
        
        int index = isTower ? 1 : 0;
        Entities[team][index].Remove(toRegister);

        /*int count = 0;
        for (int i = 0; i < Entities.Count; i++)
        {
           for (int j = 0; j < Entities[i].Count; j++) 
           {
                for (int k = 0; k < Entities[i][j].Count; k++)
                {
                    count++;
                }
           } 
        }
        Debug.Log(count + "entities ATM.");*/
    }

    public GameObject ClosestTarget(GameObject GO, int team, bool attackTowers, bool attackNPCs)
    {
        /*
        List<GameObject> targets = new List<GameObject>();
        if (attackTowers)
        {
        RSGameObject Towers = team == 0 ? EnemyTowers: PlayerTowers;
        targets.AddRange(Towers.Items);
        }
        if(attackEnemies)
        {
            RSGameObject Enemies = team == 0 ? EnemyNPCs: PlayerNPCs;
            targets.AddRange(Enemies.Items);
        }*/
       
        List<GameObject> targets = new List<GameObject>();
        int teamToAttack = team == 0 ? 1 : 0; 
        if (attackNPCs) { targets.AddRange(Entities[teamToAttack][0]); }
        if (attackTowers) { targets.AddRange(Entities[teamToAttack][1]); }
    

        float distance = Mathf.Infinity;
        GameObject closest = null; // Initialize closest to null

        foreach (GameObject target in targets)
        {
            //if (target != null)
            //{
                float thisDistance = Vector3.Distance (GO.transform.position, target.transform.position);;
                if (distance > thisDistance)
                {
                    distance = thisDistance; // Update the distance to the new shortest distance
                    closest = target; // Update the closest tower
                }
            //}
        }
        
        return closest;
    }
}





/* OLD VERSIONS
 public void Delete(GameObject toRegister, int team, bool isTower)
    {
        if (isTower)
        {
            if (team == 0) 
            {
                PlayerTowers.Remove(toRegister);
            }
            else if (team == 1)
            {
                EnemyTowers.Remove(toRegister);
            }
        }
        else
        {
            if (team == 0) 
            {
                PlayerNPCs.Remove(toRegister);
            }
            else if (team == 1)
            {
                EnemyNPCs.Remove(toRegister);
            }
        }
    }*/
    /*
    public void Register(GameObject toRegister, int team, bool isTower)
    {   
        
        if (isTower)
        {
            if (team == 0) 
            {
                PlayerTowers.Add(toRegister);
            }
            else if (team == 1)
            {
                EnemyTowers.Add(toRegister);
            }
        }
        else
        {
            if (team == 0) 
            {
                PlayerNPCs.Add(toRegister);
            }
            else if (team == 1)
            {
                EnemyNPCs.Add(toRegister);
            }
        }
    }*/