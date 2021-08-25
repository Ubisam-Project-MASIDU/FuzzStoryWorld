# 핸젤과그레텔 - Episode13
***
 - 작성 및 제작 : 김명현
 - 언어 : C#
***
 - Update Log
     1) 2021-08-05 : 처음 시작하면 구슬 아이템들이 생성되게 설정
     2) 2021-08-06 : 아이템이 삭제되는 함수 작성
     3) 2021-08-10 : 가로로 아이템이 3개이상 모이면 삭제되게 설정
     4) 2021-08-12 : 세로로 아이템이 3개이상 모이면 삭제되게 설정
     5) 2021-08-17 : 타임아웃 기능 구현
     6) 2021-08-20 : 보물 배경추가, 점수에따라 보물의 크기가 커지게 설정
     7) 2021-08-23 : 시계 에니메이션 추가, 아이템 터질때 이펙트 추가
***
 - 구동화면 및 내용
![구동화면](https://user-images.githubusercontent.com/37494407/130718905-c15fd5c0-45d9-4727-abde-c009e76576bf.png)

    - 에피소드13 구동화면이다.
    - 화면 왼쪽에는 점수를 출력해준다. (아이템이 터질경우 점수가 증가하는 방식)
    - 오른쪽에는 남은 시간을 표현해준다. 시간이 흐를수록 흰 원이 점점 사라진다.
    - 아이템을 드래그하여 3개이상의 같은 모양을 연결해주면 아이템이 터지면서 새로운 아이템이 위에서 떨어져 내려온다.
    
    
***

- H&G (Episode13) 구성 정보
  - Animation
    - Clock.controller : 시계 애니메이션을 연결하기위한 에니메이션 관리파일
    - ClockAnimation.anim : 시계가 빨갛게 커지고 작아지는 애니메이션
    - Default_ClockAnimation.anim : 평상시 기본 애니메이션
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/1_13H&G.unity 에서 진행하였다.
  - Prefab
    - Item1_Orange.prefab : 오렌지색의 구슬 아이템 프리팹이다. SwapItem.cs 파일이 적용되어있다.
    - Item2_Red.prefab : 빨간색의 구슬 아이템 프리팹이다. SwapItem.cs 파일이 적용되어있다
    - Item3_Purple.prefab : 보라색의 구슬 아이템 프리팹이다. SwapItem.cs 파일이 적용되어있다
    - Item4_Blue.prefab : 파랑색의 구슬 아이템 프리팹이다. SwapItem.cs 파일이 적용되어있다
    - Item5_Green.prefab : 초록색의 구슬 아이템 프리팹이다. SwapItem.cs 파일이 적용되어있다
    - Item6_Yellow.prefab : 노랑색의 구슬 아이템 프리팹이다. SwapItem.cs 파일이 적용되어있다
    - Item7_Star.prefab : 별모양의 아이템 프리팹이다. SwapItem.cs 파일이 적용되어있다
  - Script
    - ControlUI.cs : 화면에 비치는 UI들을 관리하기위한 스크립트이다. 그리고 종료시 연결을 지정해준다. Ex) 남은시간, 점수
    - MainScript.cs : 게임 진행에 있어 메인 스크립트이다. 초기아이템 생성, 3개이상 모였는지 검사, 아이템 재생성 타이밍을 정의했다.
    - ManageItem.cs : 아이템을 생성하는 함수와 삭제하는 함수를 작성해둔 함수이다.
    - ManageItemArray.cs : 아이템 배치값을 저장해둔 배열을 관리하는 스크립트이다.
    - ResetButton.cs : 게임 아이템을 모두 삭제하고 다시 생성하는 리셋 버튼 작동을 위한 스크립트이다.
    - SwapItem.cs : 아이템 프리팹들에 적용되는 스크립트이다. 적절한 타이밍에 아이템들이 드래그가 가능한 상태로 해주며, 아이템을 드래그할 경우 어느방향으로 드래그를 하였는지 계산한다.
    - Treasure.cs : 배경화면의 보물 이펙트 관리를 위한 스크립트이다. 점수가 증가하면 보물 이펙트도 점점 커진다. 
    
***


