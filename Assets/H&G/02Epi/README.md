# 헨젤과 그레텔 - Episode2
***
 - 작성 및 제작 : 유희수
 - 언어 : C#
***
 - Update Log
      1) 2021-08-3 : 초기 개발
      2) 2021-08-12 : 코드 획일화 및 주석처리
      3) 2021-08-20 : 리드미 초기 작성
***
 - 구동화면 및 내용
<img src = "https://user-images.githubusercontent.com/76957700/130374352-308f13db-34a2-47bf-a2a6-3a161cd66043.png" width="450" height="220">
 
<img src = "https://user-images.githubusercontent.com/76957700/130374458-97547935-7eff-4042-bec2-e6bce9524142.png" width="450" height="220">
 
<img src = "https://user-images.githubusercontent.com/76957700/130374485-a65f09cf-55d0-4f51-a619-6a7314be03c0.png" width="450" height="220">
 
<img src = "https://user-images.githubusercontent.com/76957700/130374653-73d8065e-8368-4076-8132-9b4753a43b92.png" width="450" height="220">

<img src = "https://user-images.githubusercontent.com/76957700/130374689-16173ff8-ac6b-4a58-b7bf-7d6583163d3d.png" width="450" height="220">

<img src = "https://user-images.githubusercontent.com/76957700/130374711-55e5cf84-7f63-447a-a970-c244b6216a54.png" width="450" height="220">

<img src = "https://user-images.githubusercontent.com/76957700/130374738-d0483a2c-5e54-4492-8abf-bd71bb07ec1f.png" width="450" height="220">






    - 에피소드2의 스토리 진행화면이다.
    - 스토리 진행 후 문을 클릭하면 플레이어가 문으로 이동한다.
    - 문으로 이동하는 튜토리얼 진행 후 스토리 진행한다.
    - 스토리 진행이 끝나면 에피소드2의 퍼즐 맞추기 게임 플레이 버튼이 나온다.
    - 퍼즐 조각이 랜덤으로 섞여있고, 퍼즐 조각을 모두 맞추면 게임이 끝난다.
    - 게임이 끝나면 "You Win" 텍스트가 나오고 다음 씬으로 이동한다. 
***
- H&G (Episode5) 구성 정보
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/1_02H&G.unity 에서 진행하였다.
  - Prefab
    - popup.prefab : 게임을 시작할 화면의 플레이 버튼 프리팹이다.

  - Script
    - DoorClickEvent.cs : Epi2에서 진행되는 스토리의 메인 흐름과, 튜토리얼을 진행한다.
    - RandomPuzzles.cs : 랜덤으로 퍼즐 조각들이 섞여 나오는 기능을 수행하는 스크립트이다.
    - CheckAnswer.cs : 각 위치에 맞는 퍼즐 조각이 들어갔는지 확인하고, 오답이면 퍼즐 조각을 다시 제자리로 돌아가게 하고 정답이면 정답 위치에 조각을 맞춰준다.
    - MatchPuzzle.cs : 모든 퍼즐조각이 맞춰졌는지 맞춰진 퍼즐 개수를 통해 확인하고 다 맞춰지면 다음 씬으로 넘어가게한다.
***


