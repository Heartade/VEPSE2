using UnityEngine;
using Gvr.Internal;
using System.Collections;

public class Bege : InteractingGameObject
{

    float alpha = 1f;//투명도
    float time = 0f;//기준 시간
    public Material m;

    public void onTrigger()
    {
        if (!base.isTrigger)
        {
            base.isTrigger = true;
            base.onTrigger();
            time = Time.time;//기준시간 설정, 플래그 설정
        }
    }

    void Start()
    {
        m.color = new Color(1f, 1f, 1f, 1f);
    }

    void Update()
    {
        if (time != 0f)
        {
            float dt = Time.time - time;//시간 차 계산
            alpha = 1 - dt;//1초동안 90->0으로
            m.color = new Color(1f, 1f, 1f, alpha);
            if (alpha < 0)
            {
                time = 0;//플래그 해제
                gameObject.transform.Translate(new Vector3(0, 100, 0));
            }
        }
    }
}
