using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    Vector2 dir = Vector2.right;

    List<Transform> tail = new List<Transform>();

    bool ate = false;

    public GameObject tailPrefab;
    public GameObject GameOverMenu;
    public Text score;
    public int scoreValue;
    private void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
    }
    void Move()
    {
        Vector2 v = transform.position;

        transform.Translate(dir);

        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            tail.Insert(0, g.transform);

            ate = false;
        }
        else if (tail.Count > 0)
        {

            tail.Last().position = v;

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("border") || coll.CompareTag("Player"))
        {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0;
        }
        if (coll.name.StartsWith("Food"))
        {
           if(coll.CompareTag("TimePlus"))
            {
                Timer.timeLeft += 5;
            }
                ate = true;
            scoreValue++;
            score.text = scoreValue.ToString();
            Destroy(coll.gameObject);
        }
        else
        {

        }
    }
}