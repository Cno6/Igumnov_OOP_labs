#pragma once
#include <iostream>
using namespace std;

template<typename T>
class DequeTemp
{
	T *arr;
	int count;
	int end = 0, size = 0;
public:
	DequeTemp(int count)
		: count(count)
	{
		this->count = count;
		arr = new T[count];
	}
	DequeTemp(const DequeTemp &other)
	{
		arr = new T[other.count];
		count = other.count;
		end = other.end;
		size = other.size;
		for (int i = 0; i < count; ++i)
		{
			arr[i] = other.arr[i];
		}
	}
	DequeTemp(DequeTemp &&other)
	{
		arr = other.arr;
		count = other.count;
		other.arr = nullptr;
	}
	~DequeTemp()
	{
		delete[] arr;
	}
	DequeTemp &operator=(const DequeTemp &other)
	{
		if (this == &other)
		{
			return *this;
		}
		delete[] arr;
		arr = new T[other.count];
		count = other.count;
		for (int i = 0; i < count; ++i)
		{
			arr[i] = other.arr[i];
		}
	}
	DequeTemp &operator=(DequeTemp &&other)
	{
		if (this == &other)
		{
			return *this;
		}
		delete[] arr;
		arr = other.arr;
		count = other.count;
		other.arr = nullptr;
	}
	friend ostream& operator<<(ostream& stream, DequeTemp& a)
	{
		for (int i = 0; i < a.size; i++)
			stream << a.arr[i] << " ";
		return stream;
	}	
	int GetSize()
	{
		return this->size;
	}
	void PushFront(T element)
	{
		if (size <= count)
		{
			int* tmp = new int[size];
			for (int i = 0; i <= size; i++)
			{
				tmp[i] = arr[i];
			}
			for (int i = 0; i <= size; i++)
			{
				arr[i + 1] = tmp[i];
			}
			arr[0] = element;
			size++;
			end++;
		}
	}
	void PushBack(T element)
	{
		if (size <= count)
		{
			end += 1;
			arr[end] = element;
			size++;
		}
	}
	void PopFront()
	{
		if (size <= count)
		{
			for (int i = 0; i < end; i++)
			{
				arr[i] = arr[i + 1];
			}
			arr[end] = 0;
			end--;
			size--;
		}
	}
	void PopBack()
	{
		if (size <= count)
		{
			arr[end] = 0;
			end--;
			size--;
		} 
	}
	T PeekFront()
	{
		return arr[0];
	}
	T PeekBack()
	{
		return arr[end];
	}
	void GetFirst(T element)
	{
		arr[0] = element;
		size++;
	}
};