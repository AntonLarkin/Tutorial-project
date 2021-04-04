using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenPlayer : MonoBehaviour
{
    public string playerName = "Jason";
    public int playerHealth = 100;
    public int tempPlayerHealth;
    public int playerAttack = 20;
    public int playerDefence = 10;
    private int current = 0;
    public int playerHealing = 10;
    public bool isPlayerReady = true;
    public bool isDead;
    private float timer = 2.5f;

    public Text labelPlayerName;
    public Text labelPlayerHealth;

    public GreenEnemy enemy;
    public EnemyKeeper keeper;

    // Start is called before the first frame update
    private void Start()
    {
        keeper.Enemies[current].gameObject.SetActive(true);
        SettingPlayerInformation();
    }

    // Update is called once per frame
    private void Update()
    {
        if (enemy.isGameActive == true)
        {
            if (isPlayerReady)
            {
                PlayerReadyToFight();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemy.isGameActive = true;
            SettingPlayerInformation();
        }
    }

    private void SettingPlayerInformation()
    {
        keeper.Enemies[current].tempEnemyHealth = keeper.Enemies[current].enemyHealth;
        keeper.Enemies[current].labelEnemyHealth.text = keeper.Enemies[current].tempEnemyHealth.ToString();
        keeper.Enemies[current].gameObject.SetActive(false);
        current = 0;
        keeper.Enemies[current].gameObject.SetActive(true);
        labelPlayerName.text = playerName;
        tempPlayerHealth = playerHealth;
        labelPlayerHealth.text = tempPlayerHealth.ToString();
    }

    private void PlayerAttack()
    {
        keeper.Enemies[current].tempEnemyHealth -= playerAttack;
        if (keeper.Enemies[current].tempEnemyHealth <= 0)
        {
            keeper.Enemies[current].tempEnemyHealth = 0;
            print($"{keeper.Enemies[current].enemyName} мертв!");
            tempPlayerHealth += playerHealing;
            labelPlayerHealth.text = tempPlayerHealth.ToString();
            keeper.Enemies[current].tempEnemyHealth = keeper.Enemies[current].enemyHealth;
            keeper.Enemies[current].labelEnemyHealth.text = keeper.Enemies[current].tempEnemyHealth.ToString();
            keeper.Enemies[current].gameObject.SetActive(false);
            current++;
            if (current >= 8)
            {
                enemy.isGameActive = false;
            }
            keeper.Enemies[current].gameObject.SetActive(true);
        }
        else
        {
            print($"Нанесенный урон {playerName} противнику { keeper.Enemies[current].enemyName} равен {playerAttack}! У { keeper.Enemies[current].enemyName} осталось { keeper.Enemies[current].tempEnemyHealth}");
        }
        keeper.Enemies[current].labelEnemyHealth.text = keeper.Enemies[current].tempEnemyHealth.ToString();
    }

    IEnumerator WaiterCoroutine(float value)
    {
        yield return new WaitForSeconds(value);
        PlayerAttack();
        enemy.isEnemyReady = true;
    }

    private void PlayerReadyToFight()
    {
        isPlayerReady = false;
        StartCoroutine(WaiterCoroutine(timer));
    }

}
