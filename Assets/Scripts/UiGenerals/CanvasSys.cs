using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CanvasSys : MonoBehaviour
{
    [SerializeField] GameObject textHelp;
    [SerializeField] Text healtBar;
    [SerializeField] Text enemyBar;

    //Текст и картинка перезарядки способностей
    [SerializeField] Text attackReload;
    [SerializeField] Image attack;

    [SerializeField] Text castBallReload;
    [SerializeField] Image castBall;

    [SerializeField] Text cjargAttackllReload;
    [SerializeField] Image charge;


    public static bool endGame;

    void Update()
    {
        if(PlayerHealthSys.CurrentHealth >= 0)
            healtBar.text = $"HP: {PlayerHealthSys.CurrentHealth}/{new PlayerHealthSys().MaxHealth}";
        else
            healtBar.text = $"HP: 0/100";

        if (EnemyHealth.CurrentHealth >= 0)
            enemyBar.text = $"HP: {EnemyHealth.CurrentHealth}/{new EnemyHealth().MaxHealth}";
        else
            enemyBar.text = $"HP: 0/100";

        if (Input.GetKeyDown(KeyCode.F9))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (textHelp.activeInHierarchy)
            {
                textHelp.SetActive(false);
            }
            else
            {
                textHelp.SetActive(true);
            }
        }

        if (PlayerHealthSys.isDeath)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (endGame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        TextToReaload();
    }

    void TextToReaload()
    {
        PlayerAttack.reloadTimeCast -= Time.deltaTime;
        PlayerAttack.reloadTimeCharg -= Time.deltaTime;
        PlayerAttack.reloadAttack -= Time.deltaTime;

        //int reload = (int)PlayerAttack.reloadTimeCast;

        if (PlayerAttack.reloadTimeCast >= 0)
        {
            float reloadTime = (float)Math.Round(PlayerAttack.reloadTimeCast, 1);

            castBallReload.text = reloadTime.ToString();
            castBall.color = Color.gray;
        }
        else
        {
            castBall.color = Color.white;
            castBallReload.text = null;
        }

        if (PlayerAttack.reloadTimeCharg >= 0)
        {
            float reloadTime = (float)Math.Round(PlayerAttack.reloadTimeCharg, 1);

            cjargAttackllReload.text = reloadTime.ToString();
            charge.color = Color.gray;
        }
        else
        {
            charge.color = Color.white;
            cjargAttackllReload.text = null;
        }

        if (PlayerAttack.reloadAttack >= 0)
        {
            float reloadTime = (float)Math.Round(PlayerAttack.reloadAttack, 1);

            attackReload.text = reloadTime.ToString();
            attack.color = Color.gray;
        }
        else
        {
            attack.color = Color.white;
            attackReload.text = null;
        }
    }

}
