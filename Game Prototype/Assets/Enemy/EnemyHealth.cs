using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Maximum HP")]
    int maxHP = 3; //Enemy Health
    public int hp = 0;
    Enemy enemy;
    GameHandler gameHandler;
    AudioSource explosionAudioSource;
    private void Awake()
    {
        
    }
    void Start()
    {   
        enemy = GetComponent<Enemy>();
        explosionAudioSource = GameObject.Find("explosionAudio").GetComponent<AudioSource>();
        gameHandler = GameObject.FindObjectOfType<GameHandler>();
        hp = maxHP + gameHandler.difficulty;
    }
    void OnParticleCollision(GameObject other)
    {
        Damage();
    }

    void Damage()
    {
        hp--;
        if (hp <= 0)
        {
            enemy.GiveMoney();
            explosionAudioSource.Play();
            gameHandler.score++;
            Destroy(gameObject);
        }
    }
}
