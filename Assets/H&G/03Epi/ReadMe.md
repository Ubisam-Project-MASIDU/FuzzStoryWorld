# 헨젤과 그레텔 - Episode03 & Episode03 Game
***
 - 작성 및 제작 : 유희수
 - 언어 : C#
***
 - Update Log
    1) 2021-08-12 : 초기 개발  
    2) 2021-08-17 : 주석수정
    3) 2021-08-24 : 게임 건너뛰기 기능 추가
    4) 2021-08-25 : 다음씬으로 넘어가는 텀 수정
    5) 2021-08-26 : 소리 수정
***
 - 구동화면 및 내용
![시연1](https://user-images.githubusercontent.com/37494407/131274881-1efc5000-b581-482b-bb0e-104992fd5b15.PNG)

    - 에피소드3에 해당하는 구동화면이다.
    - 헨젤과 그레텔이 부모님의 말씀을 엿듣는 씬이다.

![시연3](https://user-images.githubusercontent.com/37494407/131275554-86eb3b6d-eccb-4961-92a6-c2bed6f159f1.PNG)


    - 에피소드3_게임에 해당하는 구동화면이다.
    - 퍼즐을 다 맞추면 다음씬으로 이동
    
    
***
- H&G (intro) 구성 정보
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/1_03H&G.unity  에서 진행하였다.
  - Script
    - CheckAnswerEpi3.cs : 퍼즐조각들이 모두 알맞은 위치에 들어갔는지 검사하고 다음씬으로 연결해주는 스크립트
    - MatchShape.cs : 퍼즐조각을 놓을때 맞는 위치인지 검사하고 틀리면 다시 원위치시키는 스크립트
    - MoveHansel.cs : 음성을 지원하고 문 버튼을 클릭하면 핸젤이 문쪽으로 이동하는 스크립트
***
