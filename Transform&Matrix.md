# TRS Matrix culc.

## What is Transform?

#### Transform은 Unity에서 게임 오브젝트의 위치, 회전, 스케일, 부모ㅡ자식 상태를 저장하기 위해 사용한다.
#### 게임 오브젝트에는 항상 하나의 Transform 컴포턴트가 있다.
#### 트랜스폼은 제거하거나 트랜스폼이 없는 게임 오브젝트에 생성하지 못한다.
#### Transform을 사용하여 부모-자식을 연결하면 부모의 TRS를 자식이 상속 받는다.
#### Transform은 Position (위치), Rotation (회전), Scale (크기) 총 3종류로 이루어진 컴포넌트를 가지고 있다.

## What is TRS?

### TRS는 transform의 컴포넌트 안에 있는 요소들을 변환하는 4*4 행렬로, 각각 Translation (위치), Rotation (회전), Scale (크기)를 나타낸다.

### Translation 행렬
$\begin{pmatrix}1 & 0 & 0 & t_x\\0 & 1 & 0 & t_y\\0&0&1&t_z\\0&0&0&1\end{pmatrix}$
### 이게 맞나
1|0|0|$t_x$
0|1|0|$t_y$
0|0|1|$t_z%
0|0|0|1

### Rotation 행렬은 x,y,z 총 3개의 기준 축에 대한 행렬이 있다.

#### Rotation 행렬 (x축 기준 회전)
$\begin{bmatrix}1&0&0&0\\0&cos\theta&-sin\theta&0\\0&sin\theta&cos\theta&0\\0&0&0&1\\ \end{bmatrix}$

#### Rotation 행렬 (y축 기준 회전)
$\begin{pmatrix}cos\theta&0&sin\theta&0\\0&1&0&0\\-sin\theta&0&cos\theta&0\\0&0&01\\ \end{pmatrix}$

#### Rotation 행렬 (z축 기준 회전)
$\begin{pmatrix}cos\theta&-sin\theta&0&0\\\sin\theta&cos\theta&0&0\\0&0&1&0\\0&0&0&1\\ \end{pmatrix}$

##### Rotation 행렬은 기준 축이 z,y,x 순서로 계산되어 합산된다.

### Scale 행렬
$\begin{pmatrix}S_x&0&0&0\\0&S_y&0&0\\0&0&S_z&0\\0&0&0&1\\ \end{pmatrix}$

### 모든 행렬이 4x4크기인 이유는?
1. 단일 행렬로 모든 변환을 표현 가능
- 이동, 회전, 확대 or 축소 등 모든 변환을 하나의 행렬로 표현할 수 있어 코드가 간결해진다.
2. 효율적인 계산
- 4x4 크기의 행렬을 사용하여 모든 변환을 하나의 행렬로 표현하여 계산이 간단하고 효율적이다.
3. 일관된 표현
- 동차 좌표계를 사용하여 모든 변환이 동일한 방식으로 표현되어 코드가 더 일관되고 이해하기 쉬워진다.

## How can I merge them?

### Unity를 포함한 많은 게임 엔진들은 Scale, Rotation, Translation의 순서로 계산된다.
#### 1.Scale은 Rotation이나 Translation 행렬에 영향을 주지 않기 때문에 맨 처음에 계산된다.
#### 2. Rotation은 Scale에는 영향을 주지 않지만 Object의 방향이 바뀌기 때문에 Translation에 영향을 주기 때문에 2번째로 계산된다.
#### 3. Translation은 Scale이나 Rotation에 영향을 받지 않기 때문에 마지막에 계산한다.

## How can I culculate them?

### c#에는 MatrixAdd를 사용한 행렬의 합, MatrixSubtract를 사용한 행렬의 뺄셈과 MatrixMultiply를 이용한 행렬의 곱셈이 있다.

#### Translation과 Scale은 Vector3 값을 사용해서 $t_x,t_y,t_z$를 표현한다.
#### Rotation에서는 Quaternion의 Euler를 사용해서 $r_x, r_y,r_z$를 표현한다.
#### 유니티에서는 'Matrix4x4' 클래스를 사용하여 행렬을 표현할 수 있다.

##### Matrix4x4 사용 예시
<pre><code>//Matrix 1번
Matrix4x4 matrixA = new Matrix4x4(
  new Vector4(1, 2, 3, 4),
  new Vector4(5, 6, 7, 8),
  new Vector4(9, 10, 11, 12),
  new Vector4(13, 14, 15, 16)
);
//Matrix 2번
Matrix4x4 matrixB = new Matrix4x4(
  new Vector4(1, 0, 0, 0),
  new Vector4(0, 1, 0, 0),
  new Vector4(0, 0, 1, 0),
  new Vector4(0, 0, 0, 1)
);</code></pre>
#### 행렬의 곱은 TRS 행렬을 종합하여 계산할때 필요하다.
#### 행렬의 곱은 4x4 행렬의 내적으로 이루어 진다.
#### Matrix4x4를 사용할때는 곱셈으로, Vector3나 Euler를 사용할때는 4x4 행렬로 변환해서 연산한다.
##### Matrix4x4 곱셈 사용 예시
<pre><code>Matrix4x4 MultipliedMatrix = matrixA * matrixB;</pre></code>
### 4x4 행렬의 곱셈 (내적)
#### 행렬의 곱셈은 곱해지는 1번 Matrix의 가로 길이와 곱하는 2번 Matrix의 세로 길이가 동일할때만 가능하다.
#### 행렬 곱셈 과정
<pre><code>for (int i = 0; i < 4; i++)
{
  for (int j = 0; j < 4; j++)
  {
    resultMatrix[i, j] = 
    matrixA[i, 0] * matrixB[0, j] +
    matrixA[i, 1] * matrixB[1, j] +
    matrixA[i, 2] * matrixB[2, j] +
    matrixA[i, 3] * matrixB[3, j];
  }
}</code></pre>
#### 행렬의 i번째 가로줄의 j번째 세로줄 위치의 요소는 위의 공식으로 계산된다.
---

##### 후기
###### 마크다운 문법을 사용해서 문서를 작성해본 경험은 처음이지만 chat gpt에서 행렬을 표시하기 직전에 잠깐 뜨는 문법, 디스코드에서 텍스트로 다양한 형식을 표현하는 방법 등 생각보다 많은 곳에서 활용되고 있는 것을 확인했다. 이번 기회를 통해 마크다운 문법에 대한 경험이 늘어 좋다고 생각한다.