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
- 오일러 각(Euler Angles), 180도 넘는 회전까지 표현, 짐벌락 발생
3차원 공간의 절대 좌표를 기준으로 물체의 회전을 측정하는 방식
짐벌락 : 오일러 각의회전은 먼저 회전한 축이 회전 안하는 축을 함께 회전시킨다. 결과에서 세번 째와 첫번째가 겹치는 것
- 쿼터니언(Quaternion), 계산시 비용이 적고 직관적이지 못하다.
하나의벡터(x, y, z)와 하나의 스칼라(w, roll)로 구성, 직접 접근 수정하지 않는다.
세 축을 동시에 회전시킨다. 벡터가 위치(position)와 방향(direction) 이듯, 쿼터니언은 방향(orientation)과 회전(rotation)이다.
- Quaternion.LookRotation( 대상 오브젝트의 위치, 머리의 방향 ), 2번 매개변수는 기본적으로 월드의 위방향
대상 오브젝트를 바라보게 한다. 해당 오브젝트의 회전 값을 지정
- Quaternion.Slerp(회전a, 회전b, 시간)
회전a는 해당오브젝트의 회전값, 회전b는 대상오브젝트의 회전값이다.
A회전값에서 B회전값까지 시간동안 회전하게 된다.


https://daebalstudio.tistory.com/entry/%EC%95%A1%EC%85%98%EA%B3%BC-%EB%9E%8C%EB%8B%A4-%ED%95%A8%EC%88%98-%EC%99%84%EB%B2%BD%ED%95%98%EA%B2%8C-%EC%9D%B4%ED%95%B4%ED%95%98%EA%B8%B0
https://ksuo.tistory.com/48
https://euncero.tistory.com/361
(선형보간[Lerp]과 구면선형보간[Slerp])
https://gnaseel.tistory.com/14
