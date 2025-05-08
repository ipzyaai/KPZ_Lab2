using System;
using System.Threading;

public sealed class Authenticator
{
    private static volatile Authenticator instance;
    private static readonly object lockObject = new object();
    private Authenticator()
    {
        if (instance != null)
        {
            throw new InvalidOperationException("Use GetInstance() method to get the single instance of this class.");
        }
    }

    public static Authenticator GetInstance()
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Authenticator();
                }
            }
        }
        return instance;
    }

    public void Authenticate(string username, string password)
    {
        Console.WriteLine($"Authenticating user: {username}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Authenticator auth1 = Authenticator.GetInstance();
        Authenticator auth2 = Authenticator.GetInstance();

        Console.WriteLine($"auth1 і auth2 це один і той же об'єкт? {object.ReferenceEquals(auth1, auth2)}");

        auth1.Authenticate("admin", "password123");

        Thread thread1 = new Thread(() => {
            Authenticator auth = Authenticator.GetInstance();
            Console.WriteLine($"Authenticator instance in thread {Thread.CurrentThread.ManagedThreadId}: {auth.GetHashCode()}");
        });

        Thread thread2 = new Thread(() => {
            Authenticator auth = Authenticator.GetInstance();
            Console.WriteLine($"Authenticator instance in thread {Thread.CurrentThread.ManagedThreadId}: {auth.GetHashCode()}");
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
