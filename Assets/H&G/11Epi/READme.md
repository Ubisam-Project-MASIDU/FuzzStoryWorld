# 헨젤과 그레텔 - Episode11

***
 - 작성 및 제작 : 이병권
 - 언어 : C#
***

  - Update Log
    1) 2021-08-04 : 초기 개발
    2) 2021-08-10 : 코드 수정 및 주석처리
    3) 2021-08-22 : 리드미 초기 작성
***
 - 구동화면 및 내용
1) ![MainPic](https://user-images.githubusercontent.com/88296556/130382747-edd5e12d-fd47-4fff-a934-33cda5f95248.jpg)
2) ![MainGamePic](https://user-images.githubusercontent.com/88296556/130382749-32a9856d-2291-4b80-b488-a6938ea49cf9.jpg)
3) ![IfDragBoneStickPic](https://user-images.githubusercontent.com/88296556/130382769-21fc17a2-676f-4816-892c-6dc41b101fcb.jpg)

    - 에피소드11에 해당하는 구동화면이다.
    - 헨젤과 그레텔이 마녀에게 잡혀 지하에 갇혀 있고 마녀에게 잡어먹히지 않기 위해 손 대신에 뼈다귀를 내미는 장며니다
    - 에피소드11 미니게임을 시작을 하기에 앞서 본문을 먼저 읽어준다.
    - 그후 미니게임을 시행한다.
    - 미니게임은 마녀에게 손을 내미는 대신에 뼈다귀를 드래그 하여 가져다 준다.
    - 뼈다귀는 두개로 구성되며 헨젤, 그레텔이 하나씩 자기고 있다.
    - 만약 뼈다귀를 마녀에게 주면 충돌이 일어나며 사라지게 된다.
    - 게임이 끝나기 위해서는 뻐다귀를 모두 주어야 한다.
***
- H&G (Episode4) 구성 정보
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/1_11H&G.unity 에서 진행하였다.
  - Scripts
    - CollideWitch.cs : 헨젤과 그레텔이 가지고 있는 뼈다귀와 마녀가 만났을때 사라지게 한다.
    - DragBoneStick.cs : 마우스로 뼈다귀를 움직을 수 있고, 원하는 곳에 위치하게 할 수 있으며 만약 잘 못 장소에 놓게 되면 헨젤과 그레텔 손으로 돌아가게 한다.
    - TurnPage.cs : 만약 뻐다귀를 마녀에게 다 주게 되면 다음 페이지로 자동으로 넘어가게 한다.
    - SoundEffectes.cs : 뼈다귀를 마녀에게 주었을 때 사라지는데 그때 소리가 나게 한다.
***
