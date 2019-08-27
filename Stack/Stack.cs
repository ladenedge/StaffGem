using System;

namespace StaffGem
{
    public class Stack : IStack
    {
        StackNode[] _stack;
        int _stackSize = 0;
        const int _defaultSize = 10;

        public Stack() : this(_defaultSize) { }
        public Stack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Initial capacity must not be negative.");
            if (capacity < _defaultSize)
                capacity = _defaultSize;

            _stack = new StackNode[capacity];
        }

        public void Push(StackNode node)
        {
            if (_stackSize == _stack.Length)
                Array.Resize(ref _stack, _stackSize * 2);

            _stack[_stackSize++] = node;
        }

        public StackNode Pop()
        {
            if (_stackSize == 0)
                throw new InvalidOperationException("Popped an empty stack.");

            return _stack[--_stackSize];
        }
    }
}
