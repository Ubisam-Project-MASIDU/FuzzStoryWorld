# 헨젤과 그레텔 - Episode8
***
 - 작성 및 제작 : 이윤교
 - 언어 : C#
***
 - Update Log
   1) 2021-08-10 : 초기 개발
   2) 2021-08-11 : 코드 획일화 및 주석처리
   3) 2021-08-19 : 효과음 재생 추가
   4) 2021-08-20 : 리드미 초기 작성
***
 - 구동화면 및 내용
<img src="https://user-images.githubusercontent.com/73592778/130159994-459ab3eb-840c-462c-a3a6-9d70038785e9.png" width="500" height="220">
<img src="https://user-images.githubusercontent.com/73592778/130160011-9c09c19f-96df-4cfd-ae51-1ba80ead210e.png" width="500" height="220">

    - 에피소드8에 해당하는 장면과 미니 게임의 구동화면이다.
    - 에피소드8 내용을 tts를 통해 읽어준다.
    - 에피소드8의 미니게임을 시작하면 헨젤과 그레텔이 먹고싶어하는 사탕의 종류가 말풍선 위에 띄어지게된다.
    - 헨젤과 그레텔이 먹고싶어하는 사탕의 종류를 과자집에서 드래그해서 헨젤과 그레텔 입으로 드래그해서 먹여준다.
    - 과자집에 있는 사탕을 다 먹게되면 게임이 끝난다.
    - 게임이 끝나면 다음 씬으로 넘어가게 된다.
***
- H&G (Episode8) 구성 정보
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/1_08H&G.unity 에서 진행하였다.
  - Script
    - Start_Epi8_Game.cs : Epi8 미니게임 시작
    - CandyControl.cs : 배열로 남은 아이템 관리, 이 배열을 통해 랜덤으로 정답을 정하는 함수 및 아이템이 바뀌었는지 flag로 관리
    - DragCandy.cs : 마우스 이벤트 스크립트, 마우스 드래그시 오브젝트가 따라 움직이게 수정
    - RandomCandy.cs : 사탕(아이템)을 중복되지않게 랜덤으로 보여줌
    - CheckAnswer.cs : 충돌 시 정답 확인 및 정답일 경우 오브젝트 삭제

***


