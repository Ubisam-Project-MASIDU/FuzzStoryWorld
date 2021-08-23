# 헨젤과 그레텔 - daejune_yeeun_intro
***
 - 작성 및 제작 : 이예은, 최대준
 - 언어 : C#
***
 - Update Log
    1) 2021-08-05 : 초기 개발
    2) 2021-08-06 : 개발 수정
    3) 2021-08-09 : 코드 획일화 및 주석처리
    4) 2021-08-20 : 리드미 초기 작성
***
 - 구동화면 및 내용
<img src = "https://user-images.githubusercontent.com/88296511/130384915-6b46abc8-3f90-4c24-aa1f-2e690d97bb08.JPG" width="450" height="220">
<img src = "https://user-images.githubusercontent.com/88296511/130385021-b2e79d4b-70cd-4796-bb78-e6e178ef5477.JPG" width="450" height="220">
<img src = "https://user-images.githubusercontent.com/88296511/130385061-b3ad33b6-56d0-4be0-93a8-6e213fee8df6.JPG" width="450" height="220">





    - intro에 해당하는 스토리 진행 화면이다.
    - 헨젤과 그레텔이 앞 쪽으로 걸어 나온다.
    - 책으로 점프해서 들어간다.
    - 이 때 들어가는 효과(풍덩)가 나온다.
***
- H&G (intro) 구성 정보
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/daejus_yeeun_intro.unity 에서 진행하였다.
  - Script
    - GenerateEffect.cs : 해당 에피소드에 나오는 책으로 들어갈 때 풍덩 효과가 나오도록 만든 스크립트이다.
    - JumpHG.cs : 헨젤과 그레텔이 일정거리 앞으로 걸어나와 책으로 점프하는 스크립트이다.

***
