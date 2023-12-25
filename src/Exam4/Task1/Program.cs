Random random = new Random(DateTime.Now.Millisecond);

for(int i = 0; i < 10; i++)
    Console.WriteLine(GetRandomChar());

char GetRandomChar()
{
    return (char)random.Next('A', 'Z');
}