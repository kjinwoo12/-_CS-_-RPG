using System;

class Program
{
    static void Main(string[] args)
    {
        IScene currentScene = new CreateCharacterScene();
        while (true)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            currentScene.OnShow();
            currentScene = currentScene.GetNextScene();
            if (currentScene == null)
            {
                break;
            }
        }
    }
}