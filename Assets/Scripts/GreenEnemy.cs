using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenEnemy : MonoBehaviour
{
    public bool isGameActive=true;
    public string enemyName = "Todd";
    public int enemyHealth = 70;
    public int tempEnemyHealth;
    public int enemyAttack = 30;
    public int enemyPierce = 5;
    private int enemyDamage;
    public int enemyQuantity = 3;
    public bool isEnemyReady;
    private float timer = 2.5f;

    public Text labelEnemyName;
    public Text labelEnemyHealth;

    public GreenPlayer player;
    // Start is called before the first frame update
    private void Start()
    {
        SettingEnemyInformation();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isGameActive == true)
        {
            if (isEnemyReady || Input.GetKeyDown(KeyCode.Q)) 
            {                                                
                EnemyReadyToFight();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGameActive = true;
            SettingEnemyInformation();
        }
    }

    private void SettingEnemyInformation()
    {
        labelEnemyName.text = enemyName;
        tempEnemyHealth = enemyHealth;
        labelEnemyHealth.text = enemyHealth.ToString();
    }

    public void EnemyAttack()
    {
        enemyDamage = (enemyAttack + enemyPierce) - player.playerDefence;
        if (enemyDamage > 0 && player.tempPlayerHealth != 0)
        {
            player.tempPlayerHealth -= enemyDamage;
        }
        if (player.tempPlayerHealth <= 0)
        {
            player.tempPlayerHealth = 0;
            print($"{player.playerName} мертв!");
            isGameActive = false;
        }
        else
        {
            print($"Нанесенный урон {enemyName} игроку {player.playerName} равен {enemyDamage}! У {player.playerName} осталось {player.tempPlayerHealth}");
        }
        player.labelPlayerHealth.text = player.tempPlayerHealth.ToString();
    }

    IEnumerator WaiterCoroutine(float value)
    {
        yield return new WaitForSeconds(value);
        EnemyAttack();
        player.isPlayerReady = true;
    }
    private void EnemyReadyToFight()
    {
        isEnemyReady = false;
        StartCoroutine(WaiterCoroutine(timer));
    }

}
