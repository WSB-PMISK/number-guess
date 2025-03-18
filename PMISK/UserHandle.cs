namespace PMISK;

public interface IHandler {
    public string ReadLine();
}

public class Handler : IHandler {
    public string ReadLine() {
        var readLine = Console.ReadLine()!.Trim();
        return readLine;
    }
}

public class UserHandler(IHandler handler) {
    public string Ask(string question) {
        Console.Write($"[ PYTANIE ] {question}: ");
        var answer = handler.ReadLine().Trim();

        if (string.IsNullOrEmpty(answer)) {
            Console.WriteLine("Prosze podac odpowiedz");
            answer = Ask(question);
        }

        return answer;
    }
    
    public string GetChoiceList(string[] choices) {
        var list = "";

        for (var i = 1;i<=choices.Length;i++) {
            list += $"  {i}. {choices[i-1]}\n";
        }

        return list.Substring(0, list.Length - 1);
    }
}