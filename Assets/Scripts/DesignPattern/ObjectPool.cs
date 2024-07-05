using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace DesignPattern
{
	public class ObjectPool : MonoBehaviour
	{
		// 디자인 패턴 Object Pool

		// <오브젝트 풀>
		// 프로그램 내에서 빈번하게 재활용되는 많은 수의 인스턴스들을 생성, 삭제 하지 않고
		// 미리 생성해놓은 인스턴스들을 오브젝트 풀에 보관하고
		// 인스턴스를 대여, 반납하는 방식으로 사용되는 기법

		// 구현
		// 인스턴스들을 보관할 오브젝트 풀을 생성
		// 프로그램의 시작시 오브젝트 풀에 인스턴스들을 생성하여 보관
		// 인스턴스가 필요로 하는 상황에서 생성 대신 오브젝트 풀에서 인스턴스를 대여하여 사용
		// 인스턴스가 필요로 하지 않는 상황에서 삭제 대신 오브젝트 풀에 인스턴스를 반납하여 보관

		// 장점
		// 빈번하게 사용하는 인스턴스의 생성에 소요되는 오버헤드를 줄임
		// 빈번하게 사용하는 인스턴스의 삭제에 기비지 컬렉터의 부담을 줄임

		// 주의점
		// 미리 생성해놓은 인스턴스에 의해 사용하지 않는 경우에도 메모리를 차지하고 있음
		// 메모리가 넉넉하지 않은 상황에서 너무 많은 오브젝트 풀링을 적용하는 경우
		// 힙영역의 여유공간이 줄어들어 오히려 가비지 컬렉터에 부담이 주어 프로그램이 느려지는 경우에 주의
	}

	public class ObjectPooler : MonoBehaviour
	{
		private ObjectPool prefab;
		private Stack<ObjectPool> objectPool;
		private int poolSize = 100;

		public void CreatePool()
		{
			objectPool = new Stack<ObjectPool>(poolSize);
			for (int i = 0; i < poolSize; i++)
			{
				ObjectPool instance = Instantiate(prefab);
				instance.gameObject.SetActive(false);
				objectPool.Push(instance);
			}
		}

		public ObjectPool GetPool()
		{
			if (objectPool.Count > 0)
			{
				ObjectPool instance = objectPool.Pop();
				instance.gameObject.SetActive(true);
				return instance;
			}
			else
			{
				return Instantiate(prefab);
			}

		}

		public void ReturnPool(ObjectPool instance)
		{
			if (objectPool.Count < poolSize)
			{
				instance.gameObject.SetActive(false);
				objectPool.Push(instance);
			}
			else
			{
				Destroy(instance.gameObject);
			}
		}
	}
}


