﻿//// See https://aka.ms/new-console-template for more information
//using CSharpTicTacToe.ADT;

//string input = "5";

//string[] possibleAnswers = ["1", "2", "3"];

//List<Pokemon> pokemonList = [];

//while (possibleAnswers.Contains(input))
//{
//    Console.Write("1 - Show list\n2 - Insert new pokemon\n3 - Delete\n4 - Close Op\nInput: ");
//    input = Console.ReadLine()!;

//    switch (input)
//    {
//        case "1": showPokemonList(); break;
//        case "2": insertPokemon(); break;

//    }

//}

//void showPokemonList()
//{

//    Console.Write(pokemonList);

//}

//void insertPokemon()
//{
//    Pokemon newPokemon = new();

//    Console.Write("Pokemon name: ");
//    string nameInput = Console.ReadLine()!;

//    newPokemon.Name = nameInput;

//    pokemonList.Add(newPokemon);
//}



// ---


int[] intArray = new int[6];

int length = 0;

for (int i = 0; i < 3; i++)
{
    intArray[i] = i;
}

intArray[^1] = 8;

for (int i = 0; i < intArray.Length; i++)
{
    Console.WriteLine(intArray[i]);
}