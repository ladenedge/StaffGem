using System;
using System.Linq;
using AutoFixture;
using NUnit.Framework;

namespace StaffGem
{
    [TestFixture]
    public class StackTests
    {
        readonly Fixture _fixture = new Fixture();

        [Test]
        public void Constructor_throws_on_invalid_capacity()
        {
            Assert.That(() => new Stack(-1), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Push_can_push_onto_stack_with_zero_capacity()
        {
            var stack = new Stack(0);
            var node = _fixture.Create<StackNode>();
            Assert.That(() => stack.Push(node), Throws.Nothing);
        }

        [Test]
        public void Push_can_push_over_allotted_capacity()
        {
            var stack = new Stack(5);
            var nodes = _fixture.CreateMany<StackNode>(20);

            foreach (var node in nodes)
                stack.Push(node);
        }

        [Test]
        public void Pop_retrieves_last_in()
        {
            var stack = new Stack();
            var nodes = _fixture.CreateMany<StackNode>();

            foreach (var node in nodes)
                stack.Push(node);

            var last = stack.Pop();

            Assert.That(last, Is.SameAs(nodes.Last()));
        }

        [Test]
        public void Pop_retrieves_all_pushed_elements()
        {
            var stack = new Stack();
            var nodes = _fixture.CreateMany<StackNode>();

            foreach (var node in nodes)
                stack.Push(node);

            foreach (var node in nodes)
            {
                var last = stack.Pop();
                Assert.That(nodes, Has.Member(last));
            }
        }

        [Test]
        public void Pop_throws_with_empty_stack()
        {
            var stack = new Stack();
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }
    }
}
