using UnityEngine;
using System.Collections;

public class PlayerMoveBehavior : MonoBehaviour {

    int state = 0;//0이면 아무것도 아닌 상태(초기 상태), 1이면 정지, 2이면 걷기, 3이면 숙이기(겉으로는 안 보임, 시야만 변경)
    float height = 1;//y좌표
    long time=0;//눈높이 진동 기준 시간

    void Update()
    {
        Vector3 oldPos = transform.position;
        Vector3 oldRot = transform.rotation.eulerAngles;
        switch (state)
        {
            case 0:
                height = 1;
                oldPos = new Vector3(0, 1, 0);
                transform.position = oldPos;
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

}
