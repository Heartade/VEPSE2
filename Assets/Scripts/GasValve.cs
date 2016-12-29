using UnityEngine;
using System.Collections;

public class GasValve : InteractingGameObject {

    float deg = 90f;//z방향 각도
    float time = 0f;//기준 시간

    public void onTrigger()
    {
        if (!base.isTrigger)
        {
            base.isTrigger = true;
            base.onTrigger();
            time = Time.time;//기준시간 설정, 플래그 설정
        }
    }

    void Update()
    {
        if (time != 0f)
        {
            float dt = Time.time - time;//시간 차 계산
            deg = 90 - 90 * dt;//1초동안 90->0으로
            gameObject.transform.rotation = Quaternion.Euler(0, 0, deg);
            if (deg < 0)
            {
                deg = 0;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, deg);
                time = 0;//플래그 해제
            }
        }
    }
}
