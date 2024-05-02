using UnityEngine;

public class PetFollower : MonoBehaviour
{
    public Transform playerHead; // 玩家头部的Transform
    public float distance = 2.0f; // 宠物狗与玩家的距离
    public float angleOffset = -30.0f; // 宠物狗相对于正前方的角度偏移
    public Animator petAnimator; // 宠物狗的Animator组件
    public float smoothTime = 0.3f; // 平滑移动的时间

    private float movingThreshold = 0.1f; // 宠物狗移动的最小距离阈值来触发动画
    private Vector3 velocity = Vector3.zero; // 用于平滑移动的速度向量

    // 添加随机偏移属性
    public float randomPositionOffset = 0.5f; // 随机偏移量
    private Vector3 randomOffset; // 当前随机偏移

    void Start()
    {
        if (petAnimator == null)
        {
            // 尝试获取Animator组件
            petAnimator = GetComponent<Animator>();
        }
        // 初始化随机偏移
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
            // 计算新的位置
            Vector3 forward = playerHead.forward;
            forward.y = 0; // 忽略垂直分量，保持在水平面上
            forward.Normalize(); // 重新标准化

            Quaternion rotation = Quaternion.Euler(0, angleOffset, 0);
            Vector3 targetPosition = playerHead.position + rotation * forward * distance + randomOffset;
            targetPosition.y = transform.position.y; // 保持原有的高度不变

            // 计算移动前后的位置差
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            // 如果宠物狗需要移动
            if (distanceToTarget > movingThreshold)
            {
                // 设置动画状态为跑步
                petAnimator.SetBool("IsRunning", true);

                // 平滑移动宠物狗到新的位置
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }
            else
            {
                // 设置动画状态为静止
                petAnimator.SetBool("IsRunning", false);
            }

            // 可选：使宠物狗面向玩家
            Vector3 lookAtPosition = playerHead.position;
            lookAtPosition.y = transform.position.y; // 确保只在水平方向旋转头部
            transform.LookAt(lookAtPosition);

            // 在一定的时间间隔后更新随机偏移，以模拟更自然的移动
            if (Random.Range(0f, 1f) < 0.1f) // 大约10%的几率更新偏移
            {
                UpdateRandomOffset();
            }
        }
    }
}