# TutoDS

> EP01 - InputSystem
1. PakageManager에서 InputSystem설치
2. 프로젝트에서 InputActions생성 > ActionMaps > Actions > ActionType과 Key지정
3. InputActions오브젝트생성, Vector2오브젝트에 InputAction의 performed()와 ReadValue<Vector2>()로 값을 전달한다.
4. OnEnable, OnDisable로 InputActions 오브젝트를 작성
> EP02 
게임 공간에서 벡터의 위치값을 구할 때 현재 좌표를 기준으로 거리를 구한다면 상대 좌표로 사용
게임 월드에서 원점을 기준으로 거리를 구한다면 절대 좌표로 사용
- Normalize(정규화)
어떠한 벡터를 크기가 1인 벡터로 만드는 것이며, 정규화한 벡터를 단위 벡터라고 한다.
결국 벡터의 크기가 1인 벡터에 어떤 수를 곱하면 방향 벡터의 부호만을 따지게 된다.
벡터의 방향을 구하는 방법은 목표점 - 시작점을 한 후 방향값에 정규화를 해주어야 방향 벡터가 된다.
- 백터의연산 : 벡터에 배수를 취한다. (Vector3 * 스칼라값;)
AddForce: 같은 힘을 연속해서 가하면 가속화
Velocity: 같은 힘을 가해도 등속운동하도록 물리엔진이 자동계산
  
https://daebalstudio.tistory.com/entry/%EC%95%A1%EC%85%98%EA%B3%BC-%EB%9E%8C%EB%8B%A4-%ED%95%A8%EC%88%98-%EC%99%84%EB%B2%BD%ED%95%98%EA%B2%8C-%EC%9D%B4%ED%95%B4%ED%95%98%EA%B8%B0
https://ksuo.tistory.com/48
https://euncero.tistory.com/361
