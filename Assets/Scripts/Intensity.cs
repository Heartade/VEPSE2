using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// 이 코드는 존나 중요한 코드입니다.
/// 멍청한 유저들을 위해 지진 규모에 따른 피해를 알려주거든요.
/// 이 텍스트는 규모 선택 UI에 표시됩니다.
/// 
/// </summary>


public class Intensity : MonoBehaviour {
    public float value;
    public Text helperText;
    public Text valueText;
    public float maxValue;
    public float minValue;
    private string[] script = //스크립트입니다. 위대하신 세종대왕님의 도움으로 이해할 수 있습니다.
    {
        "", //공백 텍스트 (Placeholder) "a-b"로 표기된 진도는 반개구간 [a,b)를 따릅니다.
        "지진계에 의해서만 탐지가 가능한 수준입니다.", //진도 3 미만
        "진동이 느껴지지만 피해는 거의 없습니다.", //진도 3-4
        "방 안의 물건들이 흔들리지만, 심한 피해는 없습니다.", //진도 4-5
        "부실 건물은 붕괴할 수도 있습니다.", //진도 5-6
        "최대 160km 범위에서 건물이 파괴됩니다.", //진도 6-7
        "대규모의 광범위한 피해를 입힙니다.", //진도 7-8
        "수백 km 범위에 극심한 피해를 입힙니다.", //진도 8-9
        "수천 km 범위를 초토화합니다." //진도 9 이상
    };
	// Use this for initialization
	void Start () {
        SetHelperText(this.helperText);
        SetValueText(this.valueText);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetIntensity(float value) { //규모 값을 조정합니다.
        this.value = value;
    }

    public void AddIntensity(float addition) { //규모 값을 addition만큼 더합니다.
        float newVal = this.value + addition;
        if (newVal <= maxValue)
            this.value = newVal;
    }

    public void DeductIntensity(float deduction) { //규모 값을 deduction만큼 뺍니다.
        float newVal = this.value -deduction;
        if (newVal >= minValue)
            this.value = newVal;
    }

    public void SetHelperText(Text helperText) { //규모 값에 따라 helperText의 텍스트 값을 script에서 가져와 사용합니다.
        if (this.value < 3)
            helperText.text = this.script[1];
        else if (this.value < 4)
            helperText.text = this.script[2];
        else if (this.value < 5)
            helperText.text = this.script[3];
        else if (this.value < 6)
            helperText.text = this.script[4];
        else if (this.value < 7)
            helperText.text = this.script[5];
        else if (this.value < 8)
            helperText.text = this.script[6];
        else if (this.value < 9)
            helperText.text = this.script[7];
        else
            helperText.text = this.script[8];
    }

    public void SetValueText(Text valueText) {
        valueText.text = this.value.ToString();
    }
}
