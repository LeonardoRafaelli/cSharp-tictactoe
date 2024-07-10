//// See https://aka.ms/new-console-template for more information
using CSharpTicTacToe.ADT;

using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;

char freeSlotSpace = ' ';
char[] slots = Enumerable.Repeat(freeSlotSpace, 9).ToArray();
string[] possibleAnswers = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
char playerTurn = 'X';
char winner = ' ';
int roundNumber = 0;

printGameBoard();

while (true)
{
    Console.WriteLine($"\nTurn: {playerTurn}");
    string? userInput = requestUserInput("Play position (1-9): ");

    if (possibleAnswers.Contains(userInput))
    {
        int slotNumber = parseUserInputToInt(userInput!);
        makePlayOnPlace(slotNumber);

        if(isEndGame() && !playAgain()){ break; };

        printGameBoard();
    }
}

string? requestUserInput(string requestText)
{
    Console.Write(requestText);
    return Console.ReadLine();
}

int parseUserInputToInt(string userInput)
{
    return int.Parse(userInput) - 1; // -1 to match slots index
}

void makePlayOnPlace(int slotNumber)
{
    if (isSlotFree(slotNumber))
    {
        slots[slotNumber] = playerTurn;
        roundNumber++;

        changePlayerTurn();
    };

}

bool isSlotFree(int slotNumber)
{
    return slots[slotNumber] == freeSlotSpace;
}

void changePlayerTurn()
{
    playerTurn = (playerTurn == 'X') ? 'O' : 'X';
}

bool isEndGame()
{
    if (roundNumber >= 5)
    {
        if (isAnyWinner())
        {
            printGameBoard();
            showWinner();
            return true;
        }
        else if (roundNumber == 9)
        {
            printGameBoard();
            showTie();
            return true;
        };
    }
    return false;
}

bool isAnyWinner()
{
    bool winLine1 = slots[0] == slots[1] && slots[1] == slots[2] && slots[2] != ' ';
    bool winLine2 = slots[3] == slots[4] && slots[4] == slots[5] && slots[5] != ' ';
    bool winLine3 = slots[6] == slots[7] && slots[7] == slots[8] && slots[8] != ' ';
    bool winCol1 = slots[0] == slots[3] && slots[3] == slots[6] && slots[6] != ' ';
    bool winCol2 = slots[1] == slots[4] && slots[4] == slots[7] && slots[7] != ' ';
    bool winCol3 = slots[2] == slots[5] && slots[5] == slots[8] && slots[8] != ' ';
    bool winDia1 = slots[0] == slots[4] && slots[4] == slots[8] && slots[8] != ' ';
    bool winDia2 = slots[2] == slots[4] && slots[4] == slots[6] && slots[6] != ' ';

    // Set winner
    if (winLine1 || winCol1 || winDia1) winner = slots[0];
    if (winLine2) winner = slots[3];
    if (winCol2) winner = slots[1];
    if (winLine3 || winCol3 || winDia2) winner = slots[2];

    // Resume return
    bool winLine = winLine1 || winLine2 || winLine3;
    bool winCol = winCol1 || winCol2 || winCol3;
    bool winDia = winDia1 || winDia2;

    return (winLine || winCol || winDia);
}

void showWinner()
{
    Console.WriteLine($"End game\nWinner: {winner}\n");
}

void showTie()
{
    Console.WriteLine("End game\nIt's a tie - No Winner!\n");
}
bool playAgain()
{ 
    string? playAgainUserInput = requestUserInput("Play again? 1 - Yes | 2 - No\nInput: ");

    #pragma warning disable CA1861
    while (!new[] { "1", "2" }.Contains(playAgainUserInput))
    {
        playAgainUserInput = requestUserInput("Play again? 1 - Yes | 2 - No\nInput: ");
    }
    #pragma warning restore CA1861

    bool isPlayAgain = playAgainUserInput == "1";

    if(isPlayAgain)
    {
        resetGame();
    }

    return isPlayAgain;
}

void resetGame()
{
    clearSlots();
    winner = ' ';
    roundNumber = 0;
    playerTurn = 'X';
}

void clearSlots()
{
    for (int i = 0; i < slots.Length; i++)
    {
        slots[i] = freeSlotSpace;
    }
}

void printGameBoard()
{
    Console.WriteLine();
    for (int i = 1; i <= slots.Length; i++)
    {
        Console.Write(slots[i - 1]);
        if (i % 3 == 0)
        {
            Console.WriteLine();
        }
        else
        {
            Console.Write(" | ");
        }
    }
}