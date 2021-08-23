# 헨젤과 그레텔 - Episode10

***
 - 작성 및 제작 : 이병권
 - 언어 : C#
***

  - Update Log
    1) 2021-08-03 : 초기 개발
    2) 2021-08-10 : 코드 수정 및 주석처리
    3) 2021-08-22 : 리드미 초기 작성
***
 - 구동화면 및 내용
1) ![MainPic](https://user-images.githubusercontent.com/88296556/130381014-93ccc9f1-2621-4f32-9a85-e99ef6e55bfd.jpg)
2) ![MainGamePic](https://user-images.githubusercontent.com/88296556/130381016-6bf892dc-cd4c-4bd7-9b80-6ca133a8c0fb.jpg)
3)![IfMonsterDiePic](https://user-images.githubusercontent.com/88296556/130381166-c5cf0b45-2d4a-4c5d-a752-2c03976c8273.jpg)



    - 에피소드10에 해당하는 구동화면이다.
    - 헨젤과 그레텔이 마녀에게 잡혀 지하에 갇혀 있고 그곳에서 청소를 하는 장면이다.
    - 에피소드10 시작을 하기에 앞서 본문을 먼저 읽어준다.
    - 그후 미니게임을 시행한다.
    - 미니게임은 청소를 하는 장면 속 아이들의 흥미를 이끌기 위해 몬스터(쓰레기모양)들을 넣어 하나씩 제거해 가며 청소를 하는 장면이다.
    - 청소를 하기 위해서는 몬스터(쓰레기모양)들을 두번씩 클릭해야 한다. (몬스터(쓰레기모양)들의 최대 채력은 2로 한정되어 있다.)
    - 게임이 끝나기 위해서는 6마리의 몬스터(쓰레기모양)들을 모두 제거해야 한다.
***
- H&G (Episode4) 구성 정보
  - Image
    - 구현에 필요한 이미지 파일들은 모두 FuzzStoryWorld/Assets/Image/ 에서 참고하였다.
  - Scene
    - Scene파일의 경우에도 FuzzStoryWorld/Assets/Scenes/1_10H&G.unity 에서 진행하였다.
  - Prefab
    - GMonster1.prefab : 화면에서 제일 먼저 보이는 초록색 패트병 몬스터에 해당된다.
    - GMonster2.prefab : 화면에서 두 번째로 보이는 노란색 캔 몬스터에 해당된다.
    - GMonster3.prefab : 화면에서 세 번째로 보이는 빨간색 캔 몬스터에 해당된다.
    - GMonster4.prefab : 화면에서 네 번째로 보이는 밝은 노란색 배추 몬스터에 해당된다.
    - GMonster5.prefab : 화면에서 다섯 번째로 보이는 파란색 서류가방 몬스터에 해당된다.
    - GMonster6.prefab : 화면에서 제일 뒤에 보이는 밝은 초록색 비닐봉지 몬스터에 해당된다.
  - Scripts
    - ActiveTrashMonster.cs : 자동으로 좌우로 쓰레기 몬스터들이 움직이게 한다.
    - ControlMonster.cs : 몬스터들을 6개로 한정하며 만약 몬스터들이 다 삭제가 된다면 다음 페이지로 자동으로 넘기게 한다.
    - KillTheMonster.cs : 몬스터들의 체력, 몇 번을 클릭해야 사라지게 하는지, 앞의 상황이 발생하였을 때 소리가 작동할 수 있게 한다.
    - SoundEffectes.cs : 몬스터들이 사라지고, 체력이 줄어들 때 소리들이 날 수 있게 소리를 저장한다.
***




