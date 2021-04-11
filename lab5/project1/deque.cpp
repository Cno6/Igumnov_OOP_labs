#include "header.h"

Deque::Deque(int count)
	:count(count)
{
	arr = new int[count];
}

Deque::Deque(const Deque &other)
{
	arr = new int[other.count];
	count = other.count;
	end = other.end;
	size = other.size;
	for (int i = 0; i < count; ++i)
	{
		arr[i] = other.arr[i];
	}
}

Deque::Deque(Deque &&other) 
{
	arr = other.arr;
	count = other.count;
	other.arr = nullptr;
}

Deque::~Deque()
{
	delete[] arr;
}

Deque &Deque::operator=(const Deque &other)
{
	if (this == &other) { return *this; }
	delete[] arr;
	arr = new int[other.count];
	count = other.count;
	for (int i = 0; i < count; ++i)
	{
		arr[i] = other.arr[i];
	}
}

Deque &Deque::operator=(Deque &&other)
{
	if (this == &other) { return *this; }
	delete[] arr;
	arr = other.arr;
	count = other.count;
	other.arr = nullptr;
}

ostream& operator << (ostream& stream, const Deque& a)
{
	for (int i = 0; i < a.size; i++)
		stream << a.arr[i] << " ";
	return stream;
}

int Deque::GetSize()
{
	return this->size;
}

void Deque::PushFront(int element)
{
	if (size <= count)
	{
		int *tmp = new int[size];
		for (int i = 0; i <= size; i++)
		{
			tmp[i] = arr[i];
		}
		for(int i = 0; i <= size; i++) 
		{
			arr[i + 1] = tmp[i];
		}
		arr[0] = element;
		size++;
		end++;
	}
}

void Deque::PushBack(int element)
{
	if (size <= count)
	{
		end += 1;
		arr[end] = element;
		size++;
	}
}

void Deque::PopFront()
{
	if (size <= count)
	{
		for (int i = 0; i < end; i++)
		{
			arr[i] = arr[i+1];
		}
		arr[end] = 0;
		end--;
		size--;
	}
}

void Deque::PopBack()
{
	if (size <= count)
	{
		arr[end] = 0;
		end--;
		size--;
	}
}

int Deque::PeekFront()
{
	return arr[0];
}

int Deque::PeekBack()
{
	return arr[end];
}

void Deque::GetFirst(int element)
{
	arr[0] = element;
	size++;
}
