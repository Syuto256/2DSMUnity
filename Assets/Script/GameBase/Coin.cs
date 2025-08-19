using UnityEngine;

// �v���C���[���擾�ł���R�C���̏������Ǘ�����N���X
public class Coin : MonoBehaviour
{
    // ���̃R�C�������Z����X�R�A�̒l�iInspector�Œ����\�j
    [SerializeField] private int coinValue = 10;

    // ���̃I�u�W�F�N�g�����̃R�C���̃g���K�[�ɓ������Ƃ��ɌĂ΂��֐�
    // �����̃I�u�W�F�N�g��Collider�́uIs Trigger�v�ɐݒ肳��Ă���K�v������
    void OnTriggerEnter2D(Collider2D other)
    {
        // �ڐG�����I�u�W�F�N�g���v���C���[���ǂ������^�O�Ŕ���
        // �^�O��Inspector�Őݒ�ł��鎯�ʃ��x���BCompareTag()�͍����ň��S�Ȕ�����@
        if (other.CompareTag("Player"))
        {
            // �X�R�A�Ǘ��N���X�̃C���X�^���X��ʂ��ăX�R�A�����Z
            // �V���O���g���p�^�[���ɂ��A�ǂ�����ł�ScoreManager.Instance�ɃA�N�Z�X�\
            ScoreManager.Instance.AddScore(coinValue);

            // �R�C�����擾������A�Q�[����ʂ�������i�j������j
            Destroy(gameObject);
        }
    }
}