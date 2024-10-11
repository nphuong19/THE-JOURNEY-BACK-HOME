using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class player : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Collider2D standingCollider, crouchingCollider;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] Transform overheadCheckCollider;
    [SerializeField] LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    const float overheadCheckRadius = 0.2f;
    [SerializeField] float speed = 2;
    [SerializeField] float jumpPower = 8;
    [SerializeField] int totalJumps = 2;
    int availableJumps;
    float dir;
    float runSpeedModifier = 2f;
    float crouchSpeedModifier = 0.5f;

    [SerializeField] bool isGrounded = false;
    bool isFacing = true;
    bool isRunning = false;
    [SerializeField] bool crouch;
    bool doubleJump;
    bool coyoteJump;
    bool isDead = false;

    private DeathAnimation deathAnimation;
    public bool dead => deathAnimation.enabled;
    public Text scoreText;
    public Text highScoreText;

<<<<<<< HEAD
    private SpriteRenderer spriteRenderer; // Tham chiếu đến SpriteRenderer
    private Color originalColor; // Màu sắc ban đầu
    public float recoilDistance = 0.2f; // Khoảng cách lùi lại

    AudioManager audioManager;
=======
>>>>>>> origin/main

    void Start()
    {
        // thiết lập tổng số lần nhảy
        availableJumps = totalJumps;
<<<<<<< HEAD
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // Lưu lại màu sắc ban đầu
=======

>>>>>>> origin/main
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // cập nhật điểm số lên giao diện
        UpdateScoreUI();
    }

    private void Awake()
    {
<<<<<<< HEAD
       audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
=======
>>>>>>> origin/main
       deathAnimation = GetComponent<DeathAnimation>();
    }

    void Update()
    {
        if (CanMove() == false)
            return;

        // lấy giá trị di chuyển ngang từ người chơi
        // nhận tín hiệu từ 2 phím A và D
        dir = Input.GetAxisRaw("Horizontal");

        // nếu nhấn Shift chuyển sang trạng thái chạy
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRunning = true ;
        // Bỏ shift hủy trạng thái chạy
        if (Input.GetKeyUp(KeyCode.LeftShift))
            isRunning = false;

        //thực hiện nhảy khi nhấn phím jump
        if (Input.GetButtonDown("Jump"))   
            Jump();

        //Thực hiện cúi nếu nhấn phím Crouch
        if (Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;

        animator.SetFloat("yVelocity", rb.velocity.y);

    }

    bool CanMove()
    {
        bool can = true;
        if(FindObjectOfType<InteractionSystem>().isExamining)
            can = false;

        if (FindObjectOfType<InventorySystem>().isOpen)
            can = false;

        if (isDead)
            can = false;
        

        return can;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheckCollider.position, groundCheckRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(overheadCheckCollider.position, overheadCheckRadius);
    }

    void FixedUpdate()
    {
        // thực hiện di chuyển
        Move( crouch);
        // kiểm tra xem nhân vật ở trên mặt đất hay không
        GroundCheck();
    }

    void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false ;
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (collider.Length > 0)
        {
            isGrounded = true;
            if (!wasGrounded)
            {
                availableJumps = totalJumps;
                doubleJump = false;

<<<<<<< HEAD
                audioManager.PlaySFX(audioManager.landing);
=======
                /*AudioManager.instance.PlaySFX("landing");*/
>>>>>>> origin/main
            }
            
            //
            foreach(var c in collider)
            {
                if (c.tag == "MovingPlatform")
                    transform.parent = c.transform;
            }

        }
        else
        {
            //
            transform.parent = null;

            if (wasGrounded)
                StartCoroutine(CoyoteJumpDelay());
        }

        
        animator.SetBool("Jump", !isGrounded) ;
    }

    

    IEnumerator CoyoteJumpDelay()
    {
        coyoteJump = true;
        yield return new WaitForSeconds(0.2f);
        coyoteJump = false;
    }

    void Jump()
    {
        if (isGrounded)
        {
            doubleJump = true;
            availableJumps--;
            // Đặt lực nhảy
            rb.velocity = Vector2.up * jumpPower;
            // thiết lập animation cho động tác nhảy
            animator.SetBool("Jump", true);
        }
        else
        {
            if (coyoteJump)
            {
                doubleJump = true;
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump", true);
            }

            if (doubleJump && availableJumps > 0)
            {
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump", true);
            }
        }
    }



    void Move(bool crouchFlag)
    {
        // Nếu không trong trạng thái cúi
        if (!crouchFlag)
        {
            // nếu trên đầu có vật cản thì luôn trong trạng thái cúi
            if (Physics2D.OverlapCircle(overheadCheckCollider.position, overheadCheckRadius,groundLayer))
                crouchFlag = true;
        }

        animator.SetBool("Crouch", crouchFlag);
        standingCollider.enabled = !crouchFlag;
        crouchingCollider.enabled = crouchFlag;

        
        // Khai báo biến di chuyển 
        float xVal = dir * speed ;
        // Tăng tốc độ nếu đang chạy
        if (isRunning)
            xVal *= runSpeedModifier;
        // Giảm tốc độ nếu đang cúi
        if (crouchFlag)
            xVal *= crouchSpeedModifier;
       // xác định vận tốc
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        // Gán vận tốc cho Rigidbody
        rb.velocity = targetVelocity;

        // Lật nhân vật khi thay đổi hướng
        if (isFacing && dir < 0 || !isFacing && dir > 0)
        {
            isFacing = !isFacing;
            Vector3 size = transform.localScale;
            size.x = size.x * -1;
            transform.localScale = size;
        }

        // tạo hiệu ứng chuyển động
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }

   

    public void Die()
    {
        isDead = true;
        deathAnimation.enabled = true;
<<<<<<< HEAD
        audioManager.PlaySFX(audioManager.playerDeath);
=======
>>>>>>> origin/main
        animator.SetBool("PlayerDeath", true);
        GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Gem")
        {
<<<<<<< HEAD
            audioManager.PlaySFX(audioManager.collectGem);
=======
>>>>>>> origin/main
            GameManager.Instance.IncreaseScore(10);
            Debug.Log(GameManager.Instance.score);
            collision.gameObject.SetActive(false);
        }
<<<<<<< HEAD
        else if(collision.tag == "DeathBarrier")
        {
            Die();
        }
=======
>>>>>>> origin/main
    }

    public void UpdateScoreUI()
    {       
<<<<<<< HEAD
            scoreText.text = "Điểm: " + GameManager.Instance.score;
            scoreText.gameObject.SetActive(true);
            highScoreText.text = "Điểm kỉ lục: " + GameManager.Instance.highScore;
            highScoreText.gameObject.SetActive(true);
    }

    public void Hurt()
    {
        /*Instantiate(damageEffect, transform.position, Quaternion.identity); // Tạo hiệu ứng*/
        StartCoroutine(DamageEffect());
        StartCoroutine(Recoil()); // Gọi phương thức lùi lại
    }

    private IEnumerator DamageEffect()
    {
        // Thay đổi màu sắc khi nhận sát thương
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f); // Chờ trong 0.1 giây
        spriteRenderer.color = originalColor; // Đổi về màu sắc ban đầu
    }

    private IEnumerator Recoil()
    {
        Vector3 originalPosition = transform.position; // Lưu vị trí ban đầu
        Vector3 recoilPosition = originalPosition - transform.right * recoilDistance; // Tính toán vị trí lùi lại

        // Di chuyển người chơi về phía lùi
        float elapsedTime = 0f;
        float recoilDuration = 0.2f; // Thời gian lùi lại

        while (elapsedTime < recoilDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, recoilPosition, elapsedTime / recoilDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Chờ một khung hình
        }

        transform.position = recoilPosition; // Đảm bảo người chơi kết thúc ở vị trí lùi lại
    }
=======
            scoreText.text = "Score: " + GameManager.Instance.score;
            scoreText.gameObject.SetActive(true);
            highScoreText.text = "High Score: " + GameManager.Instance.highScore;
            highScoreText.gameObject.SetActive(true);
    }

>>>>>>> origin/main

}
