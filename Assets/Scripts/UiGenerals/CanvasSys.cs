using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasSys : MonoBehaviour
{
    [SerializeField] GameObject textHelp;
    [SerializeField] Text healtBar;
    [SerializeField] Text enemyBar;


    void Update()
    {
        if(PlayerHealthSys.CurrentHealth >= 0)
            healtBar.text = $"HP: {PlayerHealthSys.CurrentHealth}/100";
        else
            healtBar.text = $"HP: 0/100";

        if (EnemyHealth.CurrentHealth >= 0)
            enemyBar.text = $"HP: {EnemyHealth.CurrentHealth}/250";
        else
            enemyBar.text = $"HP: 0/100";

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
       
    }
}
