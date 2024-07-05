using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace DesignPattern
{
	public class ObjectPool : MonoBehaviour
	{
		// ������ ���� Object Pool

		// <������Ʈ Ǯ>
		// ���α׷� ������ ����ϰ� ��Ȱ��Ǵ� ���� ���� �ν��Ͻ����� ����, ���� ���� �ʰ�
		// �̸� �����س��� �ν��Ͻ����� ������Ʈ Ǯ�� �����ϰ�
		// �ν��Ͻ��� �뿩, �ݳ��ϴ� ������� ���Ǵ� ���

		// ����
		// �ν��Ͻ����� ������ ������Ʈ Ǯ�� ����
		// ���α׷��� ���۽� ������Ʈ Ǯ�� �ν��Ͻ����� �����Ͽ� ����
		// �ν��Ͻ��� �ʿ�� �ϴ� ��Ȳ���� ���� ��� ������Ʈ Ǯ���� �ν��Ͻ��� �뿩�Ͽ� ���
		// �ν��Ͻ��� �ʿ�� ���� �ʴ� ��Ȳ���� ���� ��� ������Ʈ Ǯ�� �ν��Ͻ��� �ݳ��Ͽ� ����

		// ����
		// ����ϰ� ����ϴ� �ν��Ͻ��� ������ �ҿ�Ǵ� ������带 ����
		// ����ϰ� ����ϴ� �ν��Ͻ��� ������ ����� �÷����� �δ��� ����

		// ������
		// �̸� �����س��� �ν��Ͻ��� ���� ������� �ʴ� ��쿡�� �޸𸮸� �����ϰ� ����
		// �޸𸮰� �˳����� ���� ��Ȳ���� �ʹ� ���� ������Ʈ Ǯ���� �����ϴ� ���
		// �������� ���������� �پ��� ������ ������ �÷��Ϳ� �δ��� �־� ���α׷��� �������� ��쿡 ����
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


