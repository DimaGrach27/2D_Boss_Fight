using UnityEngine.Playables;
using UnityEngine;

public class EndingCatScene : MonoBehaviour
{

    private PlayableDirector playble;

    void Start() => playble = GetComponent<PlayableDirector>();

    void Update()
    {
        if (EnemyHealth.CurrentHealth <= 0)
            playble.Play();
    }
}
