using UnityEngine;

// �G���v���C���[�Ƀ_���[�W��^���鏈�����Ǘ�����N���X
public class EnemyAttack : MonoBehaviour
{
    // �v���C���[�ɗ^����_���[�W�ʁiInspector�Œ����\�j
    [SerializeField] private int damage = 10;

    // �v���C���[���U�����悤�Ƃ��鏈��
    // �����Ƃ��čU���Ώہi�v���C���[��GameObject�j���󂯎��
    public void TryAttack(GameObject target)
    {
        // �v���C���[��Health�Ǘ��X�N���v�g���擾
        // GetComponent�́A�w�肳�ꂽ�^�̃R���|�[�l���g��GameObject����T��Unity�̊�{�I�Ȋ֐�
        //target.GetComponent<PlayerHealth>�͍U���Ώۂ���PlayerHealth�Ƃ����X�N���v�g��T��
        //PlayerHealth�Ƃ����^��playerHealth�Ƃ����ϐ��������Ă���
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();

        // �v���C���[��PlayerHealth�R���|�[�l���g�������Ă���ꍇ�̂݃_���[�W���������s
        // null�`�F�b�N�́A�G���[�h�~�̂��߂̏d�v�ȃX�e�b�v
        if (playerHealth != null)
        {
            // �v���C���[��TakeDamage�֐����Ăяo���ă_���[�W��^����
            playerHealth.TakeDamage(damage);//PlayerHealth�X�N���v�g��TakeDamage���\�b�h���ĂԁBdamage�͈�����TakeDamage�ɐ��l��������
        }
    }
}