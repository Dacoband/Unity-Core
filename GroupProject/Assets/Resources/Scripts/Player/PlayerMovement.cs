using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Tốc độ di chuyển của nhân vật
    [SerializeField] private float speed = 4.0f;

    // Kiểm tra xem nhân vật có đang đứng trên mặt đất không
    [SerializeField] private bool isGrounded = true;

    // Kiểm tra xem nhân vật có đang thực hiện nhảy đôi không
    [SerializeField] private bool isDoubleJumping = false;

    // Biến cho phép hoặc ngăn cản nhân vật di chuyển
    [SerializeField] public bool IsAllowedToMove { get; set; } = true;

    // Xác định hướng nhân vật (trái/phải)
    [SerializeField] public bool isFacingLeft = false;

    // Tham chiếu đến Animator của nhân vật để điều khiển animation
    [SerializeField] private Animator anim;

    // Tham chiếu đến Rigidbody2D của nhân vật để điều khiển vật lý
    [SerializeField] private Rigidbody2D rb;

    // Khởi tạo và gán các thành phần khi bắt đầu
    void Start()
    {
        // Đặt tag cho đối tượng là "Player"
        gameObject.tag = "Player";

        // Gán Animator cho biến anim
        anim = GetComponent<Animator>();

        // Gán Rigidbody2D cho biến rb
        rb = GetComponent<Rigidbody2D>();
    }

    // Hàm cập nhật gọi mỗi khung hình để xử lý di chuyển và nhảy
    void Update()
    {
        // Nếu nhân vật được phép di chuyển
        if (IsAllowedToMove)
        {
            Move();  // Gọi hàm di chuyển
            Jump();  // Gọi hàm nhảy
        }
    }

    // Hàm chuyển đổi trạng thái di chuyển
    public void TriggerMoveAllowance()
    {
        IsAllowedToMove = !IsAllowedToMove; // Đảo ngược trạng thái cho phép di chuyển
    }

    // Cho phép di chuyển
    public void AllowMoving()
    {
        IsAllowedToMove = true;
    }

    // Ngăn cản di chuyển và dừng animation chạy
    public void DisallowMoving()
    {
        IsAllowedToMove = false;
        anim.SetBool("isRunning", false); // Tắt animation chạy
    }

    // Hàm xử lý di chuyển nhân vật theo hướng trái/phải
    private void Move()
    {
        // Lấy giá trị trục "Horizontal" (trái/phải) từ input
        float move = Input.GetAxis("Horizontal");

        // Cập nhật vận tốc ngang dựa trên giá trị move và speed
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Kiểm tra hướng di chuyển và cập nhật hoạt ảnh tương ứng
        if (move > 0) // Di chuyển sang phải
        {
            isFacingLeft = false; // Đặt hướng không phải trái
            transform.localScale = new Vector3(1, 1, 1); // Hướng nhân vật sang phải
            anim.SetBool("isRunning", true); // Bật animation chạy
        }
        else if (move < 0) // Di chuyển sang trái
        {
            isFacingLeft = true; // Đặt hướng là trái
            transform.localScale = new Vector3(-1, 1, 1); // Hướng nhân vật sang trái
            anim.SetBool("isRunning", true); // Bật animation chạy
        }
        else // Không di chuyển
        {
            anim.SetBool("isRunning", false); // Tắt animation chạy
        }
    }

    // Hàm xử lý nhảy và nhảy đôi
    private void Jump()
    {
        // Kiểm tra nếu người chơi nhấn phím nhảy (Space, W, hoặc UpArrow)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded) // Nếu đang đứng trên mặt đất
            {
                rb.velocity = new Vector2(rb.velocity.x, 5); // Đặt vận tốc nhảy lên
                isGrounded = false; // Đặt trạng thái không còn đứng trên mặt đất
                anim.SetBool("isJumping", true); // Bật animation nhảy
            }

            // Thực hiện nhảy đôi nếu đáp ứng điều kiện
            if (!isGrounded && rb.velocity.y < 0 && !isDoubleJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0); // Đặt vận tốc y = 0 trước khi nhảy đôi
                rb.AddForce(new Vector2(0, 350)); // Thêm lực nhảy đôi
                isDoubleJumping = true; // Đặt trạng thái đang nhảy đôi
                anim.SetBool("isDoubleJumping", true); // Bật animation nhảy đôi
            }
        }

        // Kiểm tra sau khi nhảy đạt đỉnh và đang rơi xuống
        if (rb.velocity.y < 0) // Khi vận tốc y < 0 (rơi xuống)
        {
            anim.SetBool("isJumping", false); // Tắt animation nhảy
            anim.SetBool("isDoubleJumping", false); // Tắt animation nhảy đôi
            anim.SetBool("isFalling", true); // Bật animation rơi
        }

        // Khi vận tốc y = 0, tức là đã chạm đất
        if (rb.velocity.y == 0)
        {
            anim.SetBool("isFalling", false); // Tắt animation rơi
        }
    }

    // Hàm xử lý khi nhân vật va chạm với đối tượng khác
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu va chạm với đối tượng có tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Đặt trạng thái là đứng trên mặt đất
            isDoubleJumping = false; // Đặt lại trạng thái không nhảy đôi
            anim.SetBool("isFalling", false); // Tắt animation rơi
        }
    }
}
