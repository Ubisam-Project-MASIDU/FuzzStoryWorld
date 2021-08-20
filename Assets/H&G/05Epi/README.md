# 헨젤과 그레텔 - Episode5
***
 - 작성 및 제작 : 이윤교
 - 언어 : C#
***
 - Update Log
      1) 2021-08-13 : 초기 개발
      2) 2021-08-18 : 코드 획일화 및 주석처리
      3) 2021-08-19 : 효과음 재생 추가
      4) 2021-08-19 : 리드미 초기 작성
***
 - 구동화면 및 내용
<img src="https://user-images.githubusercontent.com/73592778/130014820-38b09cb8-684c-4817-8022-e1c0a163c441.png" width="500" height="220">

<img src="https://user-images.githubusercontent.com/73592778/130014795-f271d0ca-a856-4415-849b-b46765ce9a7c.png" width="500" height="220">

<img src="https://user-images.githubusercontent.com/73592778/130014693-799f33c2-a16c-414b-b1ec-0700e5aab678.png" width="500" height="220">

    - 에피소드5 런 게임의 구동화면이다.
    - 미니게임을 시작하려면 Start 버튼을 누른다.
    - 화면을 클릭하면 플레이어가 점프를 한다.
    - 조약돌이 다가오면 그 타이밍에 맞춰서 점프를 하게 하여 조약돌을 먹게한다.
    - 주어진 조약돌을 다 먹게 되면 게임이 끝난다.
    - 게임이 끝나면 Finish 버튼이 나오고 이 버튼을 누르면 다음 씬으로 넘어가게 된다.
***
- H&G (Episode5) 구성 정보
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/1_05H&G.unity 에서 진행하였다.
  - Prefab
    - Gratel_Run.prefab : 뛰는 모습의 그레텔 프리팹이다.
    - GoldCoin.prefab : 금색의 조약돌 프리팹이다.
    - SliverCoin.prefab : 은색의 조약돌 프리팹이다.
    - BronzeCoin.prefab : 동색의 조약돌 프리팹이다.
  - Script
    - GameManager.cs : Epi5에서 진행되는 게임의 메인 흐름을 조절한다.
    - BackgroundScroller.cs : 달리는 효과를 증대시키기 위해 뒷 배경이 화면 우측에서 시작해서 화면 좌측으로 넘어가면 비활성화 한다.
    - GroundScroller.cs : 달리는 효과를 증대시키기 위해 바닥이 화면 우측에서 시작해서 화면 좌측으로 넘어가면 비활성화 한다.
    - PlayerController.cs : 달리는 플레이어의 역할을 관리한다.
    - RespawnManager.cs : 게임을 시작할 때 조약돌을 미리 여러개를 생성하고 필요할 때 마다 활성화를 시키고 필요가 없어지면 비활성화를 시킨다.
    - RockBase.cs : 오브젝트(조약돌)가 화면 우측에서 시작해서 화면 좌측으로 넘어가면 비활성화 한다.
***


