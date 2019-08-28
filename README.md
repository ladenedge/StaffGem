# Greetings, StaffGem!

Thanks for taking a look at my code samples.

To jump right to the specific answers to your requests, you can use these links:

 * [`bool HasDuplicates(int[] items) { ... }`](https://github.com/ladenedge/StaffGem/blob/master/Duplicates/DuplicateFinder.cs#L14)
 * [`class Stack : IStack { ... }`](https://github.com/ladenedge/StaffGem/blob/master/Stack/Stack.cs)

Though it's simple code, I tried to demonstrate a few important development concepts, including:

 * **Unit tests**, which you can find in the [Tests](https://github.com/ladenedge/StaffGem/tree/master/Tests) folder. Though it's hard to tell, I used (and nearly always advocate) **test-driven development**.
 * A rough **strategy pattern** for changing the hash set used to find duplicates, since I wasn't sure if just using the .NET `HashSet` would count as cheating, heh.
 * **Inversion of control** to adjust the hashing strategy outside the duplicate finder itself.  **Dependency injection** is the bedrock of testable code.

Thanks again for your time!

