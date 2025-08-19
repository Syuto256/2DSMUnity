using UnityEngine;

// �G�L�����̈ړ��ƃv���C���[�ւ̍U���������Ǘ�����N���X
public class EnemyMove : MonoBehaviour
{
    // �G�̈ړ����x�iInspector�Œ����\�j
    [SerializeField] private float moveSpeed = 2f;

    // �ړ��͈͂̍��[�ƉE�[�i���GameObject���g���Ĉʒu���w��j
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    // ���݉E�����Ɉړ����Ă��邩�ǂ����̃t���O
    [SerializeField] private bool movingRight = true;

    // Rigidbody2D�F���������𐧌䂷�邽�߂̃R���|�[�l���g
    private Rigidbody2D rb;

    // SpriteRenderer�F�����ځi�X�v���C�g�j�𔽓]�����邽�߂Ɏg�p
    private SpriteRenderer sprite;

    // �����������i�Q�[���J�n����1�x�����Ă΂��j
    private void Start()
    {
        // Rigidbody2D��SpriteRenderer���擾���Ă���
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // ���t���[���Ă΂�鏈���i�ړ��������Ăяo���j
    private void Update()
    {
        Patrol();
    }

    // �G�̍��E�p�g���[���ړ�����
    private void Patrol()
    {
        // �ړ������ɉ����đ��x��ݒ�i�E�Ȃ�+1�A���Ȃ�-1�j
        float direction = movingRight ? 1f : -1f;

        // Rigidbody2D��linearVelocity���g���Ĉړ��ix�����̂ݕύX�j
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        // �E�[�ɓ��B�����獶�ɔ��]
        if (movingRight && transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;
            sprite.flipX = true; // �X�v���C�g�𔽓]���Č�����ς���
        }
        // ���[�ɓ��B������E�ɔ��]
        else if (!movingRight && transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;
            sprite.flipX = false;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փˑ��肪�v���C���[���ǂ������^�O�Ŕ���
        if (collision.gameObject.CompareTag("Player"))
        {
            // EnemyAttack�R���|�[�l���g���擾���čU���������Ăяo��
            EnemyAttack attack = GetComponent<EnemyAttack>();
            if (attack != null)
            {
                attack.TryAttack(collision.gameObject);
            }
        }
    }
}