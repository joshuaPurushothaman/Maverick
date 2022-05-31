using System.ComponentModel;

namespace Maverick.ECS
{
	interface IComponentList
	{
	}

	class ComponentList<T> : IComponentList where T : struct
	{
		public RefList<T> components = new();
		public Dictionary<int, int> entityIDToIndex = new();
	}

	//	TODO: Memory safety??? References get invalidated upon resizing :( (I think?)
	// thanks https://www.vogella.com/tutorials/JavaDatastructureList/article.html !
	class RefList<T> where T : struct
	{
		T[] components;
		int count = 0;

		public RefList()
		{
			components = new T[4];
		}

		public void Add(T component)
		{
			if (count == components.Length)
				Array.Resize(ref components, components.Length * 2);

			components[count] = component;
			count++;
		}

		public ref T this[int index]
		{
			get => ref components[index];
		}
		
		public int Count
		{
			get => count;
		}
	}

	static class ExtensionMethods
	{
		public static bool Contains<T>(this IComponentList list, int entityID) where T : struct
		{
			return ((ComponentList<T>)list).entityIDToIndex.ContainsKey(entityID);
		}

		public static void Add<T>(this IComponentList list, int entityID, T component) where T : struct
		{
			if (list is ComponentList<T> componentList)
			{
				if (componentList.entityIDToIndex.TryGetValue(entityID, out int index))
				{
					componentList.components[index] = component;
				}
				else
				{
					componentList.components.Add(component);
					componentList.entityIDToIndex.Add(entityID, componentList.components.Count - 1);
				}
			}
		}

		public static bool TryGet<T>(this IComponentList list, int entityID, out T component) where T : struct
		{
			if (list is ComponentList<T> componentList)
			{
				if (componentList.entityIDToIndex.TryGetValue(entityID, out int index))
				{
					component = componentList.components[index];
					return true;
				}
			}

			component = default;
			return false;
		}

		public static ref T Get<T>(this IComponentList list, int entityID) where T : struct
		{
			if (list is ComponentList<T> componentList)
			{
				if (componentList.entityIDToIndex.TryGetValue(entityID, out int index))
				{
					return ref componentList.components[index];
				}
			}

			throw new KeyNotFoundException("Component not found");
		}

		public static bool TrySet<T>(this IComponentList list, int entityID, T value) where T : struct
		{
			if (list is ComponentList<T> componentList)
			{
				if (componentList.entityIDToIndex.TryGetValue(entityID, out int index))
				{
					componentList.components[index] = value;
					return true;
				}
			}
			return false;
		}
	}
}
