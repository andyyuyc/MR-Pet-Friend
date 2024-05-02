using UnityEngine;

public class PetFollower : MonoBehaviour
{
    public Transform playerHead; // ���ͷ����Transform
    public float distance = 2.0f; // ���ﹷ����ҵľ���
    public float angleOffset = -30.0f; // ���ﹷ�������ǰ���ĽǶ�ƫ��
    public Animator petAnimator; // ���ﹷ��Animator���
    public float smoothTime = 0.3f; // ƽ���ƶ���ʱ��

    private float movingThreshold = 0.1f; // ���ﹷ�ƶ�����С������ֵ����������
    private Vector3 velocity = Vector3.zero; // ����ƽ���ƶ����ٶ�����

    // ������ƫ������
    public float randomPositionOffset = 0.5f; // ���ƫ����
    private Vector3 randomOffset; // ��ǰ���ƫ��

    void Start()
    {
        if (petAnimator == null)
        {
            // ���Ի�ȡAnimator���
            petAnimator = GetComponent<Animator>();
        }
        // ��ʼ�����ƫ��
        UpdateRandomOffset();
    }

    void UpdateRandomOffset()
    {
        randomOffset = new Vector3(Random.Range(-randomPositionOffset, randomPositionOffset), 0, Random.Range(-randomPositionOffset, randomPositionOffset));
    }

    void Update()
    {
        if (playerHead != null && petAnimator != null)
        {
            // �����µ�λ��
            Vector3 forward = playerHead.forward;
            forward.y = 0; // ���Դ�ֱ������������ˮƽ����
            forward.Normalize(); // ���±�׼��

            Quaternion rotation = Quaternion.Euler(0, angleOffset, 0);
            Vector3 targetPosition = playerHead.position + rotation * forward * distance + randomOffset;
            targetPosition.y = transform.position.y; // ����ԭ�еĸ߶Ȳ���

            // �����ƶ�ǰ���λ�ò�
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            // ������ﹷ��Ҫ�ƶ�
            if (distanceToTarget > movingThreshold)
            {
                // ���ö���״̬Ϊ�ܲ�
                petAnimator.SetBool("IsRunning", true);

                // ƽ���ƶ����ﹷ���µ�λ��
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }
            else
            {
                // ���ö���״̬Ϊ��ֹ
                petAnimator.SetBool("IsRunning", false);
            }

            // ��ѡ��ʹ���ﹷ�������
            Vector3 lookAtPosition = playerHead.position;
            lookAtPosition.y = transform.position.y; // ȷ��ֻ��ˮƽ������תͷ��
            transform.LookAt(lookAtPosition);

            // ��һ����ʱ������������ƫ�ƣ���ģ�����Ȼ���ƶ�
            if (Random.Range(0f, 1f) < 0.1f) // ��Լ10%�ļ��ʸ���ƫ��
            {
                UpdateRandomOffset();
            }
        }
    }
}