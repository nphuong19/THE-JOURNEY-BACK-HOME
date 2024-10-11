using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{
    Animator animator;
    public Sprite dieSprite;
    //tham chieu den diem tham chieu
    public List<Transform> points;
    public int nextID = 0;
    int idChangeValue = 1;
    
    // toc do cua cac enemy
    public float speed = 2;

<<<<<<< HEAD
    AudioManager audioManager;

=======
>>>>>>> origin/main
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Reset()
    {
        Init();
       
    }

<<<<<<< HEAD

=======
    
>>>>>>> origin/main

    void Init()
    {
        
        GetComponent<BoxCollider2D>().isTrigger = true;

       
        GameObject root = new GameObject(name + "_Root");
        
        root.transform.position = transform.position; 
        transform.SetParent(root.transform); 
        GameObject waypoints = new GameObject("Waypoints");
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform);
        p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform);
        p2.transform.position = root.transform.position;
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);

        

    }

<<<<<<< HEAD
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

=======
>>>>>>> origin/main
    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //lấy vị trí của điểm tiếp theo
        Transform goalPoint = points[nextID];
        //Lật quái vật khi quay đổi hướng
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        //di chuyển quái vật hướng đến điểm mục tiêu
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //Kiểm tra khoảng cách giữa điểm mục tiêu và quái vật để thay đổi hướng
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            
            if (nextID == points.Count - 1)
                idChangeValue = -1;
           
            if (nextID == 0)
                idChangeValue = 1;
            
            nextID += idChangeValue;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            if (Vector2.Dot(direction, Vector2.up) > 0.5f)
            {    
                OnDestroy();
<<<<<<< HEAD
                audioManager.PlaySFX(audioManager.enemyDeath);
                GameManager.Instance.IncreaseScore(10);
            }

            else
            {
                FindObjectOfType<player>().Hurt();
                FindObjectOfType<HealthBar>().LoseHealth(25);
                audioManager.PlaySFX(audioManager.hurt);
                // Đổi hướng ngay lập tức
                idChangeValue = -idChangeValue; // Đổi hướng
                nextID += idChangeValue;

                // Giới hạn nextID để đảm bảo nó nằm trong ranh giới
                if (nextID >= points.Count) nextID = points.Count - 1;
                if (nextID < 0) nextID = 0;
            }
                
            
=======
                GameManager.Instance.IncreaseScore(10);
            }
               
            else
                FindObjectOfType<HealthBar>().LoseHealth(25);
>>>>>>> origin/main
        }
    }

    private void OnDestroy()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        animator.SetBool("EnemyDeath", true);
        Destroy(gameObject, 0.5f);
    }
    
<<<<<<< HEAD

=======
>>>>>>> origin/main
}