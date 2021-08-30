# 헨젤과 그레텔 - Episode9
***
 - 작성 및 제작 : 유희수
 - 언어 : C#

***
 - Update Log
      1) 2021-08-17 : 초기 개발
      2) 2021-08-23 : 코드 획일화 및 주석처리
      3) 2021-08-30 : 리드미 초기 작성
***
 - 구동화면 및 내용
<img src = "https://user-images.githubusercontent.com/76957700/131277581-0e135ba7-491a-4459-8fcd-81b63da0043b.png" width="500" height="250">
 
<img src = "https://user-images.githubusercontent.com/76957700/131277934-ec31a0b7-931b-4b50-be6f-aadc7d9144e7.png" width="500" height="250">

<img src = "https://user-images.githubusercontent.com/76957700/131278319-84ad3c38-7b5c-44d3-b7a6-d462ce78a5b0.png" width="500" height="250">

<img src = "https://user-images.githubusercontent.com/76957700/131278354-9a58504f-218d-43be-983e-355e9c0b259e.png" width="500" height="250">


    - 에피소드9의 스토리 진행화면이다.
    - 스토리 진행 후, 배경이 어두워진다.
    - 배경이 어두워지면 오브젝트 6개를 클릭하라는 음성이 나온다.
    - 오브젝트를 클릭하면 헨젤과 그레텔이 오브젝트 뒤로 숨고, 마녀가 곧바로 따라간다.
    - 6개의 오브젝트를 모두 클릭하면 마녀에게 헨젤과 그레텔이 잡히고 마녀의 집으로 데려간다. 
    - 집으로 데려가면 다음씬으로 이동한다. 
    
***
- H&G (Episode5) 구성 정보
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/1_09H&G.unity 에서 진행하였다.
  - Prefab
    - vibrate.prefab

  - Script
    - SceneControl.cs : Epi9에서 진행되는 스토리의 메인 흐름과, 튜토리얼을 진행한다.
    - ObjectClick.cs : SceneControl 클래스가 끝나면 오브젝트를 클릭해서 헨젤과 그레텔이 오브젝트 뒤로 숨고, 마녀가 숨은 아이들을 찾는다. 
***

