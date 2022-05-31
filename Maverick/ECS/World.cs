using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maverick.ECS
{
	public static class World
	{
		//	COPILOT POWER MWAHAHA
		public delegate void ActionRef<T>(ref T component) where T : struct;
		public static void ForEach<T>(ActionRef<T> action) where T : struct
		{
			foreach (var entity in Manager.Instance.entities)
			{
				if (entity.HasComponent<T>())
				{
					ref var component = ref entity.GetComponent<T>();
					action(ref component);
				}
			}
		}

		public delegate void ActionRef<T1, T2>(ref T1 component1, ref T2 component2) where T1 : struct where T2 : struct;
		public static void ForEach<T1, T2>(ActionRef<T1, T2> action) where T1 : struct where T2 : struct
		{
			foreach (var entity in Manager.Instance.entities)
			{
				if (entity.HasComponent<T1>() && entity.HasComponent<T2>())
				{
					ref var component1 = ref entity.GetComponent<T1>();
					ref var component2 = ref entity.GetComponent<T2>();
					action(ref component1, ref component2);
				}
			}
		}

		public delegate void ActionRef<T1, T2, T3>(ref T1 component1, ref T2 component2, ref T3 component3) where T1 : struct where T2 : struct where T3 : struct;
		public static void ForEach<T1, T2, T3>(ActionRef<T1, T2, T3> action) where T1 : struct where T2 : struct where T3 : struct
		{
			foreach (var entity in Manager.Instance.entities)
			{
				if (entity.HasComponent<T1>() && entity.HasComponent<T2>() && entity.HasComponent<T3>())
				{
					ref var component1 = ref entity.GetComponent<T1>();
					ref var component2 = ref entity.GetComponent<T2>();
					ref var component3 = ref entity.GetComponent<T3>();
					action(ref component1, ref component2, ref component3);
				}
			}
		}

		public delegate void ActionRef<T1, T2, T3, T4>(ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4) where T1 : struct where T2 : struct where T3 : struct where T4 : struct;
		public static void ForEach<T1, T2, T3, T4>(ActionRef<T1, T2, T3, T4> action) where T1 : struct where T2 : struct where T3 : struct where T4 : struct
		{
			foreach (var entity in Manager.Instance.entities)
			{
				if (entity.HasComponent<T1>() && entity.HasComponent<T2>() && entity.HasComponent<T3>() && entity.HasComponent<T4>())
				{
					ref var component1 = ref entity.GetComponent<T1>();
					ref var component2 = ref entity.GetComponent<T2>();
					ref var component3 = ref entity.GetComponent<T3>();
					ref var component4 = ref entity.GetComponent<T4>();
					action(ref component1, ref component2, ref component3, ref component4);
				}
			}
		}

		public delegate void ActionRef<T1, T2, T3, T4, T5>(ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4, ref T5 component5) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct;
		public static void ForEach<T1, T2, T3, T4, T5>(ActionRef<T1, T2, T3, T4, T5> action) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct
		{
			foreach (var entity in Manager.Instance.entities)
			{
				if (entity.HasComponent<T1>() && entity.HasComponent<T2>() && entity.HasComponent<T3>() && entity.HasComponent<T4>() && entity.HasComponent<T5>())
				{
					ref var component1 = ref entity.GetComponent<T1>();
					ref var component2 = ref entity.GetComponent<T2>();
					ref var component3 = ref entity.GetComponent<T3>();
					ref var component4 = ref entity.GetComponent<T4>();
					ref var component5 = ref entity.GetComponent<T5>();
					action(ref component1, ref component2, ref component3, ref component4, ref component5);
				}
			}
		}

		public delegate void ActionRef<T1, T2, T3, T4, T5, T6>(ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4, ref T5 component5, ref T6 component6) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct;
		public static void ForEach<T1, T2, T3, T4, T5, T6>(ActionRef<T1, T2, T3, T4, T5, T6> action) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct
		{
			foreach (var entity in Manager.Instance.entities)
			{
				if (entity.HasComponent<T1>() && entity.HasComponent<T2>() && entity.HasComponent<T3>() && entity.HasComponent<T4>() && entity.HasComponent<T5>() && entity.HasComponent<T6>())
				{
					ref var component1 = ref entity.GetComponent<T1>();
					ref var component2 = ref entity.GetComponent<T2>();
					ref var component3 = ref entity.GetComponent<T3>();
					ref var component4 = ref entity.GetComponent<T4>();
					ref var component5 = ref entity.GetComponent<T5>();
					ref var component6 = ref entity.GetComponent<T6>();
					action(ref component1, ref component2, ref component3, ref component4, ref component5, ref component6);
				}
			}
		}

		public delegate void ActionRef<T1, T2, T3, T4, T5, T6, T7>(ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4, ref T5 component5, ref T6 component6, ref T7 component7) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct;
		public static void ForEach<T1, T2, T3, T4, T5, T6, T7>(ActionRef<T1, T2, T3, T4, T5, T6, T7> action) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct
		{
			foreach (var entity in Manager.Instance.entities)
			{
				if (entity.HasComponent<T1>() && entity.HasComponent<T2>() && entity.HasComponent<T3>() && entity.HasComponent<T4>() && entity.HasComponent<T5>() && entity.HasComponent<T6>() && entity.HasComponent<T7>())
				{
					ref var component1 = ref entity.GetComponent<T1>();
					ref var component2 = ref entity.GetComponent<T2>();
					ref var component3 = ref entity.GetComponent<T3>();
					ref var component4 = ref entity.GetComponent<T4>();
					ref var component5 = ref entity.GetComponent<T5>();
					ref var component6 = ref entity.GetComponent<T6>();
					ref var component7 = ref entity.GetComponent<T7>();
					action(ref component1, ref component2, ref component3, ref component4, ref component5, ref component6, ref component7);
				}
			}
		}

		public delegate void ActionRef<T1, T2, T3, T4, T5, T6, T7, T8>(ref T1 component1, ref T2 component2, ref T3 component3, ref T4 component4,
			ref T5 component5, ref T6 component6, ref T7 component7, ref T8 component8)
			where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct;
		public static void ForEach<T1, T2, T3, T4, T5, T6, T7, T8>(ActionRef<T1, T2, T3, T4, T5, T6, T7, T8> action)
			where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct
		{
			foreach (var entity in Manager.Instance.entities)
			{
				if (entity.HasComponent<T1>() && entity.HasComponent<T2>() && entity.HasComponent<T3>() && entity.HasComponent<T4>()
					&& entity.HasComponent<T5>() && entity.HasComponent<T6>() && entity.HasComponent<T7>() && entity.HasComponent<T8>())
				{
					ref var component1 = ref entity.GetComponent<T1>();
					ref var component2 = ref entity.GetComponent<T2>();
					ref var component3 = ref entity.GetComponent<T3>();
					ref var component4 = ref entity.GetComponent<T4>();
					ref var component5 = ref entity.GetComponent<T5>();
					ref var component6 = ref entity.GetComponent<T6>();
					ref var component7 = ref entity.GetComponent<T7>();
					ref var component8 = ref entity.GetComponent<T8>();
					action(ref component1, ref component2, ref component3, ref component4, ref component5, ref component6, ref component7, ref component8);
				}
			}
		}
	}
}
