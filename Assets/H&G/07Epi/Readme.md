# 헨젤과 그레텔 - Episode7
***
 - Readme 작성: 이예은
 - 씬 제작 및 코드 작성 : 최대준
 - 언어 : C#
***
 - Update Log
      1) 2021-08-09 : 초기 개발
      2) 2021-08-10 : 코드 획일화 및 주석처리
      3) 2021-08-19 : 효과음 재생 추가
      4) 2021-08-30 : 리드미 초기 작성
***
 - 구동화면 및 내용
<img src="https://user-images.githubusercontent.com/88296511/131270379-f260534f-6ea6-4684-b99b-f7631fd6f7b5.jpg" width="500" height="220">

<img src="https://user-images.githubusercontent.com/88296511/131270386-11688fd6-f1f2-4307-871b-6c87b38f4fa0.jpg" width="500" height="220">


    - 에피소드7 새 따라가기 게임의 구동화면이다.
    - 씬이 시작되면 새가 특정 위치로 날라간다.
    - 화면을 클릭하면 플레이어가 새 위치(클릭한 위치)로 이동한다.
    - 과자집에 도착한 새를 마지막으로 따라가면 씬이 끝난다. .
***
- H&G (Episode5) 구성 정보
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/1_07H&G.unity 에서 진행하였다.
  - Prefab
    - MovingBird.prefab : 움직이는 새 프리팹이다.
  - Script
    - ChangeNextScene.cs : 플레이어가 과자집에 도착하면 Epi7에서 다음씬으로 넘어감 
    - ClickAnim.cs : 새를 클릭하라는 손가락 표시가 깜박이는 동작 정의한다.
    - EpisodeController.cs : Epi7에서 진행되는 게임의 메인 흐름을 조절한다.
    - FlyBird.cs : 새가 날아가는 것처럼 동작을 구현한 스크립트 코드이다.
    - MoveHAG.cs : 화면을 터치시에 헨젤과 그레텔 오브젝트가 새를 따라가는 동작을 정의한 클래스이다. 

***
