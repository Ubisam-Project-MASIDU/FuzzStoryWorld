/*
 * - Name : WitchAttack.cs
 * - Writer : 이예은
 * 
 * - Content :
 * 마녀가 헨젤과 그레텔에게 공격하는 것을 표현하는 스크립트 클래스이다.
 * 
 * - History
 * 1) 2021-08-18 : 코드 구현 
 * 2) 2021-08-13 : 주석 작성
 *  
 * - Variable 
 *
 * - Function
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WitchAttack : MonoBehaviour {
    private enum SetBrightness {
        Dark,
        Bright
    }
    public GameObject mgo_HAG;     
    public SpriteRenderer msr_SetBrightness;     
    public GameObject mgo_SkillThunder;     
    public GameObject mgo_SkillThunderPrefab;    
    private bool mb_SetDark = false;
    private bool mb_CoroutineOnce = true;
    private bool mb_SetBright = false;
    public int mn_SetRange = 10;
    private float mf_CheckAttackCoolTime = 0f;
    private int mn_NumThunder = 3;

    void Start() {
        msr_SetBrightness = GameObject.Find("Bright").GetComponent<SpriteRenderer>();
    }

    void Update() {
        mf_CheckAttackCoolTime += Time.deltaTime;
        if (mgo_HAG != null) {
            if(Vector3.Distance(mgo_HAG.transform.position, transform.position) < 6f) {
                MeleeAttack();
                mf_CheckAttackCoolTime = 0f;
            } else if (mf_CheckAttackCoolTime >= 8f) {
                RangedAttack();
                mf_CheckAttackCoolTime = 0f;
                mb_SetBright = true;
            }
            
            if (mb_SetBright && mb_CoroutineOnce) {
                StartCoroutine(SetBright());
                mb_CoroutineOnce = false;
            }
        }
        
    }

    void MeleeAttack() {
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(0).gameObject.SetActive(false);
    }

    void RangedAttack() {
        for (int i = 0; i < mn_NumThunder; i++) {
            Vector3 v3_SetThunderPos = new Vector3(mgo_HAG.transform.position.x + Random.Range(-mn_SetRange, mn_SetRange), 3, mgo_HAG.transform.position.z + Random.Range(-mn_SetRange, mn_SetRange));
            mgo_SkillThunder = Instantiate(mgo_SkillThunderPrefab, v3_SetThunderPos, transform.rotation) as GameObject;
        }
    }
 

    IEnumerator SetBright() {
        Color c_TempColor = msr_SetBrightness.color;
        GetComponent<MoveWitch>().isRangeAttacking = true;
        this.transform.GetChild(1).gameObject.SetActive(true);
        for (int i = 100; i >= 0; i--) {
            if (c_TempColor.a <= 0.7f) {
                c_TempColor.a += Time.deltaTime * 0.8f;               //이미지 알파 값을 타임 델타 값 * 0.01
            }
            msr_SetBrightness.color = c_TempColor;
            yield return null;
        }
        Debug.Log("Dark");
        yield return new WaitForSeconds(1f);
        

        for (int i = 100; i >= 0; i--) {
            if (c_TempColor.a >= 0f) {
                c_TempColor.a -= Time.deltaTime * 0.8f;               //이미지 알파 값을 타임 델타 값 * 0.01
            }
            msr_SetBrightness.color = c_TempColor;
            yield return null;
        }
        yield return new WaitForSeconds(0.6f);
        GetComponent<MoveWitch>().isRangeAttacking = false;
        mb_SetBright = false;
        mb_CoroutineOnce = true;
        Debug.Log("Bright");
        this.transform.GetChild(1).gameObject.SetActive(false);
        yield return null;

    }
}