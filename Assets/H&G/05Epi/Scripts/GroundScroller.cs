/*
 * - Name : GroundScroller.cs
 * - Writer : 이윤교
 * - Content : 오브젝트(그라운드)가 화면 우측에서 시작해서 화면 좌측으로 넘어가면 비활성화
 * 
 * - HISTORY
 * 2021-08-13 : 초기 개발
 * 2021-08-18 : 코드 주석처리
 * 2021-08-23 : 코드 획일화
 *
 * <Variable>
 * ma_tiles            ground 오브젝트를 담을 SpriteRenderer 선언
 * temp             가장 뒤에 있는 타일을 찾기위해 필요한 임시 변수
 * ma_groundImg        Sprite 배열 선언
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour{
    public SpriteRenderer[] ma_tiles;
    SpriteRenderer temp;
    public Sprite[] ma_groundImg;
    
    void Start(){ 
        temp = ma_tiles[0];                                                                                            // 첫 번째 타일로 초기화
    }

    void Update(){
        // 게임 시작 버튼을 누르면
        if(GameManager.instance.mb_isPlay){
            for (int i = 0; i < ma_tiles.Length; i++){ 
                // 타일 위치의 X좌표가 -6보다 작을 때 가장 뒤에 있는 타일을 찾아서 가장 뒤에 있는 타일의 X좌표보다 1만큼 더 뒤로 보내줌
                if(-6f >= ma_tiles[i].transform.position.x){
                    // 가장 뒤(오른쪽)에 있는 타일을 검색하는 방법
                    for(int j = 0; j < ma_tiles.Length; j++){                                                             // 현재 타일과 변수에 저장된 타일의 X 좌표를 비교하면서
                        if(temp.transform.position.x < ma_tiles[j].transform.position.x){                                 // 현재 타일이 변수가 저장된 타일보다 X좌표가 크면 변수의 타일을 현재 타일로 바꾸어 줌.  
                            temp = ma_tiles[j];
                        }
                    }
                    ma_tiles[i].transform.position = new Vector2(temp.transform.position.x+1, -0.3f);                     // 타일 위치의 X좌표가 -6을 넘어버린 타일은 제일 뒤로 보내줌
                    ma_tiles[i].sprite = ma_groundImg[Random.Range(0,ma_groundImg.Length)];                               // 제일 뒤로 보낸 Sprite를 Sprite 배열 중 한개로 랜덤하게 변경해줌
                }
            }
            for(int i = 0; i < ma_tiles.Length; i++){
                ma_tiles[i].transform.Translate(new Vector2(-1,0) * Time.deltaTime * GameManager.instance.mf_gameSpeed);  // 타일을 좌측으로 이동
            }
        }
    }
}
