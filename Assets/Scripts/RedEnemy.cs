using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedEnemy : MonoBehaviour
{
    public string enemyName = "Todd";
    public int enemyHealth = 70;
    public int tempEnemyHealth;
    public int enemyAttack = 30;
    public int enemyPierce = 5;
    private int enemyDamage;

    public Text labelEnemyName;
    public Text labelEnemyHealth;

    public RedPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        SettingEnemyInformation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            EnemyAttack();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SettingEnemyInformation();
        }
    }

    void SettingEnemyInformation()
    {
        labelEnemyName.text = enemyName;
        tempEnemyHealth = enemyHealth;
        labelEnemyHealth.text = enemyHealth.ToString();
    }

    public void EnemyAttack()
    {
        enemyDamage = (enemyAttack+enemyPierce) - player.playerDefence;
        if (enemyDamage > 0 && player.tempPlayerHealth !=0)
        {
            player.tempPlayerHealth -= enemyDamage;
        }
        if (player.tempPlayerHealth <= 0)
        {
            player.tempPlayerHealth = 0;
            print($"{player.playerName} мертв!");
        }
        else
        {
            print($"Нанесенный урон {enemyName} игроку {player.playerName} равен {enemyDamage}! У {player.playerName} осталось {player.tempPlayerHealth}");
        }
        player.labelPlayerHealth.text = player.tempPlayerHealth.ToString();
    }

}
