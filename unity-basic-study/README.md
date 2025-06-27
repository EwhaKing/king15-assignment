# Unity 핵심 기초 스터디 기록

작성자: 허예원  
기수: 15기  
강의 링크: [Unity for Beginners](https://learn.unity.com/course/try-unity-for-beginners?uv=2019.4)  
학습 기간: 2025년 3월 29일 ~ 2025년 4월 3일

---

## 1. 학습 개요

본 스터디는 Unity의 공식 입문 강의인 **"Unity for Beginners"** 전 과정을 수강한 뒤, 학습 내용을 체계적으로 정리하고 주요 기능들을 직접 실습한 결과를 기록한 것입니다.  

Unity의 에디터 구조와 사용법, 오브젝트 구성, Material과 Lighting, Animation, Audio 및 Video 제어 등 **Unity 기초의 모든 핵심 개념을 실습 중심으로 학습**하였습니다.

---

## 2. 학습 내용 정리

### 2.1 Unity 에디터 기초
- Unity Hub를 통한 프로젝트 생성
- Scene 뷰, Game 뷰, Hierarchy, Project, Inspector 창 역할 이해
- 기본적인 에디터 단축키와 뷰 조작법 익힘

### 2.2 GameObject와 Transform
- Cube, Sphere, Capsule 등 기본 오브젝트 생성 및 배치
- Position, Rotation, Scale 속성 직접 조정
- 오브젝트 계층 구조를 이용한 부모-자식 관계 설정 실습

### 2.3 Material과 Shader
- 머티리얼 색상, 메탈릭, 스무스니스 조절
- 텍스처 이미지 입히기
- Shader 유형에 따른 시각적 차이 실습

### 2.4 Lighting
- Directional, Point, Spot Light 비교 실습
- 실시간 조명 vs Baked 조명 비교
- 하늘 배경(Skybox) 설정 및 조명 반사 실험

### 2.5 Animation
- Animation Clip 생성 및 키프레임 기반 동작 구현
- Animator Controller 설정 및 Transition 구조 만들기
- 파라미터(Trigger, Bool 등) 기반으로 상태 전이 구현

### 2.6 Audio
- Audio Source 및 Audio Listener 구성
- 거리 기반 3D 사운드 설정
- 사용자 입력에 따른 오디오 재생/정지 구현 (`Play()`, `Stop()` 등)

### 2.7 Video
- VideoPlayer 컴포넌트 설정
- RenderTexture를 활용한 화면 출력
- 버튼/트리거를 통한 영상 재생 제어 구현

---

## 3. 실습 예시

아래는 학습한 기능들을 종합하여 실습한 예시 장면들입니다.  
각 기능의 구현 방식은 Unity 기본 기능과 스크립트 컴포넌트를 조합하여 구성했습니다.

---

### 3.1 자연 지형 씬 구성

- Unity의 Terrain 시스템을 활용하여 산악 지형을 조성하고, 하늘 배경과 Directional Light를 적용하여 밤하늘 효과를 연출하였습니다.
- 다양한 브러시와 텍스처를 활용하여 지형 표면의 질감도 자연스럽게 구성했습니다.

![Terrain Scene](Unity%20Terrain.png)

---

### 3.2 실내 공간 및 탈 것 구현

- Room1, Room2 구조를 구성하고 문(Door), 차량(Vehicle), FPSController를 배치하였습니다.
- Animator와 직접 작성한 C# 스크립트를 조합하여, 문 열기 애니메이션과 차량의 이동을 제어할 수 있도록 구성하였습니다.

![Vehicle & Animation](Unity%20Animation.png)

---

## 4. 제출 자료 구성

- `README.md` : 학습 내용 및 실습 결과 정리 문서 (현재 문서)
- `Unity Terrain.png` : 자연 지형 씬 캡처 이미지
- `Unity Animation.png` : 실내 씬 및 Vehicle 구성 이미지

---

## 5. 참고 사항

- 모든 실습은 Unity 2022.3.57f1 버전에서 진행되었으며, 별도의 에셋은 Unity Asset Store 및 기본 제공 기능을 활용하였습니다.
- 이미지 경로는 GitHub 업로드 시 같은 폴더 내에 함께 업로드되어야 정상적으로 표시됩니다.
