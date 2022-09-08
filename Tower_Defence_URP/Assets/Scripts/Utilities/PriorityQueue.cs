using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<T>
{

	List<Tuple<T, float>> elements = new List<Tuple<T, float>>();


	/// <summary>
	/// Return the total number of elements currently in the Queue.
	/// </summary>
	/// <returns>Total number of elements currently in Queue</returns>
	public int Count
	{
		get { return elements.Count; }
	}


	/// <summary>
	/// Add given item to Queue and assign item the given priority value.
	/// </summary>
	/// <param name="item">Item to be added.</param>
	/// <param name="priorityValue">Item priority value as Double.</param>
	public void Push(T item, float priorityValue)
	{
		if (priorityValue < 0)
        {
			throw new ArgumentOutOfRangeException("priorityValue must not be negative");
        }
		elements.Add(Tuple.Create(item, priorityValue));
	}


	/// <summary>
	/// Return lowest priority value item and remove item from Queue.
	/// </summary>
	/// <returns>Queue item with lowest priority value.</returns>
	public T Pop()
	{
		int bestPriorityIndex = -1;

		for (int i = 0; i < elements.Count; i++)
		{
			if (elements[i].Item2 < elements[bestPriorityIndex].Item2)
			{
				bestPriorityIndex = i;
			}
		}

		T bestItem = elements[bestPriorityIndex].Item1;
		elements.RemoveAt(bestPriorityIndex);
		return bestItem;
	}


	/// <summary>
	/// Return lowest priority value item without removing item from Queue.
	/// </summary>
	/// <returns>Queue item with lowest priority value.</returns>
	public T Peek()
	{
		int bestPriorityIndex = 0;

		for (int i = 0; i < elements.Count; i++)
		{
			if (elements[i].Item2 < elements[bestPriorityIndex].Item2)
			{
				bestPriorityIndex = i;
			}
		}

		T bestItem = elements[bestPriorityIndex].Item1;
		return bestItem;
	}

	/// <summary>
	/// If an item is already in the queue, update its priority value. Else, put it in the queue.
	/// </summary>
	/// <param name="item"></param>
	/// <param name="priorityValue"></param>
	public void Update(T item, float priorityValue)
    {
		Tuple<T, float> node;
        for (int i = 0; i < elements.Count; i++)
        {
			node = elements[i];
			if (node.Item1.Equals(item))
			{
				if (node.Item2 > priorityValue)
				{
					elements[i] = Tuple.Create(item, priorityValue);
				}
				break;
			}
		}
		Push(item, priorityValue);
    }
}
