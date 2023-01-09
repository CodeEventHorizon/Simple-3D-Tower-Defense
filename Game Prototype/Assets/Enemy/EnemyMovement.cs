using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public List<TileClass> coords = new List<TileClass>(); //The path for an enemy
    [SerializeField] [Range(0f, 6f)] float speed = 1f;
    Enemy enemy;
    GameHandler gameHandler;
    void Awake()
    {
        FindTheWay();
        StartAtOrigin();
        StartCoroutine(FollowTheWay());
    }
    void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
        enemy = GetComponentInChildren<Enemy>();
    }
    void FindTheWay()
    {
        coords.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            coords.Add(child.GetComponent<TileClass>() != null ? child.GetComponent<TileClass>() : null);
        }
    }
    void StartAtOrigin()
    {
        transform.position = coords[0].transform.position;
    }
    IEnumerator FollowTheWay()
    {
        foreach (TileClass t in coords)
        {
            Vector3 start = transform.position;
            Vector3 end = t.transform.position;
            float temp = 0f;
            while (temp < 1f)
            {
                temp += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(start, end, temp);
                yield return new WaitForEndOfFrame();
            }
        }
        enemy.TakeMoney();
        gameHandler.hearts--;
        Destroy(gameObject);
    }
}
