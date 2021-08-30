# 헨젤과 그레텔 - Episode12
***
 - 작성 및 제작 : 이예은, 최대준
 - 언어 : C#
***
 - Update Log
      1) 2021-08-12 : 초기 개발
      2) 2021-08-13 : 개발 수정
      3) 2021-08-19 : 효과음 재생 추가
      4) 2021-08-30 : 코드 획일화 및 주석처리
      5) 2021-08-30 : 리드미 초기 작성
***
 - 구동화면 및 내용
<img src="https://user-images.githubusercontent.com/88296511/131273316-ca95c098-d6e4-469b-a6ea-7bdf7d494b41.jpg" width="500" height="220">
<img src="https://user-images.githubusercontent.com/88296511/131273332-e1f6ea6a-03f9-40f6-bbd6-f8961a3adf36.jpg" width="500" height="220">
<img src="https://user-images.githubusercontent.com/88296511/131273407-6cb08a4b-e5b3-4646-b3fe-e63e03e1d483.jpg" width="500" height="220">
<img src="https://user-images.githubusercontent.com/88296511/131273375-c97ed370-fa45-4a04-9889-93932134fbda.jpg" width="500" height="220">
<img src="https://user-images.githubusercontent.com/88296511/131273435-17ba6ef9-003f-4270-8b2f-25194256d8e8.jpg" width="500" height="220">
<img src="https://user-images.githubusercontent.com/88296511/131273487-d10a127c-3c4d-468f-ab93-72ff156247dc.jpg" width="500" height="220">

    - 에피소드12 마녀 무찌르기 게임의 구동화면이다.
    - 씬이 시작되면 마녀를 클릭해 공격한다.
    - 마녀의 번개 공격을 피해야 한다.
    - 마녀의 체력이 0이 되면 헨젤과 그레텔은 보물섬으로 걸어간다.
    - 보물섬에 도착하면 다음 미니게임 start 버튼이 나오고 이 버튼을 누르면 다음 게임으로 넘어가게 된다.
***
- H&G (Episode5) 구성 정보
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/1_12H&G.unity 에서 진행하였다.
  - Prefab
    - BonePrefeb.prefab : 마녀를 공격하는 뼈 프리팹이다.
    - CFX3_Fire.prefab : 마녀가 헨젤과 그레텔을 공격할 때 나오는 효과 프리팹이다.
    - CFX4 Fire.prefab : 마녀가 헨젤과 그레텔을 공격할 때 나오는 번개 프리팹이다.
    - mark.prefab : 헨젤과 그레텔이 움직일 곳을 표시하는 프리팹이다.
  - Script
    - ChangeNextScean.cs : 플레이어가 보물섬에 도착해 다음 씬 게임 start 버튼을 누르면 다음 씬으로 넘어간다.
    - HAGAttack.cs : 마녀를 누르면 뼈가 마녀에게 날라가 마녀를 공격하는 스크립트 코드이다. 
    - HAGMove.cs : 헨젤과 그레텔이 마우스 클릭에 따라 움직임을 표현하는 스크립트 클래스이다.
    - HPbar.cs : 게임 오브젝트들의 체력을 나타내는 HP바를 표현한 스크립트이다. 
    - MoveWitch.cs : 마녀가 헨젤과 그레텔을 추적하며 뼈를 맞으면 뼈가 사라진다.
    - NotifyPlayerDanger.cs : 마녀의 공격을 헨젤과 그레텔이 맞으면 체력이 감소한다. 
    - ReplayScene12.cs : 헨젤과 그레텔이 졌을 경우 Replay버튼이 활성화되고 이를 누를 시 게임 재시작한다. 
    - Scene12Controller.cs : Epi12에서 진행되는 게임의 메인 흐름을 조절한다.
    - Status.cs : 마녀, 헨젤과 그레텔의 HP바의 상태를 조절한다.
    - WitchAttack.cs : 마녀가 헨젤과 그레텔에게 공격하는 것을 표현하는 스크립트 클래스이다.
***
