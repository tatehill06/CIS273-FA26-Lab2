namespace BalancedParentheses;

public class Program
{
    static void Main(string[] args)
    {
        IsBalanced("{ int a = new int[ ] ( ( ) ) }");
    }

    /// <summary>
    /// Write a method IsBalanced() that tests a string for balanced parentheses.
    /// The string is balanced when every opening parenthesis has a matching closing
    /// parenthesis of the same kind, and they are closed in the correct order.
    /// Your code must work for all four kinds: &lt; &gt;, { }, [ ], and ( ).
    /// Ignore any other characters in the string.
    /// </summary>
    /// <example>
    /// <code>
    /// IsBalanced("{ int a = new int[ ] ( ( ) ) }"); // true
    /// IsBalanced("{ () ) ) ( ( }");                 // false
    /// IsBalanced(" ( ( [ &lt; ] &gt; ) ) ");        // false (closed in the wrong order)
    /// IsBalanced(" ( ( [ ");                        // false (never closed)
    /// IsBalanced(" ] ");                            // false (nothing to close)
    /// </code>
    /// </example>
    /// <param name="s">The string to check. It may contain any characters.</param>
    /// <returns>true if the parentheses in <paramref name="s"/> are balanced; otherwise, false.</returns>
    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        //string[] tokens = s.Split();

        foreach(var character in s )
        {
            //Console.WriteLine(character);

            if(character == '{' || character == '(' || character == '[' || character == '<')
            {
                // push char to stack
                stack.Push(character);
            }

            if(character == '}' || character == ')' || character == ']' || character == '>')
            {
                
                if( stack.Count == 0)
                {
                    return false;
                }
                // check if top of stack matches
                char mostRecentSymbol = stack.Pop();

                if( !Matches(mostRecentSymbol, character))
                {
                    return false;
                }

            }
        }

        return stack.Count == 0;
            
    }
    public static bool Matches(char open, char close)
    {
        return (open == '{' && close == '}') ||
           (open == '(' && close == ')') ||
           (open == '[' && close == ']') ||
           (open == '<' && close == '>');
    }
}

