using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���E�̓��͕������擾
        float horizontalInput = Input.GetAxis("Horizontal");

        // ���E�̈ړ��A�j���[�V�����𐧌�
        bool isMoving = Mathf.Abs(horizontalInput) > 0.01f;
        animator.SetBool("IsMoving", isMoving);

        // �L�����N�^�[�̌��������E�̓��͂ɉ����ĕύX
        if (horizontalInput > 0)
        {
            // �E������
            transform.localScale = new Vector3(6, 6, 1);
        }
        else if (horizontalInput < 0)
        {
            // ���������iX���̃X�P�[���𔽓]�j
            transform.localScale = new Vector3(-6, 6, 1);
        }

        // �W�����v�����ǂ����𔻒�
        bool isJumping = Mathf.Abs(rb.linearVelocity.y) > 0.5f;
        animator.SetBool("IsJumping", isJumping);

        // ���������ǂ����𔻒�
        bool isFalling = rb.linearVelocity.y < -0.5f;
        animator.SetBool("IsFalling", isFalling);
    }
}