#include <iostream>
using namespace std;

class Deque
{
private:
	int *arr;
	int count;
	int end = 0, size = 0;
	
public:
	Deque(int count);
	Deque(const Deque &other);
	Deque(Deque &&other);
	~Deque();

	int GetSize();
	void PushFront(int element);
	void PushBack(int element);
	void PopFront();
	void PopBack();
	int PeekFront();
	int PeekBack();
	void GetFirst(int element);
	Deque& operator=(const Deque &other); 
	Deque& operator=(Deque &&other);
	friend ostream& operator << (ostream& stream, const Deque &a);
};