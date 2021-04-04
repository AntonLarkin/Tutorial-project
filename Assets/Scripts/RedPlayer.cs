using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedPlayer : MonoBehaviour
{
    public string playerName = "Jason";
    public int playerHealth = 100;
    public int tempPlayerHealth;
    public int playerAttack = 20;
    public int playerDefence = 10;

    public Text labelPlayerName;
    public Text labelPlayerHealth;

    public RedEnemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        SettingPlayerInformation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerAttack();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SettingPlayerInformation();
        }
    }

    private void SettingPlayerInformation()
    {
        labelPlayerName.text = playerName;
        tempPlayerHealth = playerHealth;
        labelPlayerHealth.text = tempPlayerHealth.ToString();
    }

    private void PlayerAttack()
    {

        enemy.tempEnemyHealth -= playerAttack;
        if (enemy.tempEnemyHealth <= 0)
        {
            enemy.tempEnemyHealth = 0;
            print($"{enemy.enemyName} мертв!");
        }
        else
        {
            print($"Нанесенный урон {playerName} противнику {enemy.enemyName} равен {playerAttack}! У {enemy.enemyName} осталось {enemy.tempEnemyHealth}");
        }
        enemy.labelEnemyHealth.text = enemy.tempEnemyHealth  .ToString();
    }
}
